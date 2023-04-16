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
        public int contadorAmigos = 1;

        public ArrayList amigos = new ArrayList();

        public Amigos SelecionarAmigoPorId(int id)
        {
            Amigos amigo = new Amigos();

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

        public void Editar(int id, Amigos amigosatualizado)
        {
            Amigos amigo = SelecionarAmigoPorId(id);
            amigo.nome = amigo.nome;
            amigo.nomedoResponsavel = amigosatualizado.nomedoResponsavel;
            amigo.telefone = amigosatualizado.telefone;
            amigo.endereco = amigosatualizado.endereco;
            amigo.id = id;
        }

        public void Inserir(Amigos amiguinhos)
        {
            amigos.Add(amiguinhos);

            IncrementarIdAmigo();
        }

        public ArrayList SelecionarTodos()
        {
            return amigos;
        }

        public void IncrementarIdAmigo()
        {
            contadorAmigos++;
        }

        public void Excluir(int idSelecionado)
        {
            Amigos amigo = SelecionarAmigoPorId(idSelecionado);
            amigos.Remove(amigo);
        }
    }
}
