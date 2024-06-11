namespace ExercicioLinq
{
    public class ExercicioLinqTests
    {
        //Atribu� o readonly, sendo que n�o h� manipula��o de dados, apenas leitura
        private readonly List<Produto> produtos;

        public ExercicioLinqTests()
        {
            //Ao inv�s de definir um List, criei uma array e inseri os valores, reduzindo e repeti��o de c�digo
            produtos =
            [
                new Produto { Nome = "Sab�o", Valor = 1.1m, Quantidade = 10 },
                new Produto { Nome = "Detergente de prato", Valor = 10, Quantidade = 9 },
                new Produto { Nome = "�gua", Valor = (decimal)8.2f, Quantidade = 8 },
                new Produto { Nome = "Esponja", Valor = (decimal)5.5, Quantidade = 7 },
                new Produto { Nome = "�gua sanit�ria", Valor = (decimal)30.30d, Quantidade = 6 },
                new Produto { Nome = "Vassoura", Valor = 3.3m, Quantidade = 5 },
                new Produto { Nome = "Desinfetante", Valor = 4.4m, Quantidade = 4 },
                new Produto { Nome = "Pano de ch�o", Valor = 5.5m, Quantidade = 3 },
                new Produto { Nome = "Purificador de �gua", Valor = 6.6m, Quantidade = 2 },
                new Produto { Nome = "Balde", Valor = 10.1m, Quantidade = 1 },
            ];
        }

        [Fact(DisplayName = "Quantidade de produtos que possuem a palavra '�gua' no nome.")]
        public void Test1()
        {
            //Substitu�do o valor fixo pelo m�todo do Test do .NET
            int quantidade = produtos.Count(produto => produto.Nome.Contains("�gua", StringComparison.CurrentCultureIgnoreCase));

            Assert.Equal(3, quantidade);
        }

        [Fact(DisplayName = "Produtos ordenados por nome.")]
        public void Test2()
        {
            //Aqui eu defino a ordem da lista de produtos utilizando o m�todo OrderBy e passo o par�metro a ser ordenado (Nome)
            IEnumerable<Produto> produtosOrdenados = produtos.OrderBy(produto => produto.Nome);

            Assert.Equal("�gua", produtosOrdenados.First().Nome);
            Assert.Equal("Vassoura", produtosOrdenados.Last().Nome);
        }

        [Fact(DisplayName = "Produtos ordenados do mais caro para o mais barato.")]
        public void Test3()
        {
            //O m�todo OrderByDescendig para ordenar os produtos do maior valor para o menor valor
            IEnumerable<Produto> produtosOrdenados = produtos.OrderByDescending(produto => produto.Valor);

            Assert.Equal("�gua sanit�ria", produtosOrdenados.First().Nome);
            Assert.Equal("Sab�o", produtosOrdenados.Last().Nome);
        }

        [Fact(DisplayName = "Produto mais caro")]
        public void Test4()
        {
            //O m�todo MaxBy itera pela lista de produtos e retorna o maior valor 
            Produto produto = produtos.MaxBy(produto => produto.Valor);

            Assert.Equal("�gua sanit�ria", produto.Nome);
        }

        [Fact(DisplayName = "Produto mais barato")]
        public void Test5()
        {
            //O m�todo MinBy itera pela lista de produtos e retorna o menor valor 
            Produto produto = produtos.MinBy(produto => produto.Valor);

            Assert.Equal("Sab�o", produto.Nome);
        }

        [Fact(DisplayName = "Lista dos nomes dos produtoss")]
        public void Test6()
        {
            IEnumerable<string> nomeDosProdutos = produtos.Select(produto => produto.Nome);

            Assert.Contains("�gua", nomeDosProdutos);
        }

        [Fact(DisplayName = "Quantidade total de todos dos produtos")]
        public void Test7()
        {
            //O m�todo Sum retorna a soma de toda a quantidade de todos os produtos
            int quantidade = produtos.Sum(produto => produto.Quantidade);

            Assert.Equal(55, quantidade);
        }

        [Fact(DisplayName = "Nome dos produtos com valor at� 10.0")]
        public void Test8()
        {
            //Utilizei o m�todo Where para identificar os produtos com valor at� 10 e para selecionar o Nome utilizei o Select
            IEnumerable<string> nomeDosProdutos = produtos
                .Where(produto => produto.Valor <= 10)
                .Select(produto => produto.Nome);

            Assert.Contains("Detergente de prato", nomeDosProdutos);
            Assert.Contains("Sab�o", nomeDosProdutos);
        }

        [Fact(DisplayName = "Nome dos produtos com valor maior 10.0")]
        public void Test9()
        {
            //Utilizei o m�todo Where para identificar os produtos com valor maior que 10 e para selecionar o Nome utilizei o Select
            IEnumerable<string> nomeDosProdutos = produtos
                .Where(produto => produto.Valor > 10)
                .Select(produto => produto.Nome);

            Assert.Contains("Balde", nomeDosProdutos);
            Assert.Contains("�gua sanit�ria", nomeDosProdutos);
        }

        [Fact(DisplayName = "Verifica se o produto 'p�o' est� na lista")]
        public void Test10()
        {
            //O m�todo exists itera por uma array e verifica se o atributo de cada dado cont�m o valor comparado 
            bool existe = produtos.Exists(produto => produto.Nome == "p�o");

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