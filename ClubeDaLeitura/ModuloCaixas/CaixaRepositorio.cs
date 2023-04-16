using System.Collections;
using System.Runtime.ConstrainedExecution;

namespace ClubeDaLeitura.ModuloCaixas
{
    internal class CaixaRepositorio 
    {
        public int ContadorDeCaixas = 1;

        public ArrayList caixas = new ArrayList();

        public void Editar(int id, Caixa caixaAtualizada)
        {
            Caixa caixa = SelecionarPorId(id);

            caixa.cor = caixaAtualizada.cor;
            caixa.etiqueta = caixaAtualizada.etiqueta;
            caixa.id = id;

        }

        public void Inserir(Caixa caixinha)
        {
            caixas.Add(caixinha);

            IncrementarIdCaixa();
        }

        public Caixa SelecionarPorId(int id)
        {
            Caixa caixa = null;


            foreach (Caixa c in caixas)
            {
                if (c.id == id)
                {
                    caixa = c;
                    break;
                }
            }

            return caixa;

        }

        public ArrayList SelecionarTodos()
        {
            return caixas;
        }

        public void Excluir(int idSelecionado)
        {
            Caixa caixinha = SelecionarPorId(idSelecionado);

            caixas.Remove(caixinha);
        }

        public void IncrementarIdCaixa()
        {
            ContadorDeCaixas++;
        }

    }
}

