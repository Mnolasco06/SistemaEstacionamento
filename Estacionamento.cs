using System;
using System.Collections.Generic;

namespace SistemaEstacionamento
{
    class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        // Método responsável por adicionar uma placa de veículo na lista
        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            veiculos.Add(placa);
            Console.WriteLine($"Veículo {placa} cadastrado com sucesso!");
        }

        // Método responsável por remover um veículo e calcular o valor total a ser pago
        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo a ser removido:");
            string placa = Console.ReadLine();

            // Verifica se o veículo está na lista
            if (veiculos.Contains(placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = int.Parse(Console.ReadLine());
                decimal valorTotal = precoInicial + (precoPorHora * horas);

                veiculos.Remove(placa); // Remove o veículo da lista
                Console.WriteLine($"O veículo {placa} foi removido. Preço total: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Verifique se digitou a placa corretamente.");
            }
        }

        // Método responsável por listar todos os veículos estacionados
        public void ListarVeiculos()
        {
            if (veiculos.Count > 0)
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            decimal precoInicial = 0;
            decimal precoPorHora = 0;

            Console.WriteLine("Seja bem-vindo ao sistema de estacionamento!\nDigite o preço inicial:");
            precoInicial = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Agora digite o preço por hora:");
            precoPorHora = Convert.ToDecimal(Console.ReadLine());

            // Instancia a classe Estacionamento com os valores obtidos
            Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

            string opcao = string.Empty;
            bool exibirMenu = true;

            // Loop do menu
            while (exibirMenu)
            {
                Console.Clear();
                Console.WriteLine("Digite a sua opção:");
                Console.WriteLine("1 - Cadastrar veículo");
                Console.WriteLine("2 - Remover veículo");
                Console.WriteLine("3 - Listar veículos");
                Console.WriteLine("4 - Encerrar");

                switch (Console.ReadLine())
                {
                    case "1":
                        es.AdicionarVeiculo();
                        break;

                    case "2":
                        es.RemoverVeiculo();
                        break;

                    case "3":
                        es.ListarVeiculos();
                        break;

                    case "4":
                        exibirMenu = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }

                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadLine();
            }

            Console.WriteLine("O programa se encerrou");
        }
    }
}
