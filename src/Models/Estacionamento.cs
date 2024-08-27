namespace Fundamentos.Models
{
    public class Veiculo
    {
        public string Placa { get; }
        public DateTime HoraEntrada { get; }

        public Veiculo(string placa, DateTime horaEntrada)
        {
            Placa = placa;
            HoraEntrada = horaEntrada;
        }
    }

    public class Estacionamento
    {
        public decimal PrecoInicial { get; }
        public decimal PrecoPorHora { get; }

        // Uso de HashSet para armazenar veículos
        private HashSet<Veiculo> veiculos = new HashSet<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            PrecoInicial = precoInicial;
            PrecoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Tente novamente.");
                return;
            }

            DateTime horaEntrada = DateTime.Now;
            Veiculo veiculo = new Veiculo(placa, horaEntrada);

            if (veiculos.Add(veiculo))
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

            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Tente novamente.");
                return;
            }

            Veiculo veiculoRemovido = veiculos.FirstOrDefault(v => v.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase));
            
            if (veiculoRemovido != null)
            {
                // Calcula o valor total
                TimeSpan tempoEstacionado = DateTime.Now - veiculoRemovido.HoraEntrada;
                int horas = (int)Math.Ceiling(tempoEstacionado.TotalHours);
                decimal valorTotal = PrecoInicial + PrecoPorHora * horas;

                veiculos.Remove(veiculoRemovido);
                Console.WriteLine($"O veículo {placa} foi removido. Tempo total de estacionamento: {horas} horas. Preço total: R$ {valorTotal:F2}");
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
                foreach (Veiculo veiculo in veiculos)
                {
                    Console.WriteLine($"{veiculo.Placa} - Entrada: {veiculo.HoraEntrada}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}