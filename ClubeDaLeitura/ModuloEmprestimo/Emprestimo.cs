using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloRevistas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace ClubeDaLeitura.ModuloEmprestimo
{
    internal class Emprestimo
    {
       
        public static ArrayList emprestimofeito = new ArrayList();
        public static ArrayList emprestimoAberto = new ArrayList();

        internal Amigos amigo;
        internal Revista revista;
        public DateTime dataDesaida;
        public DateTime dataDevolucao;
        public int id;


        public static void CadastrarEmprestimos()
        {
            int id;
            var emprestimo = new Emprestimo();
            Console.Clear();

            TelaAmigos.VisualizarAmigos(true);

            Console.WriteLine("Qual o id do amigo que sera emprestado a revista");
            id = int.Parse(Console.ReadLine());

            

            

            if (id == 404)
            {
                Console.WriteLine("Erro!");
                return;
            }

            emprestimo.amigo = new Amigos();
            Amigos amigo = new Amigos();

            if (amigo.emprestado == true)
            {
                //MostrarListaEmprestimos(emprestimpoFeitos);
                Console.WriteLine("\nEsse amigo ja tem uma revista emprestada!");
                Console.ReadLine();
                return;
            }
                Console.Clear();

            TelaRevista.VisualizarRevistas(true);

            Console.WriteLine("Qual o id da revista?");
            string nomeRevista = Console.ReadLine();

            int idRevista = TelaRevista.EncontrarRevista();

            if (idRevista == 404)
            {
                Console.WriteLine("Revista nao cadastrada!");
                return;
            }

            //Revista revista = Revista.revistas;
            
            //if ()
            //{
            //    Console.ForegroundColor = ConsoleColor.DarkRed;
            //    Program.ApresentarMensagem("Revista ja emprestada", ConsoleColor.DarkRed);
            //    Console.ReadLine();
            //    Console.ResetColor();
            //    return;
            //}

        }










    }
}
