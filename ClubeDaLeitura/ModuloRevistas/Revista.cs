using System.Collections;

namespace ClubeDaLeitura.ModuloRevistas
{
    public class Revista
    {
        public string colecao = "";

        public int numerocolecao;
        public int anoDaRevista;
        public string caixaGuardada;
        public int id;
        public bool estaAberto;

        public  ArrayList revistas = new ArrayList();    
    }
}
