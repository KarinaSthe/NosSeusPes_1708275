using KarinaSthefaneFernandes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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

namespace Interfacegrafica
{
    /// <summary>
    /// Lógica interna para GerenciarSapato.xaml
    /// </summary>
    public partial class GerenciarSapato : Window, INotifyPropertyChanged
    {

        BancoDeDadosSapato_1708275 ctx = new BancoDeDadosSapato_1708275();


        private Sapato _Sapato = new Sapato();
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
        public IList<Sapato> Sapatos { get; set; }
        public Boolean ModoCriacaoSapatos { get; set; } = false;
        public Visibility VisibilidadeDataGrid
        {
            get
            {
                if (ModoCriacaoSapatos)
                {
                    return Visibility.Hidden;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

       
        public GerenciarSapato()
        {
            InitializeComponent();
            this.DataContext = this;
            //ModelFutebol ctx = new ModelFutebol();
            //this.Times = ctx.Times;
            this.Sapatos = ctx.Sapatos.ToList(); 
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
            BancoDeDadosSapato_1708275 ctx = new BancoDeDadosSapato_1708275();
            if (ModoCriacaoSapatos)
            {
                ctx.Sapatos.Add(SapatoSelecionado);
                ctx.SaveChanges();
                this.Close();
            }
            else if (SapatoSelecionado != null && SapatoSelecionado.Id > 0)
            {
                Sapato ParaSalvar = ctx.Sapatos.Find(SapatoSelecionado.Id);
                ParaSalvar.Nome = SapatoSelecionado.Nome;
                ParaSalvar.Material = SapatoSelecionado.Material;
                ParaSalvar.Cadarco = SapatoSelecionado.Cadarco;
                ParaSalvar.Preco = SapatoSelecionado.Preco;
                ParaSalvar.Cor = SapatoSelecionado.Cor;
                ParaSalvar.Quantidade = SapatoSelecionado.Quantidade;
                ParaSalvar.Tamanho = SapatoSelecionado.Tamanho;
                //ctx.Entry(ParaSalvar).State = System.Data.Entity.EntityState.Added;
                ctx.SaveChanges();
                this.Close();
            }
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DeletarButton_Click(object sender, RoutedEventArgs e)
        {
           
    
            

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SapatoEDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Sapato item in e.RemovedItems)
            {
                ctx.Sapatos.Remove(item);
            }


            ctx.SaveChanges();
        }
        private void BtnSelecionarSapato_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Relatorio"; // Nome padrão
            dlg.Filter = "Imagens (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            Nullable<bool> result = dlg.ShowDialog();

            // Somente irá salvar se o usuário selecionar um arquivo.
            if (result == true)
            {
                var uri = new Uri(dlg.FileName);
                var imagemFile = File.Open(dlg.FileName, FileMode.Open);
                SapatoSelecionado.Foto = new byte[imagemFile.Length];
                imagemFile.Read(SapatoSelecionado.Foto,
                    0, (int)imagemFile.Length);
                NotifyPropertyChanged("Foto");
            }

        }
    }
}
