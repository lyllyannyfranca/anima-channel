using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anima_channel
{
    public class Menu
    {
        private SerieRepositorio RepositorioSerie { get; set; }
        private FilmeRepositorio RepositorioFilme { get; set; }

        public Menu()
        {
            RepositorioFilme = new FilmeRepositorio();
            RepositorioSerie = new SerieRepositorio();
        }

        // ---- Métodos auxiliares da Classe Menu ----

        private static void ListarGenero()
        {
            foreach (int genero in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", genero, Enum.GetName(typeof(Genero), genero));
            }
        }

        private static void ListarFaixaEtaria()
        {
            foreach (int faixaEtaria in Enum.GetValues(typeof(Classificacao_Etaria)))
            {
                Console.WriteLine("{0} - {1}", faixaEtaria, Enum.GetName(typeof(Classificacao_Etaria), faixaEtaria));
            }
        }

        public void DesenharLogo()
        {
            Console.WriteLine("\t\t" + "___");
            Console.WriteLine("\t" + "      =     =");
            Console.WriteLine("\t" + "     =  " + "^ ^" + "  =");
            Console.WriteLine("\t" + "     =  " + " - " + "  =");
            Console.WriteLine("\t" + "      = ___ =" + Environment.NewLine);
        }

        
        // ---- Métodos para Filmes ----


        public void ListarFilme()
        {
            var listaFilmes = RepositorioFilme.Listar();

            if (listaFilmes.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado." + Environment.NewLine);
                return;
            }

            foreach (var filme in listaFilmes)
            {
                var excluido = filme.RetornaExcluido();
                Console.WriteLine("#ID - {0}: - {1} {2}", filme.RetornaId(), filme.RetornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        public void InserirFilme()
        {
            ListarGenero();

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            ListarFaixaEtaria();

            Console.Write("Digite a classificação etária entre as opções acima: ");
            int entradaFaixaEtaria = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite a duração do Filme (HH:MM): ");
            string entradaDuracao = Console.ReadLine();

            Console.WriteLine();

            try
            {
                Filme novoFilme = new Filme(id: RepositorioFilme.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        faixaEtaria: (Classificacao_Etaria)entradaFaixaEtaria,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao,
                                        duracao: entradaDuracao);

                RepositorioFilme.Inserir(novoFilme);

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void AtualizarFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            ListarGenero();

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            ListarFaixaEtaria();

            Console.Write("Digite a classificação etária entre as opções acima: ");
            int entradaFaixaEtaria = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite a duração do Filme (HH:MM): ");
            string entradaDuracao = Console.ReadLine();

            Console.WriteLine();

            try
            {
                Filme atualizarFilme = new Filme(id: indiceFilme,
                                        genero: (Genero)entradaGenero,
                                        faixaEtaria: (Classificacao_Etaria)entradaFaixaEtaria,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao,
                                        duracao: entradaDuracao);

                RepositorioFilme.Atualizar(indiceFilme, atualizarFilme);

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

        } 

        public void ExcluirFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = RepositorioFilme.RetornarPorId(indiceFilme);

            Console.Write("Deseja realmente excluir o filme {0}?" + Environment.NewLine + "Digite S - Sim / N - Não", filme.RetornaTitulo());
            string resposta = Console.ReadLine();

            if (resposta == "N")
            {
                return;
            }

            RepositorioFilme.Excluir(indiceFilme);

            Console.WriteLine("Filme excluído com sucesso!");
        }

        public void VisualizarFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = RepositorioFilme.RetornarPorId(indiceFilme);

            Console.WriteLine(Environment.NewLine + filme);
        }


        // --- Métodos para Séries ----


        public void ListarSerie()
        {
            var listaSeries = RepositorioSerie.Listar();

            if (listaSeries.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in listaSeries)
            {
                var excluido = serie.RetornaExcluido();
                Console.WriteLine("#ID - {0}: - {1} {2}", serie.RetornaId(), serie.RetornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        public void InserirSerie()
        {
            ListarGenero();

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            ListarFaixaEtaria();

            Console.Write("Digite a classificação etária entre as opções acima: ");
            int entradaFaixaEtaria = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite a quantidade total de episódios da Série: ");
            int entradaQtdEpisodios = int.Parse(Console.ReadLine());

            Console.WriteLine();

            try
            {
                Serie novaSerie = new Serie(id: RepositorioSerie.ProximoId(),
                                                    genero: (Genero)entradaGenero,
                                                    faixaEtaria: (Classificacao_Etaria)entradaFaixaEtaria,
                                                    titulo: entradaTitulo,
                                                    ano: entradaAno,
                                                    descricao: entradaDescricao,
                                                    qtdEpisodios: entradaQtdEpisodios);

                RepositorioSerie.Inserir(novaSerie);

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            ListarGenero();

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            ListarFaixaEtaria();

            Console.Write("Digite a classificação etária entre as opções acima: ");
            int entradaFaixaEtaria = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite a quantidade total de episódios da Série: ");
            int entradaQtdEpisodios = int.Parse(Console.ReadLine());

            Console.WriteLine();

            try
            {
                Serie atualizarSerie = new Serie(id: indiceSerie,
                                                    genero: (Genero)entradaGenero,
                                                    faixaEtaria: (Classificacao_Etaria)entradaFaixaEtaria,
                                                    titulo: entradaTitulo,
                                                    ano: entradaAno,
                                                    descricao: entradaDescricao,
                                                    qtdEpisodios: entradaQtdEpisodios);

                RepositorioSerie.Atualizar(indiceSerie, atualizarSerie);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = RepositorioSerie.RetornarPorId(indiceSerie);

            Console.Write("Deseja realmente excluir a série - {0}? S - Sim / N - Não", serie.RetornaTitulo());
            string resposta = Console.ReadLine();

            if (resposta == "N")
            {
                return;
            }

            RepositorioSerie.Excluir(indiceSerie);

            Console.WriteLine("Série excluída com sucesso!");
        }

        public void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = RepositorioSerie.RetornarPorId(indiceSerie);

            Console.WriteLine(Environment.NewLine + serie);
        }
    }
}
