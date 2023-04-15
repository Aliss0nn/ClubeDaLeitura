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
        public static ArrayList amigos = new ArrayList();

        public string nome = "";
        public string nomedoResponsavel = "";
        public int telefone;
        public string endereco;
        public int id;
        public bool emprestado;
  
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
