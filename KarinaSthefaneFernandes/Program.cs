using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarinaSthefaneFernandes
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<CadastroSapatos> cad_sapatos = new List<CadastroSapatos>();
            
            Console.WriteLine("           Seja Bem Vindo a loja de calçados NÃO SEI"); 
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Listar");
            var opcao = Console.ReadLine();
            //CadastroSapatos sapatos = new CadastroSapatos();


            switch (opcao)
            {
                case "1":
                    Console.WriteLine("1 - Cadastrar Sapato");
                    Console.WriteLine("2 - Cadastrar Cliente");
                    var op = Console.ReadLine();
                    switch (op)
                    {
                        case "1":
                            //CadastroSapatos.CadastrarSapatos();
                            break;
                        case "2":
                            //CadastroCliente.CadastrarCliente();
                            break;

                    }

                    break;
                case "2":
                    Console.WriteLine("1 - Listar Sapato");
                    var opc = Console.ReadLine();
                    switch (opc)
                    {
                        case "1":
                            //CadastroSapatos.ListarSapatos();
                            break;
                    }
                    
                    break;

            }
            

            Console.ReadKey();
        }
    }
}
