using Alura.ByteBank.Aplicacao.AplicacaoServico;
using Alura.ByteBank.Aplicacao.DTO;
using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Dominio.Interfaces.Servicos;
using Alura.ByteBank.Dominio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.Apresentacao.Comandos
{
    internal class ContaCorrenteComando
    {
        IContaCorrenteRepositorio _repositorio;
        IContaCorrenteServico _servico;
        IClienteServico _cliente;
        IAgenciaServico _agencia;
        ContaCorrenteServicoApp contaCorrenteServicoApp;
        public ContaCorrenteComando()
        {
            _repositorio = new ContaCorrenteRepositorio();
            _servico = new ContaCorrenteServico(_repositorio);
            contaCorrenteServicoApp = new ContaCorrenteServicoApp(_servico, _agencia, _cliente);
        }

        public bool Adicionar(ContaCorrenteDTO conta)
        {
            return contaCorrenteServicoApp.Adicionar(conta);
        }
        public bool Atualizar(int id, ContaCorrenteDTO conta)
        {
            return contaCorrenteServicoApp.Atualizar(id,conta);
        }

        public bool Excluir(int id)
        {
            return contaCorrenteServicoApp.Excluir(id);
        }

        public ContaCorrenteDTO ObterPorId(int id)
        {
            return contaCorrenteServicoApp.ObterPorId(id);
        }

        public List<ContaCorrenteDTO> ObterTodos()
        {
           return contaCorrenteServicoApp.ObterTodos();
        }

    }
}
