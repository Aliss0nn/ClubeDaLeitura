using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloCaixas;
using ClubeDaLeitura.ModuloRevistas;
using ClubeDaLeitura.TelaCompartilhada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloEmprestimo
{
    
    public class TelaEmprestimo : Emprestimo
    {
        TelaAmigos telaAmigos = new TelaAmigos();
        
        RepositorioAmigos repositorioAmigos = new RepositorioAmigos();

        RepositorioRevista repositorioRevista = new RepositorioRevista();

        TelaRevista telarevista = new TelaRevista();


        public void AdicionarEmprestimo()
        {
            Emprestimo emprestimo = new Emprestimo();

            telaAmigos.VisualizarAmigos(true);

            Console.WriteLine("Digite o id do amigo");
            int id = int.Parse(Console.ReadLine());
           
            emprestimo.amigo = (Amigos)repositorioAmigos.SelecionarAmigoPorId(id);
           
            telarevista.VisualizarRevistas(true);

            Console.WriteLine("Digite o id da revista");
            id = int.Parse(Console.ReadLine());

            emprestimo.revista = repositorioRevista.SelecionarRevistaPorId(id);
           
            
            if (amigo.emprestado == true)
            {
                Console.WriteLine("erro");
                return;
            }
            else
            {
                amigo.emprestado = true;
            }

             emprestimoAberto.Add(emprestimo);
             emprestimofeito.Add(emprestimo);
             emprestimo.id = emprestimoAberto.Count + 1;
             emprestimo.dataDoEmprestimo = DateTime.Today;


        }


       
        
           










    }







}






