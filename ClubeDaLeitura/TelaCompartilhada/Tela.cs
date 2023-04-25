using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.TelaCompartilhada
{
    public class Tela : Repositorio
    {
        string nome = "";
        
        
        
        public static void ApresentarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.WriteLine();
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }

        public string MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine();

            Console.WriteLine($"{nome}");
            Console.WriteLine();

            Console.WriteLine($"[1] - Cadastrar Nova {nome}");

            Console.WriteLine($"[2] - para Visulizar as {nome}");

            Console.WriteLine($"[3] - para Editar as {nome}");

            Console.WriteLine($"[4] - para Excluir as {nome}");
            Console.WriteLine();
            Console.WriteLine("Pressione s para sair");

            string opcao = Console.ReadLine().ToUpper();


            return opcao;
        }







    }
    

}
