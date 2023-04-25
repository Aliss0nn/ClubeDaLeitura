using ClubeDaLeitura.TelaCompartilhada;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloRevistas
{
    public class RepositorioRevista : Repositorio
    {
        //public ArrayList listaregistros = new ArrayList();
        //public int ContadorDeId = 1;

        //public void IncrementarID()
        //{
        //    ContadorDeId++;
        //}

        public Revista SelecionarRevistaPorId(int id)
        {
            Revista revista = null;


            foreach (Revista r in listaregistros)
            {
                if (r.id == id)
                {
                    revista = r;
                    break;
                }
            }

            return revista;
        }

        public void Editar(int id, Revista revistaAtualizada)

        {

            Revista revista = SelecionarRevistaPorId(id);
            revista.colecao = revistaAtualizada.colecao;
            revista.numerocolecao = revistaAtualizada.numerocolecao;
            revista.anoDaRevista = revistaAtualizada.anoDaRevista;
            revista.caixaGuardada = revistaAtualizada.caixaGuardada;
            revista.id = id;
        }

        public void Excluir(int idSelecionado)
        {
            Revista revista = SelecionarRevistaPorId(idSelecionado);
            listaregistros.Remove(revista);
        }

        //public void Inserir(Entidade registros)
        //{
        //    listaregistros.Add(registros);

        //    IncrementarID();
        //}

        public ArrayList Selecionartodos()
        {
            return listaregistros;
        }
    }
}
