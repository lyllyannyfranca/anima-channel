using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anima_channel
{
    public class Filme : EntidadeBase
    {
        private TimeSpan Duracao { get; set; }

        public Filme(int id, Genero genero, Classificacao_Etaria faixaEtaria, string titulo, string descricao, int ano, string duracao)
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
            Duracao = TimeSpan.Parse(duracao);
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

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + Genero + Environment.NewLine;
            retorno += "Classificação Etária: " + FaixaEtaria + Environment.NewLine;
            retorno += "Título: " + Titulo + Environment.NewLine;
            retorno += "Descrição: " + Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + Ano + Environment.NewLine;
            retorno += "Duração: " + Duracao.Hours + "h" + Duracao.Minutes + " min" + Environment.NewLine;
            retorno += "Excluído: " + Excluido;
            return retorno;
        }
    }
}
