﻿// <auto-generated />
using System;
using GLOBAL.Data.AppData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace GLOBAL.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20241121051948_startDatabase")]
    partial class startDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GLOBAL.Domain.Entities.AddressEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("neighborhood");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("number");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("street");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("zipCode");

                    b.HasKey("Id");

                    b.ToTable("tb_user_address");
                });

            modelBuilder.Entity("GLOBAL.Domain.Entities.DeviceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DeviceInfoId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("deviceInfoId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("tb_device");
                });

            modelBuilder.Entity("GLOBAL.Domain.Entities.DeviceInfoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EnergyLevel")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("energyLevel");

                    b.Property<double>("voltage")
                        .HasColumnType("BINARY_DOUBLE")
                        .HasColumnName("voltage");

                    b.HasKey("Id");

                    b.ToTable("tb_device_info");
                });

            modelBuilder.Entity("GLOBAL.Domain.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("cpf");

                    b.Property<int?>("DeviceId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("deviceId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("email");

                    b.Property<int>("IsActive")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("isActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("password");

                    b.Property<int?>("UserGroupId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("userGroupId");

                    b.HasKey("Id");

                    b.ToTable("tb_user");
                });

            modelBuilder.Entity("GLOBAL.Domain.Entities.UserGroupEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IsActive")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("isActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("tb_user_group");
                });
#pragma warning restore 612, 618
        }
    }
}
