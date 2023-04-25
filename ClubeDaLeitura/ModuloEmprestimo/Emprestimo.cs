using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloRevistas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace ClubeDaLeitura.ModuloEmprestimo
{
    public class Emprestimo : Amigos
    {
        public static ArrayList emprestimofeito = new ArrayList();
        public static ArrayList emprestimoAberto = new ArrayList();
        
        public Amigos amigo;
        public Revista revista;

        public DateTime dataDoEmprestimo;
        public DateTime dataDaDevolucao;
        public bool estaAberto;
    }
}
