using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloRevistas
{
    public class RepositorioRevista
    {
        public ArrayList revistas = new ArrayList();
        public int contadorDeRevista = 1;
        
        public void IncrementarID()
        {
            contadorDeRevista++;
        }

        public Revista SelecionarRevistaPorId(int id)
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

        public void Editar(int id, Revista revistaAtualizada)
            
        {
            
            Revista revista = SelecionarRevistaPorId(id);
            revista.colecao = revistaAtualizada.colecao;
            revista.numerocolecao = revistaAtualizada.numerocolecao;
            revista.anoDaRevista = revistaAtualizada.anoDaRevista ;
            revista.caixaGuardada = revistaAtualizada.caixaGuardada;
            revista.id = id;
        }

        public void Excluir(int idSelecionado)
        {
            Revista revista = SelecionarRevistaPorId(idSelecionado);
            revistas.Remove(revista);
        }

        public void Inserir(Revista revistinha)
        {
            revistas.Add(revistinha);

            IncrementarID();
        }

        public ArrayList Selecionartodos()
        {
            return revistas;
        }
    }
}
