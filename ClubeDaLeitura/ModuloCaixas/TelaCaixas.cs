using ClubeDaLeitura.TelaCompartilhada;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloCaixas
{
    public class TelaCaixas : Tela
    {
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

        static void InserirNovaCaixa()
        {
            Caixa novacaixa = ObterCaixa();
            CaixaRepositorio.Inserir(novacaixa);

            Tela.ApresentarMensagem("Caixa inserida com sucesso!", ConsoleColor.Green);
        }

        public static void EditarCaixas()
        {
            bool temEquipamentos = VisualizarCaixas(false);

            if (temEquipamentos == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarCaixa();

            Caixa caixaatualizada = ObterCaixa();

            CaixaRepositorio.Editar(idSelecionado, caixaatualizada);

            Tela.ApresentarMensagem("Equipamento editado com sucesso!", ConsoleColor.Green);

        }

        public static Caixa ObterCaixa()
        {
            Console.Clear();
            Console.WriteLine("Digite a cor da caixa ");
            string cor = Console.ReadLine();

            Console.WriteLine("Digite a etiqueta da caixa");
            string etiqueta = Console.ReadLine();

            Console.WriteLine("Digite o número da caixa");
            int id = int.Parse(Console.ReadLine());

            Caixa caixinha = new Caixa();
            caixinha.cor = cor;
            caixinha.etiqueta = etiqueta;
            caixinha.id = id;

            return caixinha;
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

            bool temEquipamentosGravados = VisualizarCaixas(false);

            if (temEquipamentosGravados == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarCaixa();

            CaixaRepositorio.Excluir(idSelecionado);

            Tela.ApresentarMensagem("Caixa excluída com sucesso!", ConsoleColor.Green);

        }

        public static int EncontrarCaixa()
        {
            int idSelecionado;
            bool idInvalido;

            do
            {
                Console.Write("Digite o Id da caixa: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = CaixaRepositorio.SelecionarPorId(idSelecionado) == null;

                if (idInvalido)
                    Tela.ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red);

            } while (idInvalido);

            return idSelecionado;
        }
    }
}
