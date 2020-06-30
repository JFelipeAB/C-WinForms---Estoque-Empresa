using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    class RepositorioTXTcs
    {
        //public void BuscarDados()
        //{
        //    TodosDados.Clear();
        //    using (StreamReader sr = new StreamReader("estoque.txt"))
        //    {
        //        string linha = string.Empty;
        //        int contador = 0;

        //        while ((linha = sr.ReadLine()) != null)
        //        {
        //            string[] split = new string[6];
        //            Estoque a = new Estoque();
        //            split = linha.Split('|');
        //            a.Nome = split[0];
        //            a.Disponivel = split[1];
        //            a.Manutencao = split[2];
        //            a.Local = split[3];
        //            a.Data = split[4];
        //            a.Observacao = split[5];

        //            TodosDados.Add(a);
        //            contador++;
        //        }
        //    }
        //    AtualizaGrid();
        //    }
        //public void SalvaLista()
        //{
        //    List<string> ListaTexo = new List<string>();
        //    foreach (Estoque b in TodosDados)
        //    {
        //        ListaTexo.Add(b.Nome + '|' + b.Disponivel + '|' + b.Manutencao + '|' + b.Local + '|' + b.Data + '|' + b.Observacao);
        //    }
        //    System.IO.File.WriteAllLines(@"estoque.txt", ListaTexo);
        //    AtualizaGrid();
        //}
        //public void SalvaLista()
        //{
        //    List<string> ListaTexo = new List<string>();
        //    foreach (Estoque b in ListaTodosDados)
        //    {
        //        ListaTexo.Add(b.Nome + '|' + b.Disponivel + '|' + b.Manutencao + '|' + b.Local + '|' + b.Data + '|' + b.Observacao);
        //    }
        //    System.IO.File.WriteAllLines(@"estoque.txt", ListaTexo);
        //    MontaGrid();
        //}
    }
}
