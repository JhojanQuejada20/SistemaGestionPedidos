
using Xunit;
using System.Net.Http;
using System.Threading.Tasks;

public class InventarioIntegrationTests
{
    private readonly HttpClient _client;

    public InventarioIntegrationTests()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5002");
    }

    [Fact]
    public async Task ObtenerTodosProductos_DeberiaRetornarOK()
    {
        var response = await _client.GetAsync("/api/productos");
        response.EnsureSuccessStatusCode();
    }
}
