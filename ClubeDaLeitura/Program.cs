
using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloCaixas;
using ClubeDaLeitura.ModuloEmprestimo;
using ClubeDaLeitura.ModuloRevistas;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace ClubeDaLeitura
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            Caixa caixa = new Caixa();
            Amigos amigos = new Amigos();
            Revista revista = new Revista();
            Emprestimo emprestimo = new Emprestimo();

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
                        string opcaoCadastroCaixas = TelaCaixas.MenuPrincipalCaixas();
                        //AdicionarCaixas(Caixa.caixas);
                        TelaCaixas.CadastroDeCaixas(opcaoCadastroCaixas);
                        break;

                    case "2":
                        string opcaoCadastroAmigos = TelaAmigos.ApresentarMenuDosAmigos();
                        //AdicionarAmigosAuto(Amigos.amigos);
                        TelaAmigos.CadastroAmigos(opcaoCadastroAmigos);
                        break;

                    case "3":
                        string opcaoCadastroRevista = TelaRevista.ApresentarMenuRevista();
                        TelaRevista.CadastroRevista(opcaoCadastroRevista);
                        break;

                    case "4":
                        Emprestimo.CadastrarEmprestimos();
                        break;
                }
            }
        }
       

        //    public static void AdicionarAmigosAuto(string "ArrayList AmigosAuto)

        //    {
        //        var amigo = new Amigos();

        //        amigo.nome = "Felipe";
        //        amigo.endereco = "R antonio silveira";
        //        amigo.telefone = 211312312;
        //        amigo.nomedoResponsavel = "pai dele";
        //        Amigos.amigos.Add(amigo);

        //        var amigo2 = new Amigos();

        //        amigo.nome = "Gustavo";
        //        amigo.endereco = "R teste silveira";
        //        amigo.telefone = 99912312;
        //        amigo.nomedoResponsavel = "lindoval";
        //        Amigos.amigos.Add(amigo);

        //        var amigo3 = new Amigos();

        //        amigo.nome = "leozin";
        //        amigo.endereco = "R teste do teste";
        //        amigo.telefone = 21983021;
        //        amigo.nomedoResponsavel = "marcia";
        //        Amigos.amigos.Add(amigo);

        //    }

        //    public static void AdicionarCaixas(ArrayList arraylist)
        //    {

        //        var caixa = new Caixa();

        //        caixa.id = 0;
        //        caixa.etiqueta = "Anime";
        //        caixa.cor = "azul";

        //        Caixa.caixas.Add(caixa);

        //        var caixa2 = new Caixa();

        //        caixa2.id = 1;
        //        caixa2.etiqueta = "Series";
        //        caixa2.cor = "amareloa";

        //        Caixa.caixas.Add(caixa2);


        //    }
    }
    //}
}
