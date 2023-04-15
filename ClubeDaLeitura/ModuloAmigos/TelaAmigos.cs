﻿using ClubeDaLeitura.TelaCompartilhada;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloAmigos
{
    public class TelaAmigos : Tela
    {
        internal static string ApresentarMenuDosAmigos()
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
       
        internal static void CadastroAmigos(string opcaoCadastroAmigos)
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
        
        private static Amigos ObterAmigos()
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

            Console.WriteLine("Digite o id para o seu amigo: ");
            int id = int.Parse(Console.ReadLine());

            Amigos amiguinhos = new Amigos();
            amiguinhos.nome = nome;
            amiguinhos.nomedoResponsavel = nomedoResponsavel;
            amiguinhos.telefone = telefone;
            amiguinhos.endereco = endereco;
            amiguinhos.id = id;

            return amiguinhos;
        }

        private static void EditarAmigos()
        {

            bool temEquipamentos = VisualizarAmigos(false);

            if (temEquipamentos == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarAmigo();

            Amigos amigoAtualizado = ObterAmigos();

            RepositorioAmigos.Editar(idSelecionado, amigoAtualizado);

            

            Tela.ApresentarMensagem("Equipamento editado com sucesso!", ConsoleColor.Green);


        }
      
        public static void InserirNovoAmigo()
        {
            

            Amigos novoamigo = ObterAmigos();
            RepositorioAmigos.Inserir(novoamigo);

            

            RepositorioAmigos.IncrementarIdAmigo();

            Tela.ApresentarMensagem("Caixa inserida com sucesso!", ConsoleColor.Green);
        }

        private static void ExcluirAmigos()
        {
            bool temAmigosGravados = VisualizarAmigos(false);

            if (temAmigosGravados == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarAmigo();

            RepositorioAmigos.Excluir(idSelecionado);

            Tela.ApresentarMensagem("Amigo excluído com sucesso!", ConsoleColor.Green);
        }

        public static int EncontrarAmigo()
        {

            int idSelecionado;
            bool idInvalido;

            do
            {
                Console.Write("Digite o Id do amigo: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = RepositorioAmigos.SelecionarAmigoPorId(idSelecionado) == null;

                if (idInvalido)
                    Tela.ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red);

            } while (idInvalido);

            return idSelecionado;


        }

        public static bool VisualizarAmigos(bool v)
        {
            ArrayList amigos = RepositorioAmigos.SelecionarTodos();

            Console.ForegroundColor = ConsoleColor.DarkYellow;


            Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-20}", "ID", "Nome", "Nome do Resposável", "Endereço");


            Console.WriteLine("----------------------------------------------------------------------------------------------------");


            foreach (Amigos a in amigos)
            {
                Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-20}", a.id, a.nome, a.nomedoResponsavel, a.endereco);
            }

            Console.ResetColor();

            return true;
        }
    }

}