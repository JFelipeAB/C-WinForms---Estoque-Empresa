using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAO
{
    public class RepositorioAccess
    {

        static public void InsertItem(Estoque item)
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
            string sql = $"insert into {item.Tipo()}(Nome, Disponivel, Manutencao, Loca, Data, Observacao) Values";
            sql += $"('{item.Nome}','{item.Disponivel}','{item.Manutencao}','{item.Local}','{item.Data}','{item.Observacao}')";// Disponivel, Manutencao, Local, Observacao) Values ";
            EscreveSql(sql);
        }


        static public void InsertItem(Registro item)
        {
            string sql = $"insert into {item.Tipo()}(Nome, Disponivel, Manutencao, Destino ,Data, Observacao) Values";
            sql += $"('{item.Nome}','{item.Disponivel}','{item.Manutencao}','{item.Destino}','{item.Data}','{item.Observacao}')";// Disponivel, Manutencao, Local, Observacao) Values ";
            EscreveSql(sql);
        }

        static public void DeletItem(int id, string tabela)
        {
            string sql = $"DELETE * FROM {tabela} WHERE Id = {id}";
            EscreveSql(sql);
        }

        static public void UpdateItem(Estoque item)
        {
            string sql = $"UPDATE {item.Tipo()} SET Nome = '{item.Nome}', Disponivel = '{item.Disponivel}', ";
            sql += $"Manutencao = '{item.Manutencao}', Loca = '{item.Local}', observacao = '{item.Observacao}' ";
            sql += $"WHERE Id = {item.Id}";
            EscreveSql(sql);
        }


        static public DataTable SelectItem(string item, string tabela)
        {
            using (OleDbConnection dataConnection = new OleDbConnection(RepositoriConfig.pathPadrao))
            {
                using (OleDbCommand dataCommand = dataConnection.CreateCommand())
                {
                    dataCommand.CommandText = $"SELECT * FROM {tabela} Where nome LIKE '%{item}%'";
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

        static public DataTable SelectItem(string tabela)
        {
            using (OleDbConnection dataConnection = new OleDbConnection(RepositoriConfig.pathPadrao))
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

        static public void EscreveSql(string sql)
        {
            using (OleDbConnection conn = new OleDbConnection(RepositoriConfig.pathPadrao))
            {
                using (OleDbCommand dataCommand = conn.CreateCommand())
                {
                    dataCommand.CommandText = sql;
                    conn.Open();
                    dataCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
