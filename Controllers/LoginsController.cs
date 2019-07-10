using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DataCollectionAPI.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DataCollectionAPI.Controllers
{
    [RouteAttribute("api/[controller]")]

    public class LoginsController : Controller
    {
        private readonly EventContext _eventcontext;

        public LoginsController(EventContext context)
        {
            _eventcontext = context;
            if (_eventcontext.Logins.Count() == 0)
            {
                _eventcontext.Logins.Add(new Login {
                    User = "Test",
                    ServerName = "Test"

                });
                _eventcontext.SaveChanges();
            }
        }
        [HttpGet]
        public IEnumerable<Login> Get()
        {
            return _eventcontext.Logins.ToList<Login>();
            //return _eventcontext.Events.FirstOrDefault(t => t.Id == 4);
        }


        [HttpGet("byUser/{username}")]
        public IActionResult GetByUsername(string username)
        {
            var items = _eventcontext.Logins.Where(u => u.User == username);
            if (items == null)
            {
                return NotFound();
            }

            return new ObjectResult(items);
        }

        [HttpGet("byServer/servername")]
        public IActionResult GetByServerName(string servername)
        {
            var items  = _eventcontext.Logins.Where(s => s.ServerName == servername);
            if (items == null)
            {
                return NotFound();
            }

            return new ObjectResult(items);


        }

        [HttpPost]
        public IActionResult Create([FromBody]Login login )
        {
            if(login == null)
            {
                return BadRequest();

            }

            _eventcontext.Logins.Add(login);
            _eventcontext.SaveChanges();
             return new NoContentResult();  
        }

      


     }    

}