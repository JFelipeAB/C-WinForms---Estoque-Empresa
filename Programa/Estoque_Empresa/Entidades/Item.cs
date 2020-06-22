using System;

namespace Entidades
{
    public abstract class Item
    {
        private int id;
        private string nome;
        private string disponivel;
        private string manutencao;
        private string local;
        private string data;

        public string Nome { get; set; }
        public int Id { get; set; }
        public string Disponivel { get; set; }
        public string Manutencao { get; set; }
        public string Local { get; set; }
        public string Data { get; set; }


    }
}
