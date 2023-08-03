using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.Aplicacao.DTO
{
    public class AgenciaDTO
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public String Nome { get; set; }
        public String Endereco { get; set; }
        public Guid Identificador { get; set; }

        public AgenciaDTO()
        {
            Identificador = Guid.NewGuid();
        }
    }
}
