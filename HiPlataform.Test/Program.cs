namespace HiTest
{
    public class Program
    {
        public static void Main()
        {

            //Question 1
            Console.WriteLine(TheoricalQuestions.QuestionOne.QuestionOneLetterA());
            Console.WriteLine(TheoricalQuestions.QuestionOne.QuestionOneLetterB());

            //Question 2
            var firstItem = new SellItem("Rice", 10.0, 5.0, false, 0.1, 50);
            var secondItem = new SellItem("Beans", 20.0, 4.0, true, 0.2, 30);

            var stock = new Stock();
            stock.AddItem(firstItem);
            stock.AddItem(secondItem);

            stock.PriceCalculation();

            //Question 3
            List<House> houses = GetHouses(10);

            List<Street> streets = GetStreets(houses);

            foreach (var street in streets)
            {
                Console.WriteLine($"Rua: {street.Name}, Cep: {street.ZipCode}");
            }

            //Question 4
            Console.WriteLine(TheoricalQuestions.QuestionFour.QuestionFourLetterA());
            Console.WriteLine(TheoricalQuestions.QuestionFour.QuestionFourLetterB());
            Console.WriteLine(TheoricalQuestions.QuestionFour.QuestionFourLetterC());

            //Question 5
            Console.WriteLine(TheoricalQuestions.QuestionFive.QuestionFiveLetterA());


        }

        public static List<House> GetHouses(int count)
        {
            List<House> houses = new List<House>();
            Random random = new Random();

            for (var i = 0; i < count; i++)
            {
                var street = GenerateRandomStreet(random);
                var number = GenerateRandomNumber(random);
                var totalElectors = GenerateRandomElectors(random);

                houses.Add(new House(street, number, totalElectors));
            }

            return houses;
        }

        private static Street GenerateRandomStreet(Random random)
        {
            string cep = GenerateZipCodes(random);
            string nome = GenerateNumbers(random);
            return new Street(cep, nome);
        }

        private static string GenerateZipCodes(Random random)
        {
            int preNumber = random.Next(10000, 99999);
            int postNumber = random.Next(100, 999);
            return $"{preNumber}-{postNumber}";
        }

        private static string GenerateNumbers(Random random)
        {
            string[] streetNames = {
            "Rua Abacate", "Rua Banana", "Rua Carambola",
            "Rua Damasco", "Rua Elefante", "Rua Figo",
            "Rua Goiaba", "Rua Hipopotamo", "Rua Iguana",
            "Rua Jaca", "Rua Kakaroto", "Rua Laranja",
            "Rua Macarrao", "Rua Nicodemos", "Rua Orelha",
            "Rua Patati", "Rua Queue", "Rua Roraima",
            "Rua Salada", "Rua Tesouro", "Rua Ucla",
            "Rua Vigarista", "Rua Wilson", "Rua Xis",
            "Rua Yalala", "Rua Zenorio"};

            return streetNames[random.Next(streetNames.Length)];
        }

        private static int GenerateRandomNumber(Random random)
        {
            return random.Next(1, 1000);
        }

        private static int GenerateRandomElectors(Random random)
        {
            return random.Next(1, 1000);
        }

        public static List<Street> GetStreets(List<House> houses)
        {
            var dictonary = new Dictionary<Street, int>();

            foreach (var house in houses)
            {
                if (dictonary.ContainsKey(house.Street))
                {
                    dictonary[house.Street] += house.TotalElectors;
                }
                else
                {
                    dictonary[house.Street] = house.TotalElectors;
                }
            }

            var streets = dictonary.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();

            return streets;
        }
    }

    public class House
    {
        public House(Street street, int number, int totalElectors)
        {
            Street = street;
            Number = number;
            TotalElectors = totalElectors;
        }

        public Street Street { get; set; }
        public int Number { get; set; }
        public int TotalElectors { get; set; }
    }

    public class Street
    {
        public Street(string zipCode, string name)
        {
            ZipCode = zipCode;
            Name = name;
        }

        public string ZipCode { get; set; }
        public string Name { get; set; }
    }

    public class SellItem
    {
        public SellItem(string name, double acquisitionCost, double volume, bool refrigeration, double expirationRisk, int expireDate)
        {
            Name = name;
            AcquisitionCost = acquisitionCost;
            Volume = volume;
            Refrigeration = refrigeration;
            ExpirationRisk = expirationRisk;
            ExpireTax = expireDate;
        }

        public string Name { get; set; }
        public double AcquisitionCost { get; set; }
        public double Volume { get; set; }
        public bool Refrigeration { get; set; }
        public double ExpirationRisk { get; set; }
        public int ExpireTax { get; set; }

        public double TotalCostCalculation()
        {
            var totalCost = AcquisitionCost;
            totalCost += Volume * 0.1;

            if (Refrigeration)
            {
                totalCost += 2.0;
            }

            totalCost += ExpirationRisk * 5.0;
            return totalCost;
        }

        public double PriceCalculation()
        {
            return HiperMercado.Hi.MagicFormula(TotalCostCalculation(), ExpireTax);
        }
    }

    public class Stock
    {
        private List<SellItem> Items;

        public Stock()
        {
            this.Items = new List<SellItem>();
        }

        public void AddItem(SellItem item)
        {
            Items.Add(item);
        }

        public void PriceCalculation()
        {
            foreach (var item in Items)
            {
                var price = item.PriceCalculation();
                Console.WriteLine($"Item {item.Name}, price: R${price}");
            }
        }
    }

    public class HiperMercado
    {
        public static class Hi
        {
            public static double MagicFormula(double cost, int valid)
            {
                return cost * 1.2 + (valid / 2.0);
            }
        }
    }

    public class TheoricalQuestions
    {
        public static class QuestionOne
        {
            public static string QuestionOneLetterA()
            {
                return $"Podemos usar classes abstratas quando queremos compartilhar métodos, propriedades e comportamentos, como por exemplo numa classe abastrata Pagamento, onde algumas classe" +
                    $"de pagamento podem surgir a partir dela, como BoletoPagamento, CartaoDeCreditoPagamento, e ambas compartilharem propriedades, métodos e comportamentos, mas ao mesmo tempo ter conteudos exclusivos entre si." +
                    $"Já no caso de uma interface podemos usar para definir um contrato que não seja uma implementação concreta, o que o torna flexivel para ser adotado por classes diferentes. Por exemplo, ao criar uma interface Reposiory," +
                    $"podemos ter métodos de contrato padrões a serem implementados por classes diversas.";

            }

            public static string QuestionOneLetterB()
            {
                return $"Podemos usar classes abstratas quando queremos compartilhar métodos, propriedades e comportamentos, como por exemplo numa classe abastrata Pagamento, onde algumas classe" +
                    $"de pagamento podem surgir a partir dela, como BoletoPagamento, CartaoDeCreditoPagamento, e ambas compartilharem propriedades, métodos e comportamentos, mas ao mesmo tempo ter conteudos exclusivos entre si.";
            }
        }

        public static class QuestionFour
        {

            public static string QuestionFourLetterA()
            {
                return $"Eu acredito que sim. Para mim ajuda a organizar e demonstrar de forma clara qual foi o erro de validação de negócio que foi infringido.";

            }

            public static string QuestionFourLetterB()
            {
                return $"Quando tratamos de transações que precisam de uma resposta para seguir adiante. Por exemplo, um save de uma entidade no banco que posteriormente será usado " +
                    $"para outro save de outra entidade como FK no banco. Isso se caracteriza uma transação com dependencias, e para garantir que ela ocorra com 100% de sucesso, devemos cercar com um try-catch, " +
                    $"assim, caso ocorra algo de errado no primeiro save, garantimos que não chamaríamos o segundo save sem obter sucesso no primeiro.";
            }

            public static string QuestionFourLetterC()
            {
                return $"Em casos específicos que devemos interromper a execução do fluxo de negócio, pois ele precisa seguir uma linha de eventos e um deles dá um erro. Por exemplo," +
                    $"num fluxo de pagamento, precisamos primeiro verificar se o usuario/cliente tem saldo para pagamento, caso não encontramos esse saldo, podemos lançar uma exceção de domínio e" +
                    $" interromper o fluxo de execução do sistema.";
            }
        }

        public static class QuestionFive
        {

            public static string QuestionFiveLetterA()
            {
                return $"Acredito que em casos de uma volumetria muito alta de acessos, pode-se ocorrer alguma inconsistência com os dados dos clientes, o que podem ocasionar vários problemas." +
                    $"O ideal seria trabalhar com transações para que haja mais segurança nesses dados.";

            }

        }
    }
}
