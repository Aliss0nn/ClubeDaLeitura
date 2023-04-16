
using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloCaixas;
using ClubeDaLeitura.ModuloEmprestimo;
//using ClubeDaLeitura.ModuloEmprestimo;
using ClubeDaLeitura.ModuloRevistas;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace ClubeDaLeitura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaAmigos telaAmigos = new TelaAmigos();
            TelaCaixas telaCaixas = new TelaCaixas();
            TelaRevista telaRevista = new TelaRevista();
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo();

            while (true)
            {
                Console.Clear();
                Console.WriteLine();

                Console.WriteLine("[1] - Menu das caixas");
                Console.WriteLine("[2] - Menu Amigos");
                Console.WriteLine("[3] - Menu Revistas");
                Console.WriteLine("[4] - Menu Emprestimos");
                Console.WriteLine();
                Console.WriteLine("Pressione s para sair");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        string opcaoCadastroCaixas = telaCaixas.MenuPrincipalCaixas();
                        //AdicionarCaixas(Caixa.caixas);
                        telaCaixas.CadastroDeCaixas(opcaoCadastroCaixas);
                        break;

                    case "2":
                        string opcaoCadastroAmigos = telaAmigos.ApresentarMenuDosAmigos();
                        //AdicionarAmigosAuto(Amigos.amigos);
                        telaAmigos.CadastroAmigos(opcaoCadastroAmigos);
                        break;

                    case "3":
                        string opcaoCadastroRevista = telaRevista.ApresentarMenuRevista();
                        telaRevista.CadastroRevista(opcaoCadastroRevista);
                        break;

                    case "4":
                        telaEmprestimo.AdicionarEmprestimo();
                        break;



                }
            }
        }
    }
}



            
           
             
    
    

