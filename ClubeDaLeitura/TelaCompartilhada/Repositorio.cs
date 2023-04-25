using ClubeDaLeitura.ModuloCaixas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.TelaCompartilhada
{
    public class Repositorio
    {
        public int ContadorDeId = 1;

        public ArrayList listaregistros = new ArrayList();

        public void Inserir(Entidade registro)
        {
            listaregistros.Add(registro);

            IncrementarId();
        }

        public void IncrementarId()
        {
            ContadorDeId++;
        }

        public void Editar(int id, Entidade registroAtualizado)
        {
            Entidade registro = SelecionarPorId(id);

            registro.Atualizar(registroAtualizado);

        }

        public Entidade SelecionarPorId(int id)
        {
            Entidade registro = null;


            foreach (Entidade r in listaregistros)
            {
                if (r.id == id)
                {
                    registro = r;
                    break;
                }
            }

            return registro;

        }

        public ArrayList SelecionarTodos()
        {
            return listaregistros;
        }

        public void Excluir(int id)
        {
            Entidade registro = SelecionarPorId(id);

            listaregistros.Remove(registro);
        }

    }
}
