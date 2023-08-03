using Alura.ByteBank.Infraestrutura.Testes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class PixRepositorio:IPixRepositorio
    {
        
        public List<PixDTO> Pixs { get; set; }

        public PixRepositorio()
        {
            this.Pixs = new List<PixDTO>()
            {
                new PixDTO(){Chave = new Guid("a0b80d53-c0dd-4897-ab90-c0615ad80d5a"),Saldo=10},
                new PixDTO(){Chave = new Guid("f6555014-4fed-4631-b6da-ad524288457a"),Saldo=236},
                new PixDTO(){Chave = new Guid("992f3fb4-07f5-46d7-aa75-fdd97faee6b2"),Saldo=95},
                new PixDTO(){Chave = new Guid("83eb9c17-aaf8-4958-b4ce-76cd484e8c46"),Saldo=14},
                new PixDTO(){Chave = new Guid("32f75378-9db9-4890-b6c8-17c08891b9c2"),Saldo=189.87},
                new PixDTO(){Chave = new Guid("b13633a6-01ab-4f86-8b5f-e980994a2c80"),Saldo=5618.87},
                new PixDTO(){Chave = new Guid("c3aed3f9-380b-4305-9c79-f0a8c326007c"),Saldo=68},
                new PixDTO(){Chave = new Guid("54a02202-91ec-4be4-9772-8de0a5900868"),Saldo=195},
                new PixDTO(){Chave = new Guid("8d801594-e7d4-4916-9a38-c04ee15e7dd8"),Saldo=68},
                new PixDTO(){Chave = new Guid("0f63ff06-1e83-4086-aacb-72f17f572993"),Saldo=65719.82}
            };
        }

        public PixDTO consultaPix(Guid chave)
        {
            PixDTO dto = (from pix in this.Pixs
                          where pix.Chave == chave
                          select pix).SingleOrDefault();
            return dto;
        }

    }
}
