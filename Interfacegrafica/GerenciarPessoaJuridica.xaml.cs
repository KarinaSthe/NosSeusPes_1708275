using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.ComponentModel;

using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using KarinaSthefaneFernandes;

namespace Interfacegrafica
{
    /// <summary>
    /// Lógica interna para GerenciarPessoaJuridica.xaml
    /// </summary>
    public partial class GerenciarPessoaJuridica : Window, INotifyPropertyChanged
    {
        BancoDeDadosSapato_1708275 ctx = new BancoDeDadosSapato_1708275();

        private PessoaJuridica _PessoaJuridica = new PessoaJuridica();



        public PessoaJuridica PessoaJuridicaSelecionado
        {
            get
            {
                return _PessoaJuridica;
            }
            set
            {
                _PessoaJuridica = value;
                this.NotifyPropertyChanged("PessoaJuridicaSelecionado");
            }
        }
        public IList<PessoaJuridica> PessoaJuridicas { get; set; }
        public Boolean ModoCriacaoPessoaJuridica { get; set; } = false;
        public Visibility VisibilidadeDataGrid
        {
            get
            {
                if (ModoCriacaoPessoaJuridica)
                {
                    return Visibility.Hidden;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

        public GerenciarPessoaJuridica()
        {
            InitializeComponent();
            this.DataContext = this;
            //ModelFutebol ctx = new ModelFutebol();
            //this.Times = ctx.Times;
            this.PessoaJuridicas = ctx.PessoaJuridicas.ToList();
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
            
            if (ModoCriacaoPessoaJuridica)
            {
                ctx.PessoaJuridicas.Add(PessoaJuridicaSelecionado);
                ctx.SaveChanges();
                this.Close();
            }
            else if (PessoaJuridicaSelecionado != null && PessoaJuridicaSelecionado.Id > 0)
            {
                PessoaJuridica ParaSalvar = ctx.PessoaJuridicas.Find(PessoaJuridicaSelecionado.Id);
                ParaSalvar.Nome = PessoaJuridicaSelecionado.Nome;
                ParaSalvar.CpfCnpj = PessoaJuridicaSelecionado.CpfCnpj;
                ParaSalvar.RazaoSocial = PessoaJuridicaSelecionado.RazaoSocial;
                ParaSalvar.Endereco = PessoaJuridicaSelecionado.Endereco;
                ctx.Entry(ParaSalvar).State = System.Data.Entity.EntityState.Added;
                ctx.SaveChanges();
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
        private void PJDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (PessoaJuridica item in e.RemovedItems)
            {
                ctx.PessoaJuridicas.Remove(item);
            }


            ctx.SaveChanges();
        }
    }
}
