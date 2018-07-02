using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarinaSthefaneFernandes
{
    public class MostrarLoja
    {
        public IList<Sapato> ObterSapatos()
        {
            BancoDeDadosSapato_1708275 ctx = new BancoDeDadosSapato_1708275();
            return ctx.Sapatos.ToList();
        }
        public IList<PessoaFisica> ObterPessoaFisica()
        {
            BancoDeDadosSapato_1708275 ctx = new BancoDeDadosSapato_1708275();
            return ctx.PessoaFisicas.ToList();
        }
        public IList<PessoaJuridica> ObterPessoaJuridica()
        {
            BancoDeDadosSapato_1708275 ctx = new BancoDeDadosSapato_1708275();
            return ctx.PessoaJuridicas.ToList();
        }
        public IList<Venda> ObterVenda()
        {
            BancoDeDadosSapato_1708275 ctx = new BancoDeDadosSapato_1708275();
            return ctx.Vendas.ToList();
        }
    }
}
