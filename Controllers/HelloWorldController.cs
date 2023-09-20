
namespace webapi.controllers;

using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]
[Route("[Action]")]
public class HelloWorldController : ControllerBase
{
     private ILogger<HelloWorldController> _logger;
    private readonly IHelloWorldService helloWorldService;
public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger){
    _logger =logger;
    helloWorldService = helloWorld;
}

[HttpGet]
public IActionResult Get(){
    _logger.LogDebug("Hello World desde Logger");
    return Ok(helloWorldService.GetHelloWorld());
}
}