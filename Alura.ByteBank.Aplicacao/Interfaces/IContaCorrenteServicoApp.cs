using Alura.ByteBank.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.Aplicacao.Interfaces
{
    public interface IContaCorrenteServicoApp:IDisposable
    {
        public List<ContaCorrenteDTO> ObterTodos();
        public ContaCorrenteDTO ObterPorId(int id);
        public ContaCorrenteDTO ObterPorGuid(Guid guid);
        public bool Adicionar(ContaCorrenteDTO cliente);
        public bool Atualizar(int id, ContaCorrenteDTO cliente);
        public bool Excluir(int id);
    }
}
