using System.Collections;
using System.ComponentModel;

namespace ClubeDaLeitura.ModuloCaixas
{


    public class Caixa
    {
        static int ContadorDeCaixas = 1;
        public static ArrayList caixas = new ArrayList();

        public string cor = "";
        public string etiqueta;
        public int id;

        static public string MenuPrincipalCaixas()
        {
            Console.Clear();
            Console.WriteLine();

            Console.WriteLine("Caixas");
            Console.WriteLine();

            Console.WriteLine("[1] - Cadastrar Nova Caixa");

            Console.WriteLine("[2] - para Visulizar as Caixas");

            Console.WriteLine("[3] - para Editar as Caixas");

            Console.WriteLine("[4] - para Excluir as Caixas");
            Console.WriteLine();
            Console.WriteLine("Pressione s para sair");

            string opcao = Console.ReadLine().ToUpper();


            return opcao;
        }

        public static void CadastroDeCaixas(string opcaoCadastroCaixas)
        {
            if (opcaoCadastroCaixas == "1")
            {
                InserirNovaCaixa();
            }
            else if (opcaoCadastroCaixas == "2")
            {
                bool temCaixas = VisualizarCaixas(true);

                if (temCaixas)
                    Console.ReadLine();
            }
            else if (opcaoCadastroCaixas == "3")
            {
                EditarCaixas();
            }
            else if (opcaoCadastroCaixas == "4")
            {

                ExcluirCaixas();
            }
        }

        public static void InserirCaixas(int id, string tipoOperacao)
        {

            Console.Clear();
            Console.WriteLine("Digite a cor da caixa ");
            string cor = Console.ReadLine();

            Console.WriteLine("Digite a etiqueta da caixa");
            string etiqueta = Console.ReadLine();

            Console.WriteLine("Digite o número da caixa");
            id = int.Parse(Console.ReadLine());

            Caixa caixinha = new Caixa();
            caixinha.cor = cor;
            caixinha.etiqueta = etiqueta;
            caixinha.id = id;

            caixas.Add(caixinha);

            if (tipoOperacao == "INSERIR")
            {
               
                CaixaRepositorio.Inserir(caixinha);
            }

            else if (tipoOperacao == "EDITAR")
            {

                CaixaRepositorio.Editar(id , caixinha);
            }

            
        }

        public static bool VisualizarCaixas(bool v)
        {
            ArrayList caixas = CaixaRepositorio.SelecionarTodos();
            
            Console.ForegroundColor = ConsoleColor.Green;


            Console.WriteLine("{0,-10} | {1,-40} | {2,-30}", "ID", "Cor", "Etiqueta");

            Console.WriteLine("---------------------------------------------------------------------------------------");


            foreach (Caixa c in caixas)
            {
                Console.WriteLine("{0,-10} | {1,-40} | {2,-30}", c.id, c.cor, c.etiqueta);
            }

            Console.ResetColor();

            return true;
        }

        public static void ExcluirCaixas()
        {
            //Program.MostrarCabecalho("Cadastro de Equipamentos", "Excluindo Equipamento: ");

            bool temEquipamentosGravados = VisualizarCaixas(false);

            if (temEquipamentosGravados == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarCaixa();

            Caixa equipamento = SelecionarCaixaPorId(idSelecionado);

            caixas.Remove(equipamento);

            Program.ApresentarMensagem("Caixa excluída com sucesso!", ConsoleColor.Green);
        }

        public static int EncontrarCaixa()
        {
            int idSelecionado;
            bool idInvalido;

            do
            {
                Console.Write("Digite o Id da caixa: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = SelecionarCaixaPorId(idSelecionado) == null;

                if (idInvalido)
                    Program.ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red);

            } while (idInvalido);

            return idSelecionado;
        }

        public static Caixa SelecionarCaixaPorId(int id)
        {
            Caixa caixa = null;


            foreach (Caixa c in caixas)
            {
                if (c.id == id)
                {
                    caixa = c;
                    break;
                }
            }

            return caixa;

        }

        public static void EditarCaixas()
        {


            //Program.MostrarCabecalho("Cadastro de Equipamentos", "Editando Equipamento: ");

            bool temEquipamentos = VisualizarCaixas(false);

            if (temEquipamentos == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarCaixa();

            InserirCaixas(idSelecionado, "EDITAR");

            Program.ApresentarMensagem("Equipamento editado com sucesso!", ConsoleColor.Green);


        }

        static void InserirNovaCaixa()
        {
            //Program.MostrarCabecalho("");

            InserirCaixas(ContadorDeCaixas, "INSERIR");

            IncrementarIdCaixa();

            //Program.ApresentarMensagem("Caixa inserida com sucesso!", ConsoleColor.Green);
        }

        private static void IncrementarIdCaixa()
        {
            ContadorDeCaixas++;
        }
    }
}
