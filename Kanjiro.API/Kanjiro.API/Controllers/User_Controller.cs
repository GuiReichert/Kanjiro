using Kanjiro.API.Database;
using Microsoft.AspNetCore.Mvc;

namespace Kanjiro.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class User_Controller : ControllerBase
    {
        private Kanjiro_Context _context;

        public User_Controller(Kanjiro_Context context)
        {
            _context = context;
        }
    }
}
