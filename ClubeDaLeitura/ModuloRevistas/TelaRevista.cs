using ClubeDaLeitura.TelaCompartilhada;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloRevistas
{
    public class TelaRevista : Tela
    {
       RepositorioRevista repositorioRevista = new RepositorioRevista();
                
        public Revista ObterRevista()
        {
            Console.Clear();
            Console.Write("Digite o tipo de coleção da revista: ");
            string colecao = Console.ReadLine();

            Console.Write("\nDigite o número da revista: ");
            int numero = int.Parse(Console.ReadLine());

            Console.Write("\nDigite o ano da revista: ");
            int anoDaRevista = int.Parse(Console.ReadLine());

            Console.Write("\nDigite em qual caixa vai guardar a revista: ");
            string caixaGuardada = Console.ReadLine();

            Console.Write("\nQual o id da revista: ");
            int id = int.Parse(Console.ReadLine());

            Revista revistinha = new Revista();

            revistinha.colecao = colecao;
            revistinha.numerocolecao = numero;
            revistinha.anoDaRevista = anoDaRevista;
            revistinha.caixaGuardada = caixaGuardada;
            revistinha.id = id;

            return revistinha;

        }

        public string ApresentarMenuRevista()
        {
            Console.Clear();
            Console.WriteLine();

            Console.WriteLine("Revistas");
            Console.WriteLine();

            Console.WriteLine("[1] - Cadastrar Nova Revista");

            Console.WriteLine("[2] - para Visulizar as Revistas");

            Console.WriteLine("[3] - para Editar as Revistas");

            Console.WriteLine("[4] - para Excluir as Revistas");

            Console.WriteLine("Pressione s para sair");

            string opcao = Console.ReadLine().ToUpper();

            return opcao;

        }

        public void CadastroRevista(string opcaoCadastroRevista)
        {

            if (opcaoCadastroRevista == "1")
            {
                InserirNovaRevista();
            }
            else if (opcaoCadastroRevista == "2")
            {
                bool temRevistas = VisualizarRevistas(true);

                if (temRevistas)
                    Console.ReadLine();
            }
            else if (opcaoCadastroRevista == "3")
            {
                EditarRevistas();
            }
            else if (opcaoCadastroRevista == "4")
            {

                ExcluirRevista();
            }

        }

        public void InserirNovaRevista()
        {

            Revista revista = ObterRevista();
            repositorioRevista.Inserir(revista);

            repositorioRevista.IncrementarID();

            Tela.ApresentarMensagem("Revista inserida com sucesso!", ConsoleColor.Green);
        }
       
        private void ExcluirRevista()
        {
            bool temRevistasGravadas = VisualizarRevistas(false);

            if (temRevistasGravadas == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarRevista();

            repositorioRevista.Excluir(idSelecionado);

            Tela.ApresentarMensagem("Caixa excluída com sucesso!", ConsoleColor.Green);
        }

        public int EncontrarRevista()
        {
            int idSelecionado;
            bool idInvalido;

            do
            {
                Console.Write("Digite o Id da revista: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = repositorioRevista.SelecionarRevistaPorId(idSelecionado) == null;

                if (idInvalido)
                    Tela.ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red);

            } while (idInvalido);

            return idSelecionado;
        }

        private void EditarRevistas()
        {
            bool TemCaixas = VisualizarRevistas(false);

            if (TemCaixas == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarRevista();

            Revista revistaAtualizada = ObterRevista();
            repositorioRevista.Editar(idSelecionado, revistaAtualizada);

            Tela.ApresentarMensagem("Revista editada com sucesso!", ConsoleColor.Green);
        }

        public bool VisualizarRevistas(bool v)
        {

            ArrayList revistas = repositorioRevista.Selecionartodos();

            Console.ForegroundColor = ConsoleColor.DarkBlue;



            Console.WriteLine("{0,-10} | {1,-40} | {2,-30}", "ID", "Tipo", "Caixa Guardada");

            Console.WriteLine("---------------------------------------------------------------------------------------");


            foreach (Revista r in revistas)
            {
                Console.WriteLine("{0,-10} | {1,-40} | {2,-30}", r.id, r.colecao, r.caixaGuardada);
            }

            Console.ResetColor();

            return true;
        }

    }
}

        
        
    

