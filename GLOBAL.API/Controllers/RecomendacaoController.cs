using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using Microsoft.ML.Data;
using System.Text.Json;
using System.IO;

namespace Ecommerce.Cliente.API.Controllers
{
    // Classe com a estrutura de treinamento e dados para 
    public class DadosRecomendacao
    {
        [LoadColumn(0)] public int Id { get; set; }
        [LoadColumn(1)] public float EnergyLevel { get; set; } // Variável de previsão (label)
        [LoadColumn(2)] public string DeviceName { get; set; } // Recurso categórico
    }

    // Classe que retorna as previsões de recomendação
    public class RecomendacaoProduto
    {
        [ColumnName("Score")]
        public float PontuacaoRecomendacao { get; set; }

        [ColumnName("DeviceName")]
        public string DeviceName { get; set; } = string.Empty;

        [ColumnName("EnergyLevel")]
        public float EnergyLevel { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class RecomendacaoController : ControllerBase
    {
        private readonly string caminhoModelo = Path.Combine(Environment.CurrentDirectory, "wwwroot", "MLModels", "ModeloRecomendacao.zip");
        private readonly string caminhoTreinamento = Path.Combine(Environment.CurrentDirectory, "Data", "recomendacao-train.csv");
        private readonly MLContext mlContext;

        public RecomendacaoController()
        {
            mlContext = new MLContext();

            if (!System.IO.File.Exists(caminhoModelo))
            {
                Console.WriteLine("Modelo não encontrado. Iniciando treinamento...");
                TreinarModelo();
            }
        }

        [HttpGet("recomendar/{energyLevel}/{deviceName}")]
        public IActionResult Recomendar(float energyLevel, string deviceName)
        {
            if (!System.IO.File.Exists(caminhoModelo))
            {
                return BadRequest("O modelo ainda não foi treinado.");
            }

            ITransformer modelo;
            using (var stream = new FileStream(caminhoModelo, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                modelo = mlContext.Model.Load(stream, out var modeloSchema);
            }

            var engine = mlContext.Model.CreatePredictionEngine<DadosRecomendacao, RecomendacaoProduto>(modelo);
            var resultado = engine.Predict(new DadosRecomendacao { EnergyLevel = energyLevel, DeviceName = deviceName });

            Console.WriteLine(resultado);

            string jsonRecomendacao = JsonSerializer.Serialize(resultado, new JsonSerializerOptions
            {
                WriteIndented = true 
            });

            Console.WriteLine(jsonRecomendacao);

            return Ok(new
            {
                energyLevel,
                deviceName,
                recomendacao = GetStatusRecomendacao(resultado.PontuacaoRecomendacao)
            });
        }

        private void TreinarModelo()
        {
            var pastaModelo = Path.GetDirectoryName(caminhoModelo);
            if (!Directory.Exists(pastaModelo))
            {
                Directory.CreateDirectory(pastaModelo);
                Console.WriteLine($"Diretório criado: {pastaModelo}");
            }

            IDataView dadosTreinamento = mlContext.Data.LoadFromTextFile<DadosRecomendacao>(
                path: caminhoTreinamento, hasHeader: true, separatorChar: ',');

            var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: nameof(DadosRecomendacao.EnergyLevel)) // Label é EnergyLevel
                .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "DeviceNameEncoded", inputColumnName: nameof(DadosRecomendacao.DeviceName)))
                .Append(mlContext.Transforms.Concatenate("Features", "DeviceNameEncoded"))
                .Append(mlContext.Regression.Trainers.FastTree()); // Usando o modelo de regressão

            var dadosDivididos = mlContext.Data.TrainTestSplit(dadosTreinamento, testFraction: 0.2);
            var modelo = pipeline.Fit(dadosDivididos.TrainSet);

            var predicoes = modelo.Transform(dadosDivididos.TestSet);
            var metrics = mlContext.Regression.Evaluate(predicoes, labelColumnName: "Label", scoreColumnName: "Score");

            Console.WriteLine($"R²: {metrics.RSquared}");
            Console.WriteLine($"RMSE: {metrics.RootMeanSquaredError}");

            mlContext.Model.Save(modelo, dadosTreinamento.Schema, caminhoModelo);
            Console.WriteLine($"Modelo treinado e salvo em: {caminhoModelo}");
        }

        private string GetStatusRecomendacao(float pontuacao)
        {
            switch (Math.Round(pontuacao, 1))
            {
                case >= 4:
                    return "Altamente Recomendado";
                case >= 3:
                    return "Recomendado";
                default:
                    return "Não Recomendado";
            }
        }
    }
}
