using System;
using Alura.ByteBank.Aplicacao.DTO;
using Alura.ByteBank.Apresentacao.Comandos;

namespace Alura.ByteBank.Apresentacao
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.BackgroundColor = ConsoleColor.DarkGreen;            
            //Console.ForegroundColor = ConsoleColor.Black;
            
            string opcao;
            do
            {
                Console.Clear();
                Console.WriteLine(MostrarCabecalho());
                Console.WriteLine(MostrarMenu());
                opcao = LerOpcaoMenu();
                ProcessarOpcaoMenu(opcao);
            } while (opcao!="4");
       }

        static string LerOpcaoMenu()
        {
            string opcao;
            Console.Write("Opção desejada: ");
            opcao = Console.ReadLine();
            return opcao;
        }

        static string MostrarMenu()
        {
            string menu = "   Escolha uma opção:\n\n" +
                            "   1 - Cadastrar Agência\n" +
                            "   2 - Cadastrar Conta Corrente\n" +
                            "   3 - Listar Contas Correntes\n" +                         
                            "   4 - Sair do Programa \n";
            return menu;
        }

        static string MostrarCabecalho()
        {
            return "[ CONTROLE DE CONTAS CORRENTES - BYTEBANK ]\n";
        }

        static void ProcessarOpcaoMenu(string opcao)
        {
            switch (opcao)
            {
                case "1":
                    CadastarAgencia();
                    break;
                case "2":
                    CadastarConta();
                    break;
                case "3":
                    ListarContas();
                    break;
                case "4":
                    Console.WriteLine("Obrigado por utilizar o programa.");
                    break;
                default:
                    Console.WriteLine("Opção de menu inválida!");
                    break;
            }
        }

        private static void ListarContas()
        {
            var comando = new ContaCorrenteComando();
            var contas = comando.ObterTodos();
            if (contas!=null)
            {
                foreach (var item in contas)
                {
                    Console.WriteLine("\n"+item.ToString());
                }
            }
            else
            {
               Console.WriteLine("A consulta não retornou dados.");
            }
            
            Console.ReadKey();
        }

        private static void CadastarConta()
        {
            var contaDTO = new ContaCorrenteDTO();
            var clienteDTO = new ClienteDTO();
            var agenciaDTO = new AgenciaDTO();
            var comando = new ContaCorrenteComando();
            var clienteComando = new ClienteComando();
            var agenciaComando = new AgenciaComando();
            char opcao;
            Console.Clear();
            Console.WriteLine("\n[CADASTRO DE CONTAS CORRENTES]");
            Console.Write("\nVocê deseja cadastrar um novo cliente? [s - sim ou n - não] ");
            opcao = Console.ReadLine()[0];
            if (opcao =='s')
            {
                Console.WriteLine("\n\n[CADASTRO DE CLIENTE]");
                Console.Write("Nome Cliente: ");
                clienteDTO.Nome = Console.ReadLine();
                Console.Write("Profissão Cliente: ");
                clienteDTO.Profissao = Console.ReadLine();
                Console.Write("CPF Cliente: ");
                clienteDTO.CPF = Console.ReadLine();                
                if(clienteComando.Adicionar(clienteDTO))
                {
                  Console.WriteLine("Cliente Cadastrada com sucesso!");
                  Console.ReadKey();
                }

                Console.Clear();
                Console.WriteLine("\n\n[CADASTRO DE CONTA]");
                Console.Write("Informe Saldo: ");
                contaDTO.Saldo = double.Parse(Console.ReadLine());
                Console.Write("Informe Numero Conta: ");
                contaDTO.Numero = int.Parse(Console.ReadLine());
                contaDTO.ClienteId = clienteComando.ObterPorGuid(clienteDTO.Identificador).Id;
                contaDTO.Cliente = clienteComando.ObterPorGuid(clienteDTO.Identificador);
                Console.Write("Informe Numero Agencia: ");
                contaDTO.AgenciaId = int.Parse(Console.ReadLine());
                contaDTO.Agencia = agenciaComando.ObterPorId(contaDTO.AgenciaId);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\n\n[CADASTRO DE CONTA]");
                Console.Write("Informe Saldo: ");
                contaDTO.Saldo = double.Parse(Console.ReadLine());
                Console.Write("Informe Numero Conta: ");
                contaDTO.Numero = int.Parse(Console.ReadLine());
                Console.Write("Informe Numero Cliente: ");
                contaDTO.ClienteId = int.Parse(Console.ReadLine());
                contaDTO.Cliente = clienteComando.ObterPorId(contaDTO.ClienteId);
                Console.Write("Informe Numero Agencia: ");
                contaDTO.AgenciaId = int.Parse(Console.ReadLine());
                contaDTO.Agencia = agenciaComando.ObterPorId(contaDTO.AgenciaId);

            }

            comando.Adicionar(contaDTO);          
            Console.WriteLine(contaDTO.ToString());
            Console.ReadKey();

        }

        private static void CadastarAgencia()
        {            
            var dto = new AgenciaDTO();
            var comando = new AgenciaComando();
            Console.Clear();
            Console.WriteLine("\n[CADASTRO DE AGÊNCIA]");
            Console.Write("Nome da Agência: ");
            dto.Nome = Console.ReadLine();
            Console.Write("Endereço da Agência: ");
            dto.Endereco = Console.ReadLine();
            Console.Write("Número da Agência: ");
            dto.Numero = int.Parse(Console.ReadLine());

            if (comando.Adicionar(dto))
            {
                Console.WriteLine("Agência Cadastrada com sucesso!\n");
                Console.WriteLine("\n\n===Dados da Agência===");
                string dados = $"Numero Agência: {dto.Numero}\n" +
                               $"Nome Agência {dto.Nome}\n" +
                               $"Endereço Agência {dto.Endereco}";
                Console.WriteLine(dados);
                Console.ReadKey();
            }


        }
    }
}
