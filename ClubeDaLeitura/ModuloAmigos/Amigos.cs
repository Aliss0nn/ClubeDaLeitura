using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ModuloAmigos;


namespace ClubeDaLeitura.ModuloAmigos
{

    internal class Amigos
    {

        static int contadorAmigos = 1;
        public static ArrayList amigos = new ArrayList();

        public string nome = "";
        public string nomedoResponsavel = "";
        public int telefone;
        public string endereco;
        public int id;
        internal bool emprestado;

        public static string ApresentarMenuDosAmigos()
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("Cadastro De Amigos");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir um Novo Amigo");

            Console.WriteLine("Digite 2 para Visulizar Amigos");

            Console.WriteLine("Digite 3 para Editar Amigos");

            Console.WriteLine("Digite 4 para Excluir Amigos");

            Console.WriteLine();

            Console.WriteLine("Digite s para voltar para o menu principal");

            string opcao = Console.ReadLine();

            return opcao;
        }
        public static void CadastroAmigos(string opcaoCadastroAmigos)
        {
            if (opcaoCadastroAmigos == "1")
            {
                InserirNovoAmigo();
            }
            else if (opcaoCadastroAmigos == "2")
            {
                bool temCaixas = VisualizarAmigos(true);

                if (temCaixas)
                    Console.ReadLine();
            }
            else if (opcaoCadastroAmigos == "3")
            {
                EditarAmigos();
            }
            else if (opcaoCadastroAmigos == "4")
            {

                ExcluirAmigos();
            }
        }

        private static void InserirAmigo(string tipoOperacao, int id)
        {
            Console.Clear();
            Console.WriteLine("Digite o nome ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o nome do responsável");
            string nomedoResponsavel = Console.ReadLine();

            Console.WriteLine("Digite o número de telefone");
            int telefone = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o Endereço");
            string endereco = Console.ReadLine();

            if (tipoOperacao == "INSERIR")

            {
                Amigos amiguinhos = new Amigos();
                amiguinhos.nome = nome;
                amiguinhos.nomedoResponsavel = nomedoResponsavel;
                amiguinhos.telefone = telefone;
                amiguinhos.endereco = endereco;
                amiguinhos.id = id;

                amigos.Add(amiguinhos);
            }


            else if (tipoOperacao == "EDITAR")
            {
                Amigos amigo = SelecionarAmigoPorId(id);
                amigo.nome = nome;
                amigo.nomedoResponsavel = nomedoResponsavel;
                amigo.telefone = telefone;
                amigo.endereco = endereco;
                amigo.id = id;


            }
        }

        public static Amigos SelecionarAmigoPorId(int id)
        {
            Amigos amigo = null;

            foreach (Amigos a in amigos)
            {
                if (a.id == id)
                {
                    amigo = a;
                    break;
                }
            }

            return amigo;
        }

        public static bool VisualizarAmigos(bool v)
        {

            Console.ForegroundColor = ConsoleColor.DarkYellow;


            Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-20}", "ID", "Nome", "Nome do Resposável", "Telefone");


            Console.WriteLine("---------------------------------------------------------------------------------------");


            foreach (Amigos a in amigos)
            {
                Console.WriteLine("{0,-10} | {1,-40} | {2,-30}", a.id, a.nome, a.nomedoResponsavel, a.telefone);
            }

            Console.ResetColor();

            return true;
        }

        private static void EditarAmigos()
        {

            bool temEquipamentos = VisualizarAmigos(false);

            if (temEquipamentos == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarAmigo();

            InserirAmigo("EDITAR", idSelecionado);

            Program.ApresentarMensagem("Equipamento editado com sucesso!", ConsoleColor.Green);


        }

        public static int EncontrarAmigo()
        {

            int idSelecionado;
            bool idInvalido;

            do
            {
                Console.Write("Digite o Id do amigo: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = SelecionarAmigoPorId(idSelecionado) == null;

                if (idInvalido)
                    Program.ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red);

            } while (idInvalido);

            return idSelecionado;


        }

        private static void ExcluirAmigos()
        {
            bool temAmigosGravados = VisualizarAmigos(false);

            if (temAmigosGravados == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarAmigo();

            Amigos amigo = SelecionarAmigoPorId(idSelecionado);

            amigos.Remove(amigo);

            Program.ApresentarMensagem("Amigo excluído com sucesso!", ConsoleColor.Green);


        }

        public static void InserirNovoAmigo()
        {
            //Program.MostrarCabecalho("");

            InserirAmigo("INSERIR", contadorAmigos);

            IncrementarIdAmigo();

            //Program.ApresentarMensagem("Caixa inserida com sucesso!", ConsoleColor.Green);
        }

        private static void IncrementarIdAmigo()
        {
            contadorAmigos++;
        }

        public static int ProcurarListaNomeAmigo(string nome, ArrayList array)
        {
            foreach (Amigos item in array)
            {


                if (item.nome == nome)
                {
                    int id = array.IndexOf(item);
                    return id;
                }
            }

            Console.WriteLine("Esse amigo nao foi cadastrado!");

            return 404;
        }

    }
}
