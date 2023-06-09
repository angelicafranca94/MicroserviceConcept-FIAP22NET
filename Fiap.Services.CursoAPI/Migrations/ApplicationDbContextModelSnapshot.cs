﻿// <auto-generated />
using Fiap.Services.CursoAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fiap.Services.CursoAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fiap.Services.CursoAPI.Model.Curso", b =>
                {
                    b.Property<int>("CursoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CursoId"));

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagemURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.HasKey("CursoId");

                    b.ToTable("Cursos");

                    b.HasData(
                        new
                        {
                            CursoId = 1,
                            Categoria = "MBA",
                            Descricao = "Aprenda sobre a organização do projeto com Agile, compreenda a Lógica de Programação básica, codifique, realize a concepção das telas no Front-end, faça a conexão com <br/>banco de dados e Deploy.",
                            ImagemURL = "https://storagecursosfiap.blob.core.windows.net/fiap/mbafiap.png",
                            Nome = "MBA FIAP",
                            Preco = 2.5
                        },
                        new
                        {
                            CursoId = 2,
                            Categoria = "Online",
                            Descricao = "Neste curso, vamos conhecer esta gigante economia de perto, entender o contexto que possibilitou seus grandes avanços, conhecer seus modelos de negócios digitais e nos <br/>aprofundar no sistema de inovação que está transformando o cenário mundial. Em um misto de teoria e prática, também vamos aproximar estes aprendizados à realidade brasileira, estudando<br/> cases reais e discutindo aplicações nos negócios de cada aluno.",
                            ImagemURL = "https://storagecursosfiap.blob.core.windows.net/fiap/fiapcursos.png",
                            Nome = "Cursos Online",
                            Preco = 1.599
                        },
                        new
                        {
                            CursoId = 3,
                            Categoria = "Treinamento",
                            Descricao = "Neste curso, vamos conhecer esta gigante economia de perto, entender o contexto que possibilitou seus grandes avanços, conhecer seus modelos de negócios digitais e nos <br/>aprofundar no sistema de inovação que está transformando o cenário mundial. Em um misto de teoria e prática, também vamos aproximar estes aprendizados à realidade brasileira, estudando<br/> cases reais e discutindo aplicações nos negócios de cada aluno.",
                            ImagemURL = "https://storagecursosfiap.blob.core.windows.net/fiap/cursosgratuitos.png",
                            Nome = "Cursos gratuitos",
                            Preco = 0.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
