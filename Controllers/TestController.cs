using Microsoft.AspNetCore.Mvc;

namespace StreamWriterConfusion.Controllers;

[Route("api/[Controller]/[Action]")]
public class TestController : ControllerBase
{
    [HttpGet]
    [Produces("text/plain")]
    public async Task GetPlainText()
    {
        // No `using`: it works
        // Add `using` to the following line and the response will be empty
        // Add `await using` to the following line and it will work
        var sw = new StreamWriter(Response.Body, leaveOpen: true);

        await sw.WriteAsync("Some normal text");
        await sw.FlushAsync();
    }
}
