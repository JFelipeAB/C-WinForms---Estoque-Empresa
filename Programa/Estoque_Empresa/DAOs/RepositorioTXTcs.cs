using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    class RepositorioTXTcs
    {

        //rotina para inserir dados arquivo texto


        //List<Estoque> lista = new List<Estoque>();
        //using (StreamReader sr = new StreamReader("estoque.txt"))
        //{
        //    string linha = string.Empty;
        //    int contador = 0;

        //    while ((linha = sr.ReadLine()) != null)
        //    {
        //        string[] split = new string[6];
        //        Estoque c = new Estoque();
        //        split = linha.Split('|');
        //        c.Nome = split[0];
        //        c.Disponivel = split[1];
        //        c.Manutencao = split[2];
        //        c.Local = split[3];
        //        c.Data = split[4];
        //        c.Observacao = split[5];

        //        lista.Add(c);
        //        contador++;
        //    }
        //}
        //foreach (Estoque l in lista)
        //{
        //    CRUD.Inserir(l);
        //}

        //List<Registro> lista2 = new List<Registro>();
        //using (StreamReader sr = new StreamReader("registros.txt"))
        //{
        //    string linha = string.Empty;
        //    int contador = 0;

        //    while ((linha = sr.ReadLine()) != null)
        //    {
        //        if (linha == ""||contador == 17)
        //            break;
        //        string[] split = new string[6];
        //        Registro c = new Registro();
        //        split = linha.Split('|');
        //        c.Nome = split[0];
        //        c.Disponivel = split[1];
        //        c.Manutencao = split[2];                    
        //        c.Data = split[3];
        //        c.Observacao = split[4];
        //        c.Destino = split[5];

        //        lista2.Add(c);
        //        contador++;
        //    }
        //}

        //foreach (Registro l in lista2)
        //{
        //    CRUD.Inserir(l);
        //}







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
