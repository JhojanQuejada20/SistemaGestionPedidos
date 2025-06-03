
using Xunit;
using System.Net.Http;
using System.Threading.Tasks;

public class PedidosIntegrationTests
{
    private readonly HttpClient _client;

    public PedidosIntegrationTests()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5001");
    }

    [Fact]
    public async Task CrearPedido_DeberiaRetornarCreated()
    {
        var content = new StringContent("{\"cliente\":\"Juan\",\"items\":[{\"productoId\":1,\"cantidad\":2}]}", System.Text.Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/api/pedidos", content);
        response.EnsureSuccessStatusCode();
    }
}
