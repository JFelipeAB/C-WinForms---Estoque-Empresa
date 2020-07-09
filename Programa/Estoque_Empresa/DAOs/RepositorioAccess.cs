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
            //OleDbConnection conn = new OleDbConnection(Conexao.pathPadrao); //PARAMITERSS
            //conn.Open();


            //string sql = "INSERT INTO Estoque (nome, disponivel, manutencao, local, Data, observacao) VALUES(@nome, @Disponivel, @Manutencao, @local,  @Data, @Observacao)";

            //OleDbCommand cmd = new OleDbCommand(sql, conn);

            //cmd.Parameters.AddWithValue("@nome", item.Nome);
            //cmd.Parameters.AddWithValue("@Disponivel", item.Disponivel);
            //cmd.Parameters.AddWithValue("@Manutencao", item.Manutencao);
            //cmd.Parameters.AddWithValue("@Local", item.Local);
            //cmd.Parameters.AddWithValue("@Data", item.Data);
            //cmd.Parameters.AddWithValue("@Observacao", item.Observacao);
            //cmd.ExecuteNonQuery();
            //conn.Close();

            OleDbConnection conn = new OleDbConnection(Conexao.pathPadrao);


            string sql = $"insert into Estoque(nome, disponivel, manutencao, local, Data, observacao) Values('{item.Nome}','{item.Disponivel}','{item.Manutencao}','{item.Local}','{item.Data}','{item.Observacao}')";// Disponivel, Manutencao, Local, Observacao) Values ";
            //sql += $"('{item.Nome}' , {item.Disponivel} , {item.Manutencao}, '{item.Local}' , #{item.Data}# , '{item.Observacao}')";
            //sql += $"('teste' , 1 , 1, 'localteste' , 'Observacao')"; //#'26/07/2020'# , 
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



        static public DataTable Select(string item, string tabela)
        {            
            using (OleDbConnection dataConnection = new OleDbConnection(Conexao.pathPadrao))
            {
                using (OleDbCommand dataCommand = dataConnection.CreateCommand())
                {
                    dataCommand.CommandText = $"SELECT * FROM {tabela} Where nome = {item}";
                    dataConnection.Open();
                    //dataCommand.Parameters.AddWithValue("@ID", ID);
                    DataTable dados = new DataTable();
                    OleDbDataAdapter adapter = new OleDbDataAdapter();
                    adapter.SelectCommand = dataCommand;
                    adapter.Fill(dados);
                    return dados;
                }
            }
        }

        static public DataTable Select(string tabela)
        {
            using (OleDbConnection dataConnection = new OleDbConnection(Conexao.pathPadrao))
            {
                using (OleDbCommand dataCommand = dataConnection.CreateCommand())
                {
                    dataCommand.CommandText = $"SELECT * FROM {tabela}";
                    dataConnection.Open();
                    //dataCommand.Parameters.AddWithValue("@ID", ID);
                    DataTable dados = new DataTable();
                    OleDbDataAdapter adapter = new OleDbDataAdapter();
                    adapter.SelectCommand = dataCommand;
                    adapter.Fill(dados);
                    return dados;                   
                }
            }
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
