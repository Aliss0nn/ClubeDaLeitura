using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloRevistas
{
    internal class RepositorioRevista
    {
        public static ArrayList revistas = new ArrayList();
        public static int contadorDeRevista = 1;
        
        public static void IncrementarID()
        {
            contadorDeRevista++;
        }

        public static Revista SelecionarRevistaPorId(int id)
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

        public static void Editar(int id, Revista revistaAtualizada)
            
        {
            
            Revista revista = SelecionarRevistaPorId(id);
            revista.colecao = revistaAtualizada.colecao;
            revista.numerocolecao = revistaAtualizada.numerocolecao;
            revista.anoDaRevista = revistaAtualizada.anoDaRevista ;
            revista.caixaGuardada = revistaAtualizada.caixaGuardada;
            revista.id = id;
        }

        public static void Excluir(int idSelecionado)
        {
            Revista revista = SelecionarRevistaPorId(idSelecionado);
            revistas.Remove(revista);
        }

        public static void Inserir(Revista revistinha)
        {
            revistas.Add(revistinha);

            IncrementarID();
        }

        public static ArrayList Selecionartodos()
        {
            return revistas;
        }
    }
}
