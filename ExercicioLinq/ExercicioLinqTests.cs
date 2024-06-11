namespace ExercicioLinq
{
    public class ExercicioLinqTests
    {
        //Atribuí o readonly, sendo que não há manipulação de dados, apenas leitura
        private readonly List<Produto> produtos;

        public ExercicioLinqTests()
        {
            //Ao invés de definir um List, criei uma array e inseri os valores, reduzindo e repetição de código
            produtos =
            [
                new Produto { Nome = "Sabão", Valor = 1.1m, Quantidade = 10 },
                new Produto { Nome = "Detergente de prato", Valor = 10, Quantidade = 9 },
                new Produto { Nome = "Água", Valor = (decimal)8.2f, Quantidade = 8 },
                new Produto { Nome = "Esponja", Valor = (decimal)5.5, Quantidade = 7 },
                new Produto { Nome = "Água sanitária", Valor = (decimal)30.30d, Quantidade = 6 },
                new Produto { Nome = "Vassoura", Valor = 3.3m, Quantidade = 5 },
                new Produto { Nome = "Desinfetante", Valor = 4.4m, Quantidade = 4 },
                new Produto { Nome = "Pano de chão", Valor = 5.5m, Quantidade = 3 },
                new Produto { Nome = "Purificador de água", Valor = 6.6m, Quantidade = 2 },
                new Produto { Nome = "Balde", Valor = 10.1m, Quantidade = 1 },
            ];
        }

        [Fact(DisplayName = "Quantidade de produtos que possuem a palavra 'água' no nome.")]
        public void Test1()
        {
            //Substituído o valor fixo pelo método do Test do .NET
            int quantidade = produtos.Count(produto => produto.Nome.Contains("água", StringComparison.CurrentCultureIgnoreCase));

            Assert.Equal(3, quantidade);
        }

        [Fact(DisplayName = "Produtos ordenados por nome.")]
        public void Test2()
        {
            //Aqui eu defino a ordem da lista de produtos utilizando o método OrderBy e passo o parâmetro a ser ordenado (Nome)
            IEnumerable<Produto> produtosOrdenados = produtos.OrderBy(produto => produto.Nome);

            Assert.Equal("Água", produtosOrdenados.First().Nome);
            Assert.Equal("Vassoura", produtosOrdenados.Last().Nome);
        }

        [Fact(DisplayName = "Produtos ordenados do mais caro para o mais barato.")]
        public void Test3()
        {
            //O método OrderByDescendig para ordenar os produtos do maior valor para o menor valor
            IEnumerable<Produto> produtosOrdenados = produtos.OrderByDescending(produto => produto.Valor);

            Assert.Equal("Água sanitária", produtosOrdenados.First().Nome);
            Assert.Equal("Sabão", produtosOrdenados.Last().Nome);
        }

        [Fact(DisplayName = "Produto mais caro")]
        public void Test4()
        {
            //O método MaxBy itera pela lista de produtos e retorna o maior valor 
            Produto produto = produtos.MaxBy(produto => produto.Valor);

            Assert.Equal("Água sanitária", produto.Nome);
        }

        [Fact(DisplayName = "Produto mais barato")]
        public void Test5()
        {
            //O método MinBy itera pela lista de produtos e retorna o menor valor 
            Produto produto = produtos.MinBy(produto => produto.Valor);

            Assert.Equal("Sabão", produto.Nome);
        }

        [Fact(DisplayName = "Lista dos nomes dos produtoss")]
        public void Test6()
        {
            IEnumerable<string> nomeDosProdutos = produtos.Select(produto => produto.Nome);

            Assert.Contains("Água", nomeDosProdutos);
        }

        [Fact(DisplayName = "Quantidade total de todos dos produtos")]
        public void Test7()
        {
            //O método Sum retorna a soma de toda a quantidade de todos os produtos
            int quantidade = produtos.Sum(produto => produto.Quantidade);

            Assert.Equal(55, quantidade);
        }

        [Fact(DisplayName = "Nome dos produtos com valor até 10.0")]
        public void Test8()
        {
            //Utilizei o método Where para identificar os produtos com valor até 10 e para selecionar o Nome utilizei o Select
            IEnumerable<string> nomeDosProdutos = produtos
                .Where(produto => produto.Valor <= 10)
                .Select(produto => produto.Nome);

            Assert.Contains("Detergente de prato", nomeDosProdutos);
            Assert.Contains("Sabão", nomeDosProdutos);
        }

        [Fact(DisplayName = "Nome dos produtos com valor maior 10.0")]
        public void Test9()
        {
            //Utilizei o método Where para identificar os produtos com valor maior que 10 e para selecionar o Nome utilizei o Select
            IEnumerable<string> nomeDosProdutos = produtos
                .Where(produto => produto.Valor > 10)
                .Select(produto => produto.Nome);

            Assert.Contains("Balde", nomeDosProdutos);
            Assert.Contains("Água sanitária", nomeDosProdutos);
        }

        [Fact(DisplayName = "Verifica se o produto 'pão' está na lista")]
        public void Test10()
        {
            //O método exists itera por uma array e verifica se o atributo de cada dado contém o valor comparado 
            bool existe = produtos.Exists(produto => produto.Nome == "pão");

            Assert.False(existe);
        }
    }

    public class Produto
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
    }
}