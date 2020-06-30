using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.IO;
using Crud;


namespace Estoque_Empresa
{
    public partial class TelaMenu : Form
    {
        public DataGridView gridLista;
        public List<Item> ListaTodosDados = new List<Item>();
        public Numerais.Entidade telaAtual = Numerais.Entidade.Estoque;
        public string TodosOsDados = "*";
        public TelaMenu()
        {
            InitializeComponent();
            MontaGrid(TodosOsDados);
        }

        private void BtnBuscar_Click_1(object sender, EventArgs e)
        {
            gridLista.Rows.Clear();
            CbAlterar.Items.Clear();
            string busca = txtBusca.Text.ToString().Trim().ToUpper();
            MontaGrid(busca);
        }

        private void BtnAtualizar_Click_1(object sender, EventArgs e)
        {           
                MontaGrid(TodosOsDados);
                LimpaCampos();           
        }

        private void BtnAlterar_Click_1(object sender, EventArgs e)
        {
            Estoque itemAlterado = new Estoque();
            itemAlterado.Id =Convert.ToInt32(txtID.Text.Trim());
            itemAlterado.Nome = CbAlterar.Text.Trim();
            itemAlterado.Disponivel = Nud1.Text.Trim();
            itemAlterado.Manutencao = Nud2.Text.Trim();
            itemAlterado.Local = txtLocalA.Text.Trim();
            itemAlterado.Observacao = txtFornecedor.Text.Trim();
            itemAlterado.Data = DateTime.Now.ToShortDateString();

            CRUD.Alterar(itemAlterado);            
            //Estoque itemAnterior = ExcluiItem(itemAlterado); // O Item retornado pelo metodo serve para atribuir o lacal do item automaticamenta, mais explicação a seguir

            //if (itemAnterior == null) //Se o item a ser excluido não for encontrado, ele retorna nulo
            //{
            //    return;                   pra ve se esta saindo ou chegando itens
            //}

            //ListaTodosDados.Add(itemAlterado);
            //SalvaLista();
            //int qtdAntes = Convert.ToInt32(itemAnterior.Disponivel);
            //int qtdDepois = Convert.ToInt32(itemAlterado.Disponivel);
            //int qtdMaAntes = Convert.ToInt32(itemAnterior.Manutencao);
            //int qtdMaDepois = Convert.ToInt32(itemAlterado.Manutencao);
            //if (qtdDepois < qtdAntes)
            //{
            //    itemAlterado.Disponivel = (qtdAntes - qtdDepois).ToString();
            //    itemAlterado.Manutencao = "0";
            //    GeraRegistro(itemAlterado);
            //}
            //if (qtdMaDepois < qtdMaAntes)
            //{
            //    itemAlterado.Manutencao = (qtdMaAntes - qtdMaDepois).ToString();
            //    itemAlterado.Disponivel = "0";
            //    GeraRegistro(itemAlterado);
            //}
            //else
            //{
            //    MessageBox.Show("Ação concluida com sucesso ", "Ação concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //itemAlterado.Disponivel = qtdDepois.ToString();
            //itemAlterado.Manutencao = qtdMaDepois.ToString();            
            LimpaCampos();
            MontaGrid(TodosOsDados);
        }

        private void BtnExclui_Click_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text.Trim());
            //if (ExisteItem(id))//verifica primeiro se o item existe
            // {
            if (MessageBox.Show("Certeza que deseja exclui o Item?", "Confirmação", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    switch ((int)telaAtual) // pega a aba atual
                    {
                        case 0:
                            Estoque itemAlterado = new Estoque();
                            itemAlterado.Nome = CbAlterar.Text.Trim();
                            itemAlterado.Disponivel = Nud1.Text.Trim();
                            itemAlterado.Manutencao = Nud2.Text.Trim();
                            itemAlterado.Local = txtLocalA.Text.Trim();
                            itemAlterado.Observacao = txtFornecedor.Text.Trim();
                            itemAlterado.Data = DateTime.Now.ToShortDateString();
                            GeraRegistro(itemAlterado);
                            CRUD.Deletar(id, (string)telaAtual);
                            break;
                        case 1:
                        CRUD.Deletar(id, (string)telaAtual);
                        break;
                    }
                }
            //} 
            //else
            //    MessageBox.Show("Item não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("Ação concluida com sucesso ", "Ação concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {
            Estoque cadastra = new Estoque();
            cadastra.Nome = CbAlterar.Text.Trim();
            cadastra.Disponivel = Nud1.Text.Trim();
            cadastra.Manutencao = Nud2.Text.Trim();
            cadastra.Local = txtLocalA.Text.Trim();
            cadastra.Observacao = txtFornecedor.Text.Trim();
            cadastra.Data = DateTime.Now.ToShortDateString();
            CRUD.Inserir(cadastra);
            MontaGrid(TodosOsDados);
            LimpaCampos();
            MessageBox.Show("Cadastrado com sucesso", "Ação concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void estoqueToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if ((int)telaAtual != 0)
            {
                MontaTelaEstoque();
            }
        }

        private void registrosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if ((int)telaAtual != 1)
            {
                MontaTelaRegistro();
            }
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvLista.CurrentRow.Selected = true;
            CbAlterar.Text = dgvLista.CurrentRow.Cells[0].Value.ToString();
            Nud1.Text = dgvLista.CurrentRow.Cells[1].Value.ToString();
            Nud2.Text = dgvLista.CurrentRow.Cells[2].Value.ToString();
            txtLocalA.Text = dgvLista.CurrentRow.Cells[3].Value.ToString();
            txtFornecedor.Text = dgvLista.CurrentRow.Cells[5].Value.ToString();
        }

        public bool ExisteItem(int id)
        {

            return true;
        }

        public void MontaGrid(string NomeItem)
        {
            ListaTodosDados = CRUD.Listar(NomeItem, (string)telaAtual);
            gridLista = dgvLista;// Atribui o elemento da tela
            this.dgvLista.DefaultCellStyle.Font = new Font("Tahoma", 11);
            gridLista.Rows.Clear();
            gridLista.Columns.Clear();

            int pos = 0;
            bool ExisteItem = true;
            switch ((int)telaAtual) // pega a aba atual
            {
                case 0:
                    if (ListaTodosDados.Count == 0)
                        ExisteItem = false;
                    else
                    {
                        gridLista.Columns.Add("ID", "ID");
                        gridLista.Columns.Add("Item", "Item"); //nome das colunas
                        gridLista.Columns.Add("Disponivel", "Disponivel");
                        gridLista.Columns.Add("Manutenção", "Manutenção");
                        gridLista.Columns.Add("Local", "Local");
                        gridLista.Columns.Add("Data", "Data");
                        gridLista.Columns.Add("Observação", "Observação");

                        gridLista.Columns[0].Width = 20;
                        gridLista.Columns[1].Width = 200; //tamanho das colunas
                        gridLista.Columns[2].Width = 90;
                        gridLista.Columns[3].Width = 90;
                        gridLista.Columns[4].Width = 200;
                        gridLista.Columns[5].Width = 90;
                        foreach (Estoque a in ListaTodosDados)
                        {
                            gridLista.Rows.Add();
                            gridLista.Rows[pos].Cells[0].Value = a.Id;
                            gridLista.Rows[pos].Cells[1].Value = a.Nome;
                            gridLista.Rows[pos].Cells[2].Value = a.Disponivel;
                            gridLista.Rows[pos].Cells[3].Value = a.Manutencao;
                            gridLista.Rows[pos].Cells[4].Value = a.Local;
                            gridLista.Rows[pos].Cells[5].Value = a.Data;
                            gridLista.Rows[pos].Cells[6].Value = a.Observacao;
                            pos++;
                            CbAlterar.Items.Add(a.Nome);
                        }
                    }
                    break;
                case 1:
                    if (ListaTodosDados.Count == 0)
                        ExisteItem = false;
                    else
                    {
                        gridLista.Columns.Add("ID", "ID");
                        gridLista.Columns.Add("Item", "Item"); //nome das colunas
                        gridLista.Columns.Add("Disponivel", "Disponivel");
                        gridLista.Columns.Add("Manutenção", "Manutenção");
                        gridLista.Columns.Add("Destino", "Destino");
                        gridLista.Columns.Add("Data", "Data");
                        gridLista.Columns.Add("Observação", "Observação");

                        gridLista.Columns[0].Width = 20;
                        gridLista.Columns[1].Width = 200; //tamanho das colunas
                        gridLista.Columns[2].Width = 90;
                        gridLista.Columns[3].Width = 90;
                        gridLista.Columns[4].Width = 200;
                        gridLista.Columns[5].Width = 90;
                        foreach (Registro a in ListaTodosDados)
                        {
                            gridLista.Rows.Add();
                            gridLista.Rows[pos].Cells[0].Value = a.Id;
                            gridLista.Rows[pos].Cells[1].Value = a.Nome;
                            gridLista.Rows[pos].Cells[2].Value = a.Disponivel;
                            gridLista.Rows[pos].Cells[3].Value = a.Manutencao;
                            gridLista.Rows[pos].Cells[4].Value = a.Destino;
                            gridLista.Rows[pos].Cells[5].Value = a.Data;
                            gridLista.Rows[pos].Cells[6].Value = a.Observacao;
                            pos++;
                            CbAlterar.Items.Add(a.Nome);
                        }
                    }
                    break;
            }
            if (!ExisteItem)
            {
                MessageBox.Show("Nenhum item Encontrado", "Busca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
            }
        }                                       

        public void LimpaCampos()
        {
            CbAlterar.Text = "";
            txtBusca.Clear();
            txtLocalA.Clear();
            txtFornecedor.Clear();
            Nud1.Text = "0";
            Nud2.Text = "0";
            CbAlterar.Items.Clear();
        }

        public void GeraRegistro(Estoque i)
        {

            TelaConfirmacao form = new TelaConfirmacao(i);
            form.ShowDialog();
        }
        
        private void MontaTelaEstoque()
        {
            LabelTitulo.Text = "Estoque Informatica";
            label4.Text = "Local";
            btnCadastrar.Visible = true;
            BtnAlterar.Visible = true;
            telaAtual = (int)Numerais.Entidade.Estoque;
        }

        private void MontaTelaRegistro()
        {
            LabelTitulo.Text = "Registros Informatica";
            label4.Text = "Destino do Item";
            btnCadastrar.Visible = false;
            BtnAlterar.Visible = false;

            telaAtual = (int)Numerais.Entidade.Registro;
        }

        
    }
}
