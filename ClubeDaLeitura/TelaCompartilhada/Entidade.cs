using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.TelaCompartilhada
{
    public class Entidade
    {
        public int id;
        public string nome = "";
        public string nomedoResponsavel = "";
        public int telefone;
        public string endereco = "";

        public virtual void Atualizar(Entidade registroAtualizado)
        {
           
        }
    }
}
