using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace DAO
{
    public class RepositoriConfig
    {
        
        static public string pathPadrao = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = \\192.168.0.85\Banco de Dados - Access\Estoque Informatica\Estoque_Empresa\Programa\Banco\Base.mdb";

        virtual public void Insert(EntidadeBase e)
        { 
        
        }
    }
}
