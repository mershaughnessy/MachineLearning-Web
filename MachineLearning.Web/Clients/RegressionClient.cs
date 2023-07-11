using System.Net.Mime;
using System.Text;
using System.Text.Json;
using MachineLearning.Web.Models;

namespace MachineLearning.Web.Clients;

public class RegressionClient : IRegressionClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public RegressionClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<LinearRegressionResponseModel?> GetLinearRegressionDataset(LinearRegressionRequestModel linearRegressionRequestModel)
    {
        var client = _httpClientFactory.CreateClient("ml_app");
        var requestBody = new StringContent(JsonSerializer.Serialize(linearRegressionRequestModel), Encoding.UTF8,
            MediaTypeNames.Application.Json);
        var response = await client.PostAsync("/linearRegression", requestBody);
        var data = await response.Content.ReadAsStringAsync();
        var deserializedData = JsonSerializer.Deserialize<LinearRegressionResponseModel>(data);
        return deserializedData;
    }
}

public interface IRegressionClient
{
    public Task<LinearRegressionResponseModel?> GetLinearRegressionDataset(
        LinearRegressionRequestModel linearRegressionRequestModel);
}