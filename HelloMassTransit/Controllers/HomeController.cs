using HelloMassTransit.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace HelloMassTransit.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBus _bus;

    public HomeController(ILogger<HomeController> logger, IBus bus)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _bus = bus ?? throw new ArgumentNullException(nameof(bus));
    }

    [HttpPost("Test")]
    public async Task<IActionResult> PublishTestMessage()
    {
        _logger.LogInformation("Publishing test message...");

        await _bus.Publish(new TestEvent { Text = "Test message."});

        return Ok("Test message had been published.");
    }
}
