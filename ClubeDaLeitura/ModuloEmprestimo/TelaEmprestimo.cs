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

        RepositorioAmigos repositorioAmigos;

        RepositorioRevista repositorioRevista;

        TelaRevista telarevista = new TelaRevista();

        public void AdicionarEmprestimo()
        {
            
            telaAmigos.VisualizarAmigos(true);

            Console.WriteLine("Digite o id do amigo");
            int id = int.Parse(Console.ReadLine());
           
            repositorioAmigos.SelecionarPorId(id);
           
            telarevista.VisualizarRevistas(true);

            Console.WriteLine("Digite o id da revista");
            id = int.Parse(Console.ReadLine());

            repositorioRevista.SelecionarRevistaPorId(id);

            Console.WriteLine("Digite a data do emprestimo");
            int dataDoEmprestimo = int.Parse(Console.ReadLine());

            Emprestimo emprestimo = new Emprestimo();




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






