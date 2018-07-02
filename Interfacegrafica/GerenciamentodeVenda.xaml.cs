using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using KarinaSthefaneFernandes;

namespace Interfacegrafica
{
    /// <summary>
    /// Lógica interna para GerenciamentodeVenda.xaml
    /// </summary>
    public partial class GerenciamentodeVenda : Window, INotifyPropertyChanged
    {
        BancoDeDadosSapato_1708275 ctx = new BancoDeDadosSapato_1708275();

        private Venda _Venda = new Venda();

        public Venda VendaSelecionada
        {
            get
            {
                return _Venda;
            }
            set
            {
                _Venda = value;
                

                this.NotifyPropertyChanged("VendaSelecionada");
            }
        }
        
        public IList<Venda> Vendas{ get; set; }
        public Boolean ModoCriacaoVenda { get; set; } = false;
        private ICollection<PessoaFisica> _PessoaFisicas;
        private ICollection<Sapato> _Sapatos;
        public Boolean ModoCriacaoJogador { get; set; } = false;

        public ICollection<PessoaFisica> PessoaFisicas
        {
            get => _PessoaFisicas; set
            {
                _PessoaFisicas = value;
                this.NotifyPropertyChanged("PessoaFisicas");
            }
        }
        public ICollection<Sapato> Sapatos
        {
            get => _Sapatos; set
            {
                _Sapatos = value;
                this.NotifyPropertyChanged("Sapatos");
            }
        }


        public Visibility VisibilidadeDataGrid
        {
            get
            {
                if (ModoCriacaoVenda)
                {
                    return Visibility.Hidden;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }
    
   
        public GerenciamentodeVenda()
        {
            InitializeComponent();

            this.PessoaFisicas = ctx.PessoaFisicas.ToList();
            //if (!ModoCriacaoVenda)
            //{
             // this.VendaSelecionada = this.Vendas.FirstOrDefault();
            //}
            this.Sapatos = ctx.Sapatos.ToList();
            this.DataContext = this;


            //ModelFutebol ctx = new ModelFutebol();
            //this.Times = ctx.Times;
            this.Vendas = ctx.Vendas.ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string Property)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {

            if (ModoCriacaoVenda) { 
                //if (this.VendaSelecionada.Id <= 0) {
                    {
                        ctx.Vendas.Add(this.VendaSelecionada);

                    }
                //}
            ctx.SaveChanges();
            MessageBox.Show("Venda Salva");
            this.Close();
        }
            else if (VendaSelecionada != null && VendaSelecionada.Id > 0)
            {
                Venda ParaSalvar = ctx.Vendas.Find(VendaSelecionada.Id);
                ParaSalvar.Cliente = VendaSelecionada.Cliente;
                ParaSalvar.Produto = VendaSelecionada.Produto;
                ParaSalvar.Quantidade = VendaSelecionada.Quantidade;
                ParaSalvar.ValorTotal = VendaSelecionada.ValorTotal;
                ParaSalvar.Sapatos = VendaSelecionada.Sapatos;
                ParaSalvar.PessoaFisicas = VendaSelecionada.PessoaFisicas;
                ctx.SaveChanges();
                MessageBox.Show("Venda Atualizada");
                this.Close();
            }
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void VendaDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Venda item in e.RemovedItems)
            {
                ctx.Vendas.Remove(item);
            }
        }
    }

        
    }

