using System;
using Classes;
using Entidades;

namespace Entidades
{
    public abstract class Item
    {
        private int id;
        private string nome;
        private string disponivel;
        private string manutencao;
        private string observacao;
        private string data;
        private Numerais.Entidade tipo;

        public string Nome { get; set; }
        public int Id { get; set; }
        public string Disponivel { get; set; }
        public string Manutencao { get; set; }
        public string Observacao { get; set; }
        public string Data { get; set; }
        public Numerais.Entidade Tipo { get; set; }

    }
}
