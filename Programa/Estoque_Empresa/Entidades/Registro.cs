using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Registro : Item
    {
        private string destino;

        public string Destino { get; set; }

        public override Numerais.Entidade Tipo()
        {
            return Numerais.Entidade.Registro;
        }
    }
}
