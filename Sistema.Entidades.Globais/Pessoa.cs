using System;


namespace Sistema.Entidades.Globais
{
    public class Pessoa
    {
        public int Id;
        public string Nome;
        public string Cpf_Cnpj;
        public char TipoPessoa;
        public DateTime DataNascimento;


        public override string ToString()
        {
            return Id.ToString() + " - " + Nome + " - " + Cpf_Cnpj + " - " + DataNascimento.ToString();
        }
    }
}
