using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloAmigos
{
    internal class RepositorioAmigos
    {
        public static int contadorAmigos = 1;

        public static ArrayList amigos = new ArrayList();

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

        public static void Editar(int id, Amigos amigosatualizado)
        {
            Amigos amigo = SelecionarAmigoPorId(id);
            amigo.nome = amigo.nome;
            amigo.nomedoResponsavel = amigosatualizado.nomedoResponsavel;
            amigo.telefone = amigosatualizado.telefone;
            amigo.endereco = amigosatualizado.endereco;
            amigo.id = id;
        }

        public static void Inserir(Amigos amiguinhos)
        {
            amigos.Add(amiguinhos);

            IncrementarIdAmigo();
        }

        public static ArrayList SelecionarTodos()
        {
            return amigos;
        }

        public static void IncrementarIdAmigo()
        {
            contadorAmigos++;
        }

        public static void Excluir(int idSelecionado)
        {
            Amigos amigo = SelecionarAmigoPorId(idSelecionado);
            amigos.Remove(amigo);
        }
    }
}
