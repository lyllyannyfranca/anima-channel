using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anima_channel
{
    public abstract class EntidadeBase
    {
        protected int Id { get; set; }
        protected Genero Genero { get; set; }
        protected Classificacao_Etaria FaixaEtaria { get; set; }
        protected string Titulo { get; set; }
        protected string Descricao { get; set; }
        protected int Ano { get; set; }
        protected bool Excluido { get; set; }

        public abstract string RetornaTitulo();

        public abstract bool RetornaExcluido();

        internal abstract int RetornaId();

        public abstract void Excluir();

    }
}
