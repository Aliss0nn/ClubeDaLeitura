using ClubeDaLeitura.TelaCompartilhada;
using System.Collections;

namespace ClubeDaLeitura.ModuloRevistas
{
    public class Revista : Entidade
    {
        public string colecao = "";

        public int numerocolecao;
        public int anoDaRevista;
        public string caixaGuardada;
        public int id;
        public bool estaAberto;

        public  ArrayList revistas = new ArrayList();


        public override void Atualizar(Entidade registroAtualizado)
        {
          


        }






    }
}
