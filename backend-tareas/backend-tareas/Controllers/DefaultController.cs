using Microsoft.AspNetCore.Mvc;

namespace backend_tareas.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DefaultController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "API is running";
    }
}