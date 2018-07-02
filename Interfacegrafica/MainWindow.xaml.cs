using KarinaSthefaneFernandes;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Interfacegrafica
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender == MenuGerenciarSapato)
            {
                GerenciarSapato window = new GerenciarSapato();
                window.ShowDialog();
            }
            else if (sender == MenuNovoSapato)
            {
                GerenciarSapato window = new GerenciarSapato();
                window.ModoCriacaoSapatos = true;
                window.ShowDialog();
            }
            else if (sender == MenuGerenciarPessoaFisica)
            {
                GerenciarPessoa window = new GerenciarPessoa();
                window.ShowDialog();
            }
            else if (sender == MenuNovoPessoaFisica)
            {
                GerenciarPessoa window = new GerenciarPessoa();
                window.ModoCriacaoPessoaFisica = true;
                window.ShowDialog();
            }
            else if (sender == MenuGerenciarPessoaJuridica)
            {
                GerenciarPessoaJuridica window = new GerenciarPessoaJuridica();
                window.ShowDialog();
            }
            else if (sender == MenuNovoPessoaJuridica)
            {
                GerenciarPessoaJuridica window = new GerenciarPessoaJuridica();
                window.ModoCriacaoPessoaJuridica = true;
                window.ShowDialog();
            }
            else if (sender == MenuGerenciarPesquisa)
            {
                PesquisarEstoque window = new PesquisarEstoque();
                window.ShowDialog();
            }
            else if (sender == MenuNovaVenda)
            {
                GerenciamentodeVenda window = new GerenciamentodeVenda();
                window.ModoCriacaoVenda = true;
                window.ShowDialog();
            }
            else if (sender == MenuGerenciarVenda)
            {
                GerenciamentodeVenda window = new GerenciamentodeVenda();
                window.ShowDialog();
            }
           
            else if (sender == Relatorio_Estoque)
            {
                BancoDeDadosSapato_1708275 ctx = new BancoDeDadosSapato_1708275();
               
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "Relatorio"; // Nome padrão
                dlg.DefaultExt = ".xlsx"; // Extensão do arquivo
                dlg.Filter = "Excel (.xlsx)|*.xlsx"; // Filtros
                Nullable<bool> result = dlg.ShowDialog();

                // Somente irá salvar se o usuário selecionar um arquivo.
                if (result == true)
                {
                    // Salvar Documento
                   
                    ServiceClosedXML.CriarPlanilhaSapatos(ctx.Sapatos.ToList(), dlg.FileName);
                }

            }

           
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
