using System.Diagnostics;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using MachineLearning.Web.Clients;
using MachineLearning.Web.Dtos;
using Microsoft.AspNetCore.Mvc;
using MachineLearning.Web.Models;
using MachineLearning.Web.ViewModels;

namespace MachineLearning.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRegressionClient _regressionClient;

    public HomeController(ILogger<HomeController> logger, IRegressionClient regressionClient)
    {
        _logger = logger;
        _regressionClient = regressionClient;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost("LinearRegression")]
    public async Task<IActionResult> LinearRegression([FromBody] LinearRegressionRequestDto linearProgressionRequestDto)
    {
        var linearRegressionDataset = await _regressionClient.GetLinearRegressionDataset(new LinearRegressionRequestModel()
        {
            DependentVariable = linearProgressionRequestDto.DependentVariable,
            IndependentVariable = linearProgressionRequestDto.IndependentVariable
        });
        
        return Ok(linearRegressionDataset);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}