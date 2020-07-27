using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Entidades;
using DAO;
using System.Data;



namespace Crud
{
    static public class CRUD
    {
        static public void Inserir(Item item)
        {

            switch ((int)item.Tipo()) // pega o tipo de entidade que o metodo recebe
            {
                case 0:
                    RepositorioAccess.InsertItem(item as Estoque);
                    break;
                case 1:
                    RepositorioAccess.InsertItem(item as Registro);
                    break;
                    //default:
                    //    throw new Exception("Bussines.CRUD Entidade com tipação invalida")  ;
                    //    break;
            }
        }

        static public void Deletar(int id, string tabela)
        {
            RepositorioAccess.DeletItem(id, tabela);
        }

        static public void Alterar(Item item)
        {
            switch ((int)item.Tipo()) // pega o tipo de entidade que o metodo recebe
            {
                case 0:
                    RepositorioAccess.UpdateItem(item as Estoque);
                    break;
                case 1:
                    break;
                    //default:
                    //    throw new Exception("Bussines.CRUD Entidade com tipação invalida")  ;
                    //    break;
            }
        }
        static public DataTable Listar(string nome, string tabela)
        {
            if (nome == null)
            {
                return RepositorioAccess.SelectItem(tabela);
            }
            else
            {
                return RepositorioAccess.SelectItem(nome, tabela);
            }
        }
    }
}