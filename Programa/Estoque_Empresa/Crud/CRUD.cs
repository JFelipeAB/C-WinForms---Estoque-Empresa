using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Entidades;
using DAOs;
using System.Data;



namespace Crud
{
    static public class CRUD
    {
        static public void Inserir(Item item)
        {
                        
            switch ((int)item.Tipo) // pega o tipo de entidade que o metodo recebe
            {
                case 0:
                    RepositorioAccess.Insert(item as Estoque);
                    break;
                case 1:
                    RepositorioAccess.Insert(item as Registro);
                    break;
                //default:
                //    throw new Exception("Bussines.CRUD Entidade com tipação invalida")  ;
                //    break;
            }
        }
       
        static public void Deletar(int id, string tabela )
        {
            RepositorioAccess.Delet(id, tabela);                     
        }
        
        static public void Alterar(Item item)
        {
            switch ((int)item.Tipo) // pega o tipo de entidade que o metodo recebe
            {
                case 0:
                    RepositorioAccess.Update(item as Estoque);
                    break;
                case 1:
                    RepositorioAccess.Update(item as Registro);
                    break;
                    //default:
                    //    throw new Exception("Bussines.CRUD Entidade com tipação invalida")  ;
                    //    break;
            }            
        }
        static public DataTable Listar(string nome, string tabela)
            
        {
            return RepositorioAccess.Select(nome, tabela);
        }
    }
}