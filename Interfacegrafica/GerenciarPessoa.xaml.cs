using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
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
    /// Lógica interna para GerenciarPessoa.xaml
    /// </summary>
    public partial class GerenciarPessoa : Window, INotifyPropertyChanged
    {
        BancoDeDadosSapato_1708275 ctx = new BancoDeDadosSapato_1708275();
        private PessoaFisica  _PessoaFisica = new PessoaFisica();

        public PessoaFisica PessoaFisicaSelecionado
        {
            get
            {
                return _PessoaFisica;
            }
            set
            {
                _PessoaFisica = value;
                this.NotifyPropertyChanged("PessoaFisicaSelecionado");
            }
        }
        public IList<PessoaFisica> PessoaFisicas { get; set; }
        public Boolean ModoCriacaoPessoaFisica { get; set; } = false;
        public Visibility VisibilidadeDataGrid
        {
            get
            {
                if (ModoCriacaoPessoaFisica)
                {
                    return Visibility.Hidden;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }
        public GerenciarPessoa()
        {
            InitializeComponent();
            this.DataContext = this;
            //ModelFutebol ctx = new ModelFutebol();
            //this.Times = ctx.Times;
            this.PessoaFisicas = ctx.PessoaFisicas.ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string Property)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
            }
        }

        public DateTime Dt_Cadastro { get; set; } = new DateTime();
            private void OkButton_Click(object sender, RoutedEventArgs e)
        {
          
            if (ModoCriacaoPessoaFisica)
            {
                ctx.PessoaFisicas.Add(PessoaFisicaSelecionado);
                ctx.SaveChanges();
                this.Close();
            }
            else if (PessoaFisicaSelecionado != null && PessoaFisicaSelecionado.Id > 0)
            {
                PessoaFisica ParaSalvar = ctx.PessoaFisicas.Find(PessoaFisicaSelecionado.Id);
                ParaSalvar.Nome = PessoaFisicaSelecionado.Nome;
                ParaSalvar.Cpf = PessoaFisicaSelecionado.Cpf;
                ParaSalvar.Dt_Nascimeto = PessoaFisicaSelecionado.Dt_Nascimeto;
                ctx.Entry(ParaSalvar).State = System.Data.Entity.EntityState.Added;
                ctx.SaveChanges();
                this.Close();
            }
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void SapatoDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (PessoaFisica item in e.RemovedItems)
            {
                ctx.PessoaFisicas.Remove(item);
            }


            ctx.SaveChanges();
        }
    }
}
