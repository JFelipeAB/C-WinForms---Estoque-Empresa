using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public abstract class Item : EntidadeBase
    {   
        private string nome;
        private string disponivel;
        private string manutencao;
        private string observacao;
        private string data;

        public string Nome { get; set; }
        public string Disponivel { get; set; }
        public string Manutencao { get; set; }
        public string Observacao { get; set; }
        public string Data { get; set; }
        public abstract Numerais.Entidade Tipo();
    }
}
