using Kanjiro.API.Database;
using Microsoft.AspNetCore.Mvc;

namespace Kanjiro.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Card_Controller : ControllerBase
    {
        private Kanjiro_Context _context;

        public Card_Controller(Kanjiro_Context context)
        {
            _context = context;
        }
    }
}
