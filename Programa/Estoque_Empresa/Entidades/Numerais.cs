using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Numerais
    {
        public enum Tela
        {
            TelaEstoque = 0,
            TelaRegistro = 1
        }

        public enum Entidade
        {
            Estoque = 0,
            Registro = 1
        }
    }
}