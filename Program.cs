using System;
using DIO.Series.Classes;
using DIO.Series.Enums;
using System.Collections.Generic;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InsereSerie();
                        break;
                    case "3":
                        AtualizaSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Opcao invalida");
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series");
            Console.WriteLine("Informe a opcao desejada: ");

            Console.WriteLine("1 - Listar series");
            Console.WriteLine("2 - Inserir nova serie");
            Console.WriteLine("3 - Atualizar serie");
            Console.WriteLine("4 - Excluir serie");
            Console.WriteLine("5 - Visualizar serie");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;
        }
        private static void VisualizarSerie()
        {
            Console.WriteLine("Visualizar serie");
            Console.Write("Informe o id da serie: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Serie serie = repositorio.RetornaPorId(id);
            Console.WriteLine(serie);
            Console.WriteLine();
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Excluir serie");
            Console.Write("Informe o id da serie: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Serie serie = repositorio.RetornaPorId(id);
            Console.WriteLine(serie);
            Console.WriteLine();

            repositorio.Exclui(id);
        }

        private static void AtualizaSerie()
        {
            Console.WriteLine("Atualizar serie");
            Console.Write("Informe o id da serie: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Serie serie = repositorio.RetornaPorId(id);
            Console.WriteLine(serie);
            Console.WriteLine();

            InsereSerie(id);
        }

        private static void InsereSerie(int id = -1)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o Genero entre as opcoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descricao da Serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(
                id: id == -1 ? repositorio.ProximoId() : id,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

            if (id == -1)
                repositorio.Insere(novaSerie);
            else
                repositorio.Atualiza(id, novaSerie);
            
            Console.WriteLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar series");

            List<Serie> listaSeries = repositorio.Lista();

            if (listaSeries.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada");
                return;
            }

            Console.WriteLine();
            foreach (Serie serie in listaSeries)
            {
                Console.WriteLine(serie);
            }
        }
    }
}
