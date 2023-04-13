
using System.Collections;
using System.Runtime.ConstrainedExecution;

namespace ClubeDaLeitura.ModuloCaixas
{
    internal class CaixaRepositorio
    {
        public static ArrayList caixas = new ArrayList();

        internal static void Editar(int id, Caixa caixaAtualizada)
        {
            Caixa caixa = SelecionarPorId(id);
            
            caixa.cor = caixaAtualizada.cor;
            caixa.etiqueta = caixaAtualizada.etiqueta;
            caixa.id = id;

        }

        public static void Inserir(Caixa caixinha)
        {
            caixas.Add(caixinha);
        }

        public static Caixa SelecionarPorId(int id)
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

        public static ArrayList SelecionarTodos()
        {
            return caixas;
        }
    }
}
