using System;
using System.Collections.Generic;
using System.Data;
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

            //OleDbConnection conn = new OleDbConnection(Conexao.pathPadrao);     PARAMITERSS
            //conn.Open();


            //string sql = "INSERT INTO Estoque (nome, Disponivel, Manutencao, Local, Data, Observacao) VALUES(@nome, @Disponivel, @Manutencao, @Local, @Data, @Observacao)";

            //OleDbCommand cmd = new OleDbCommand(sql, conn);

            //cmd.Parameters.AddWithValue("@nome", item.Nome);
            //cmd.Parameters.AddWithValue("@Disponivel", item.Disponivel);
            //cmd.Parameters.AddWithValue("@Manutencao", item.Manutencao);
            //cmd.Parameters.AddWithValue("@Local", item.Local);
            //cmd.Parameters.AddWithValue("@Data", oleDbType.Date).Value = item.Data.ToString());
            //cmd.Parameters.AddWithValue("@Observacao", item.Observacao);
            //cmd.ExecuteNonQuery();
            //conn.Close();

            OleDbConnection conn = new OleDbConnection(Conexao.pathPadrao);
            

            string sql = "INSERT into Estoque ( nome, Disponivel, Manutencao, Local, Data, Observacao) Values ";
            //sql += $"('{item.Nome}' , {item.Disponivel} , {item.Manutencao}, '{item.Local}' , #{item.Data}# , '{item.Observacao}')";
            sql += $"('teste' , 1 , 1, 'localteste' , #'26/07/2020'# , 'Observacao')";
            OleDbCommand cmd = new OleDbCommand(sql);
            cmd.Connection = conn;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();


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



        static public DataTable Select(string nome, string tabela)
        {
            //define a string de conexao com provedor caminho e nome do banco de dados
            string strProvider = Conexao.pathPadrao; //"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\\dados\\Cadastro.mdb";
            //define a instrução SQL
            string strSql = $"SELECT {nome} FROM {tabela}";

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strProvider);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSql, con);

            //abre a conexao
            con.Open();

            //define o tipo do comando
            cmd.CommandType = CommandType.Text;
            //cria um dataadapter
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            DataTable dados = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(dados);
            return dados;
        }

        static private void Escreve(string text)
        {
            Conexao.AtivarConexao();
            OleDbCommand cmd = new OleDbCommand(text);
            cmd.ExecuteNonQuery();
            Conexao.DesativarConexao();
        }
    }
}
