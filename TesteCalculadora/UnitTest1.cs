using MinhaCalculadora;
using System;
using Xunit;
namespace TesteCalculadora
{
    public class UnitTest1
    {
        public Calculadora construirClasse()
        {
            string data = "07/11/2023";
            Calculadora calc = new Calculadora("07/10/2023");

            return calc;
        }



        [Theory]
        [InlineData(1,2,3)]
        [InlineData(4, 5, 9)]
        public void TestSomar(int val1,int val2,int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.Somar(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }
        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(4, 5, 20)]
        public void TestMultiplicar(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.Multiplicar(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }
        [Theory]
        [InlineData(5, 2, 3)]
        [InlineData(10, 5, 5)]
        public void TestSubtrair(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.Subtrair(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }
        [Theory]
        [InlineData(6, 2, 3)]
        [InlineData(10, 5, 2)]
        public void TestDividir(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.Dividir(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }
        [Fact]
        public void TestarDivisaoPorZero()
        {
            Calculadora calc = construirClasse();
            Assert.Throws<DivideByZeroException>(
                () => calc.Dividir(3, 0)
                );
        }

        [Fact]
        public void TestarHistorico()
        {
            Calculadora calc = construirClasse();

            calc.Somar(1,2);
            calc.Somar(2, 8);
            calc.Somar(3, 7);
            calc.Somar(4, 1);

            var lista= calc.historico();

            Assert.NotEmpty(calc.historico());
            Assert.Equal(3, lista.Count);
        }
    }
}