using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAOs
{
    static public class RepositorioAccess
    {

        static public void Insert(Estoque item)
        {

            string sql = "Insert Into Estoques(Nome, Disponivel, Manutencao, Local, Data, observacao) Values";
            sql += item.Nome + item.Disponivel + item.Manutencao + item.Local + item.Data + item.Observacao ;
            RepositorioAccess.Escreve(sql);
        }
        static public void Insert(Registro item)
        {

            string sql = "Insert Into Registros(Nome, Disponivel, Manutencao, Destino, Data, observacao) Values";
            sql += item.Nome + item.Disponivel + item.Manutencao + item.Destino + item.Data + item.Observacao;
            RepositorioAccess.Escreve(sql);
        }

        static public void Delet(int id, string tabela)
        {
            string sql = "";




            RepositorioAccess.Escreve(sql);
        }

        static public void Update(Estoque item)
        {
            string sql = "";


            RepositorioAccess.Escreve(sql);
        }
        static public void Update(Registro item)
        {
            string sql = "";


            RepositorioAccess.Escreve(sql);
        }



        static public List<Item> Select(string nome, string tabela)
        {
            List < Item > lista = new List<Item>();
            string sql = "";



            RepositorioAccess.Escreve(sql);
            return lista;
        }

        static private void Escreve(string text)
        {
            Conexao.AtivarConexao();
            OleDbCommand cmd = new OleDbCommand(text);
            Conexao.DesativarConexao();
        }
    }
}
