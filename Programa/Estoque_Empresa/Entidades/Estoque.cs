using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Estoque : Item
    {

        private string local;

        public string Local { get; set; }
       
       public  Numerais.Entidade tipo = Numerais.Entidade.Estoque; 
       
    }
}
