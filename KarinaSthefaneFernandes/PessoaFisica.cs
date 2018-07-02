using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarinaSthefaneFernandes
{
    public class PessoaFisica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime Dt_Nascimeto { get; set; }


        public virtual ICollection<Venda> Vendas { get; set; }
       = new List<Venda>();
    }
}
