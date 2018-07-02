using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarinaSthefaneFernandes
{
    public class Venda
    {
        public override bool Equals(object obj)
        {
            if (obj is Venda)
            {
                return (this.Id == ((Venda)obj).Id);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public int ValorTotal { get; set; }
        public int Tamanho { get; set; }

        public PessoaFisica PessoaFisicas { get; set; }
        public Sapato Sapatos { get; set; }

        public Venda FirstOrDefault()
        {
            throw new NotImplementedException();
        }
    }
}
