namespace MicroservicioDePedidos.Tests;
using Xunit;
using System.Threading.Tasks;


namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            await Task.Delay(10);
            Assert.True(true);
        }
    }
}