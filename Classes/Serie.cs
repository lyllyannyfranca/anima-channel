using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anima_channel
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id; //modificar depois para Id++
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }

        public string retornaTitulo()
        {
            return Titulo;
        }

        public bool retornaExcluido()
        {
            return Excluido;
        }

        internal int retornaId()
        {
            return Id;
        }

        public void Excluir()
        {
            Excluido = true;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + Genero + Environment.NewLine; //Environment.NewLine = Interpreta como um S.O representa uma quebra de linha.
            retorno += "Título: " + Titulo + Environment.NewLine;
            retorno += "Descrição: " + Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + Ano;
            return retorno;
        }

    }
}
