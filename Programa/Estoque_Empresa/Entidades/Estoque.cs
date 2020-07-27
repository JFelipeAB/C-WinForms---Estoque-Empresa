using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Estoque : Item
    {
        private string local;

        public string Local { get; set; }

        public override Numerais.Entidade Tipo()
        {
            return Numerais.Entidade.Estoque;
        }
    }
}
