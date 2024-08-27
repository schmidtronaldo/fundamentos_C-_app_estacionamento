//using System;
//using System.Collections.Generic;
//using System.Linq;

namespace Fundamentos.Models
{
    public class Estacionamento
    {
        // Propriedades somente leitura para preços
        public decimal PrecoInicial { get; }
        public decimal PrecoPorHora { get; }

        // Uso de HashSet para evitar duplicatas e melhorar o desempenho
        private HashSet<string> veiculos = new HashSet<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            PrecoInicial = precoInicial;
            PrecoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine()?.Trim();

            // Verifica se a placa é válida
            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Tente novamente.");
                return;
            }

            if (veiculos.Add(placa))
            {
                Console.WriteLine($"Veículo {placa} adicionado com sucesso.");
            }
            else
            {
                Console.WriteLine($"Veículo {placa} já está estacionado.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine()?.Trim();

            // Verifica se a placa é válida
            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Tente novamente.");
                return;
            }

            if (veiculos.Contains(placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                if (int.TryParse(Console.ReadLine(), out int horas) && horas >= 0)
                {
                    decimal valorTotal = PrecoInicial + PrecoPorHora * horas;

                    veiculos.Remove(placa);
                    Console.WriteLine($"O veículo {placa} foi removido. Preço total: R$ {valorTotal:F2}");
                }
                else
                {
                    Console.WriteLine("Quantidade de horas inválida. Tente novamente.");
                }
            }
            else
            {
                Console.WriteLine("Veículo não encontrado. Verifique a placa e tente novamente.");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}