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
using Classes;


namespace Crud
{
    static public class CRUD
    {
        static public void Inserir(Item item)
        {
                        
            switch ((int)item.Tipo)
            {
                case 1:
                    DAOs.RepositorioAccess.Insert(item as Estoque);
                    break;
                case 2:
                    DAOs.RepositorioAccess.Insert(item as Registro);
                    break;
                //default:
                //    throw new Exception("Bussines.CRUD Entidade com tipação invalida")  ;
                //    break;
            }
        }
       
        static public void Deletar( Item item )
        {

            RepositorioAccess.Delet(sql);
        }
        
        static public void Alterar(Item item)
        {

            RepositorioAccess.Update(sql);
        }
        static public void Listar(List<Item> itens)
        {

            RepositorioAccess.Select(sql);
        }
    }
}