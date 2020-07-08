using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace DAOs
{
    static public class Conexao
    {
                                                                                             
        static public string pathPadrao = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = \\servidor\operacional\TI\projetos\Estoque Informatica 1.2\Estoque_Empresa\Programa\Banco\Base.mdb";
        
        static OleDbConnection conn = new OleDbConnection();
        static string PathPadrao { get; }
        static string Conectado { get; }

        static public OleDbConnection Conn()
        {
            return conn;
        }
        static public void AtivarConexao()
        {
            Conectar(pathPadrao);
        }
        static public void AtivarConexao(string path)
        {
            Conectar(path);
        }

        static void Conectar(string path)
        {
            try
            {
                conn.Open();
            }
            catch
            {
            }
        }
        static public void DesativarConexao()
        {
            try
            {
                conn.Close();
            }
            catch
            {
            }
        }

    }
}