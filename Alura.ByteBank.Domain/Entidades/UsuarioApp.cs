using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.Dominio.Entidades
{
    public class UsuarioApp
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }

        [EmailAddress]
        public string  Email { get; set; }
       
        public string Senha { get; set; }
    }
}
