using KarinaSthefaneFernandes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Interfacegrafica
{
    /// <summary>
    /// Lógica interna para PesquisarEstoque.xaml
    /// </summary>
    public partial class PesquisarEstoque : Window, INotifyPropertyChanged
    {
        BancoDeDadosSapato_1708275 ctx = new BancoDeDadosSapato_1708275();

        public String Pesquisa { get; set; }

    private Sapato _Sapato = new Sapato();
        private string _Busca;
        public string  Busca {
            get
            {
                return _Busca;
            }
            set
            {
                _Busca = value;
                this.NotifyPropertyChanged("Busca");
            }
        }
        public Sapato SapatoSelecionado
        {
            get
            {
                return _Sapato;
            }
            set
            {
                _Sapato = value;
                this.NotifyPropertyChanged("SapatoSelecionado");
            }
        }
        private IList<Sapato> _Sapatos;
        public IList<Sapato> Sapatos {
            get
            {
                return _Sapatos;
            }
            set
            {
                _Sapatos = value;
                this.NotifyPropertyChanged("Sapatos");
            }
        }
       
        public PesquisarEstoque()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Sapatos = ctx.Sapatos.ToList();
            this.Sapatos = (new MostrarLoja()).ObterSapatos();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string Property)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
            }
        }
        private void ButtonPesquisa_Click(object sender, RoutedEventArgs e)
        {
            BancoDeDadosSapato_1708275 ctx = new BancoDeDadosSapato_1708275();
            this.Sapatos = ctx.Sapatos.Where(Sapato => Sapato.Nome.Contains(Busca)).ToList();
            //Sapato sapatos = (from j in ctx.Sapatos
                               //where j.Nome == Pesquisa select j).SingleOrDefault();

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
    }
}
