using System;
using System.Data.Common;

namespace VO
{
    static public class Conexao
    {

        static string pathPadrao = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = \\192.168.0.1\operacional\TI\projetos\Estoque Informatica 1.1\Estoque_Empresa\Programa\Banco\Banco de dados.accdb";
        static bool conectado = false;
        static OleDbConnection conn = new OleDbConnection();
        static string PathPadrao { get; }
        static string Conectado { get; }

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
