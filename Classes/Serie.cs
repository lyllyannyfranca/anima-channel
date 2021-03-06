using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anima_channel
{
    public class Serie : EntidadeBase
    {
        private int QtdEpisodios { get; set; }

        public Serie(int id, Genero genero, Classificacao_Etaria faixaEtaria, string titulo, string descricao, int ano, int qtdEpisodios)
        {
            Id = id;

            if (Enum.IsDefined(typeof(Genero), genero) != true)
            {
                throw new ArgumentOutOfRangeException(nameof(genero), String.Format("{0} é uma opção inválida!", genero));
            }

            Genero = genero;

            if (Enum.IsDefined(typeof(Classificacao_Etaria), faixaEtaria) != true)
            {
                throw new ArgumentOutOfRangeException(nameof(faixaEtaria), String.Format("{0} é uma opção inválida!", faixaEtaria));
            }

            FaixaEtaria = faixaEtaria;

            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            QtdEpisodios = qtdEpisodios;
            Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + Genero + Environment.NewLine; //Environment.NewLine = Interpreta como um S.O representa uma quebra de linha.
            retorno += "Classificação Etária: " + FaixaEtaria + Environment.NewLine;
            retorno += "Título: " + Titulo + Environment.NewLine;
            retorno += "Descrição: " + Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + Ano + Environment.NewLine;
            retorno += "Quantidade de Episódios: " + QtdEpisodios + Environment.NewLine;
            retorno += "Excluído: " + Excluido;
            return retorno;
        }

        public override string RetornaTitulo()
        {
            return Titulo;
        }

        public override bool RetornaExcluido()
        {
            return Excluido;
        }

        internal override int RetornaId()
        {
            return Id;
        }

        public override void Excluir()
        {
            Excluido = true;
        }
    }
}
