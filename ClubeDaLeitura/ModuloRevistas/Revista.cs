using System.Collections;

namespace ClubeDaLeitura.ModuloRevistas
{
    internal class Revista
    {
        static int contadorDeRevista = 1;

        public string colecao = "";

        public int numerocolecao;
        public int anoDaRevista;
        public string caixaGuardada;
        public int id;

        public static ArrayList revistas = new ArrayList();

        public static string ApresentarMenuRevista()
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

        public static void CadastroRevista(string opcaoCadastroRevista)
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

        public static void InserirRevistas(int id, string tipoOperacao)
        {

            Console.Clear();
            Console.WriteLine("Digite o tipo de coleção da revista");
            string colecao = Console.ReadLine();

            Console.WriteLine("Digite o número da revista");
            int numero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o ano da revista");
            int anoDaRevista = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite em qual caixa vai guardar a revista");
            string caixaGuardada = Console.ReadLine();

            if (tipoOperacao == "INSERIR")
            {
                Revista revistinha = new Revista();
                revistinha.colecao = colecao;
                revistinha.numerocolecao = numero;
                revistinha.anoDaRevista = anoDaRevista;
                revistinha.caixaGuardada = caixaGuardada;
                revistinha.id = id;

                revistas.Add(revistinha);
            }


            else if (tipoOperacao == "EDITAR")
            {
                Revista revista = SelecionarRevistaPorId(id);
                revista.colecao = colecao;
                revista.numerocolecao = numero;
                revista.anoDaRevista = anoDaRevista;
                revista.caixaGuardada = caixaGuardada;
                revista.id = id;

            }


        }

        private static Revista SelecionarRevistaPorId(int id)
        {
            Revista revista = null;


            foreach (Revista r in revistas)
            {
                if (r.id == id)
                {
                    revista = r;
                    break;
                }
            }

            return revista;
        }

        private static void InserirNovaRevista()
        {
            //Program.MostrarCabecalho("");

            InserirRevistas(contadorDeRevista, "INSERIR");

            IncrementarID();

            //Program.ApresentarMensagem("Caixa inserida com sucesso!", ConsoleColor.Green);
        }

        private static void ExcluirRevista()
        {
            bool temRevistasGravadas = VisualizarRevistas(false);

            if (temRevistasGravadas == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarRevista();

            Revista revista = SelecionarRevistaPorId(idSelecionado);

            revistas.Remove(revista);

            Program.ApresentarMensagem("Caixa excluída com sucesso!", ConsoleColor.Green);
        }

        public static int EncontrarRevista()
        {
            int idSelecionado;
            bool idInvalido;

            do
            {
                Console.Write("Digite o Id da revista: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = SelecionarRevistaPorId(idSelecionado) == null;

                if (idInvalido)
                    Program.ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red);

            } while (idInvalido);

            return idSelecionado;
        }

        private static void EditarRevistas()
        {
            bool TemCaixas = VisualizarRevistas(false);

            if (TemCaixas == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarRevista();

            InserirRevistas(idSelecionado, "EDITAR");

            Program.ApresentarMensagem("Revista editada com sucesso!", ConsoleColor.Green);
        }

        public static bool VisualizarRevistas(bool v)
        {
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

        private static void IncrementarID()
        {
            contadorDeRevista++;
        }
    }
}
