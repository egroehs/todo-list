using Microsoft.AspNetCore.Mvc;

namespace todo_list.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseController : ControllerBase
    {
    }
}
