using Alura.ByteBank.Infraestrutura.Testes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public interface IPixRepositorio
    {
       public PixDTO consultaPix(Guid pix);
    }
}
