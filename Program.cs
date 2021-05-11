using System;

namespace anima_channel
{
    class Program
    {
        static Menu menu = new Menu();

        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                try
                {
                    switch (opcaoUsuario)
                    {
                        case "1":
                            Listar();
                            break;
                        case "2":
                            Inserir();
                            break;
                        case "3":
                            Atualizar();
                            break;
                        case "4":
                            Excluir();
                            break;
                        case "5":
                            Visualizar();
                            break;
                        case "C":
                            Console.Clear();
                            break;

                        default:
                            throw new ArgumentOutOfRangeException(nameof(opcaoUsuario), String.Format("{0} é uma opção inválida!", opcaoUsuario));
                    }
                }
                catch(ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message + Environment.NewLine);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message + Environment.NewLine);
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigada por utilizar o Anima Channel!");
            Console.WriteLine("Até breve! :D");
        }

        private static string ObterOpcaoUsuario()
        {
            menu.DesenharLogo();

            Console.WriteLine();
            Console.WriteLine("Anima Channel - O canal onde a animação é sem limites!" + Environment.NewLine);
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar atrações disponíveis");
            Console.WriteLine("2 - Inserir nova atração");
            Console.WriteLine("3 - Atualizar uma atração");
            Console.WriteLine("4 - Excluir uma atração");
            Console.WriteLine("5 - Visualizar atrações");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void Listar()
        {
            Console.WriteLine("Listar atrações disponíveis");

            Console.Write("Deseja visualizar filmes ou séries disponíveis?" + Environment.NewLine + "Digite F - Filmes / S - Séries: ");
            string entradaEscolha = Console.ReadLine().ToUpper();

            Console.WriteLine();

            switch(entradaEscolha)
            {
                case "F":
                    menu.ListarFilme();
                    break;
                case "S":
                    menu.ListarSerie();
                    break;

                default:
                    throw new ArgumentException("É necessário digitar F ou S para selecionar um Filme ou uma Série!");
            }

        }

        private static void Inserir()
        {
            Console.WriteLine("Inserir nova atração");

            Console.Write("Que tipo de atração gostaria de inserir?" + Environment.NewLine + "Digite F - Filme / S - Série: ");
            string entradaResposta = Console.ReadLine().ToUpper();

            switch(entradaResposta)
            {
                case "F":
                    menu.InserirFilme();
                    Console.WriteLine("Filme inserido com sucesso!");
                    break;
                case "S":
                    menu.InserirSerie();
                    Console.WriteLine("Série inserida com sucesso!");
                    break;

                default:
                    throw new ArgumentException("É necessário digitar F ou S para selecionar um Filme ou uma Série!");
            }

        }

        private static void Atualizar()
        {
            Console.WriteLine("Atualizar uma atração");

            Console.Write("Que tipo de atração gostaria de atualizar?" + Environment.NewLine + "Digite F - Filme / S - Série: ");
            string entradaResposta = Console.ReadLine().ToUpper();

            switch(entradaResposta)
            {
                case "F":
                    menu.AtualizarFilme();
                    Console.WriteLine("Dados do filme atualizados com sucesso!");
                    break;
                case "S":
                    menu.AtualizarSerie();
                    Console.WriteLine("Dados da série atualizados com sucesso!");
                    break;

                default:
                    throw new ArgumentException("É necessário digitar F ou S para selecionar um Filme ou uma Série!");
            }

        }

        private static void Excluir()
        {
            Console.WriteLine("Excluir uma atração");

            Console.WriteLine("Que tipo de atração deseja excluir?" + Environment.NewLine + "Digite F - Filme / S - Série: ");
            string entradaResposta = Console.ReadLine().ToUpper();

            switch(entradaResposta)
            {
                case "F":
                    menu.ExcluirFilme();
                    break;
                case "S":
                    menu.ExcluirSerie();
                    break;

                default:
                    throw new ArgumentException("É necessário digitar F ou S para selecionar um Filme ou uma Série!");
            }

        }

        private static void Visualizar()
        {
            Console.WriteLine("Deseja visualizar Filmes ou Séries?" + Environment.NewLine + "Digite F - Filmes / S - Séries: ");
            string entradaResposta = Console.ReadLine().ToUpper();

            switch(entradaResposta)
            {
                case "F":
                    menu.VisualizarFilme();
                    break;
                case "S":
                    menu.VisualizarSerie();
                    break;

                default:
                    throw new ArgumentException("É necessário digitar F ou S para selecionar um Filme ou uma Série!");
            }

        }
    }
}
