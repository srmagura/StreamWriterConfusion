using Microsoft.AspNetCore.Mvc;

namespace StreamWriterConfusion.Controllers;

[Route("api/[controller]/[Action]")]
public class TestController : ControllerBase
{
    // http://localhost:5105/api/test/getPlainText
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
