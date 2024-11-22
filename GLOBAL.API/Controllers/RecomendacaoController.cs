using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace Ecommerce.Cliente.API.Controllers
{
    //Classe com a estrutura de treinamento e dados para  
    public class DadosRecomendacao
    {
        [LoadColumn(0)] public int Id { get; set; }
        [LoadColumn(1)] public float EnergyLevel { get; set; }
        [LoadColumn(2)] public string Device { get; set; }
    }

    //Classe que retorna as previsões de recomendação
    public class RecomendacaoProduto
    {
        [ColumnName("Score")]
        public float PontuacaoRecomendacao { get; set; }
        [ColumnName("Device")]
        public string Device { get; set; } = string.Empty;
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

        //Metodo para verificar se o produto é ou nao recomendado baseado na entrada de CPF e Produto
        [HttpGet("recomendar/{id}/{device}")]
        public IActionResult Recomendar(int id, string device)
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

            var engineRecomendacao = mlContext.Model.CreatePredictionEngine<DadosRecomendacao, RecomendacaoProduto>(modelo);

            var recomendacao = engineRecomendacao.Predict(new DadosRecomendacao { 
                Id = id,
                Device = device
            });

            Console.WriteLine(recomendacao.PontuacaoRecomendacao);

            return Ok(new { 
                device = recomendacao.Device,
                recomendacao = GetStatusRecomendacao(recomendacao.PontuacaoRecomendacao)
            });
        }


        //Metodo para treinar o modelo que será utilizado para prever se o produto é ou não recomendado
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

            var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: nameof(DadosRecomendacao.EnergyLevel))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "IdCodificado", inputColumnName: nameof(DadosRecomendacao.Id)))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "DeviceCodificado", inputColumnName: nameof(DadosRecomendacao.Device)))
                .Append(mlContext.Transforms.Concatenate("Features", "IdCodificado", "DeviceCodificado"))
                .Append(mlContext.Regression.Trainers.FastTree());

            var modelo = pipeline.Fit(dadosTreinamento);

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

