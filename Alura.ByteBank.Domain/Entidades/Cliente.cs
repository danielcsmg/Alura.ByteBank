using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Alura.ByteBank.Dominio.Entidades
{
    
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        private string _cpf;
        public Guid Identificador { get; set; }

        [Required]
        [MinLength(11, ErrorMessage = "Campo deve ter no mínimo 11 caracteres.")]
        public string CPF
        {
            get
            {
                return _cpf;
            }
            set
            {
               
                if(this.ValidaCPF(value)==false)
                {
                    throw new FormatException("CPF inválido.");
                }
                _cpf = value;
            }
        }
        private string _nome;

        [Required]
        [MinLength(3, ErrorMessage = "Campo deve ter no mínimo 3 caracteres.")]
        public String Nome
        {
            get { return _nome; }
            set
            {
                if (value.Length < 3)
                {
                    throw new FormatException("Nome do titular deve possuir pelo menos 3 caractere.");
                }
                if (value==string.Empty)
                {
                    throw new FormatException("Nome do titular não pode ser vazio.");
                }
                _nome = value;
            }
        }
        public string Profissao { get; set; }
        public virtual ICollection<ContaCorrente> Contas { get; set; }
        public Cliente()
        {
            Contas = new Collection<ContaCorrente>();            
        }

        private bool ValidaCPF(string cpfParaValidacao)
        {           
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpfParaValidacao = cpfParaValidacao.Trim();
            cpfParaValidacao = cpfParaValidacao.Replace(".", "").Replace("-", "");
            if (cpfParaValidacao.Length != 11)
            {
                return false;
            }
            tempCpf = cpfParaValidacao.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            }
            resto = soma % 11;
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }
            resto = soma % 11;
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }
            digito = digito + resto.ToString();
            return cpfParaValidacao.EndsWith(digito);
            
        }
    }
}