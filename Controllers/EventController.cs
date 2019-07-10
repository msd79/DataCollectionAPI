using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DataCollectionAPI.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DataCollectionAPI.Controllers
{
    [RouteAttribute("api/[controller]")]
    public class EventController : Controller
    {
        private readonly EventContext _eventcontext;
        public EventController(EventContext eventcontext)
        {
            _eventcontext = eventcontext;

            if (_eventcontext.Events.Count() == 0)
            {
                _eventcontext.Events.Add(new Event {
                    Keyword = "Test",
                    Source = "Test",
                    Details = "placeholder"
                });
                _eventcontext.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _eventcontext.Events.ToList<Event>();
            //return _eventcontext.Events.FirstOrDefault(t => t.Id == 4);
        }

        [HttpGet("{id}", Name = "GetEvent")]
        public IActionResult GetById(long id)
        {
            var item = _eventcontext.Events.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpGet("byKeyword/{keyword}")]
        public IActionResult Getbykeyword(string keyword)
        {
            var items =   _eventcontext.Events.Where(t => t.Keyword == keyword ); 
            if(items == null)
            {
                return NotFound();
            }
            return new ObjectResult(items);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Event myevent)
        {
            if (myevent == null)
            {
                return BadRequest();
            }

           await   _eventcontext.Events.AddAsync(myevent);
            
            //_eventcontext.Events.Add(myevent);
            _eventcontext.SaveChanges();
            
             return new NoContentResult();
            //return CreatedAtRoute("GetEvent", new { id = myevent.Id }, myevent);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Event item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var putEvent = _eventcontext.Events.FirstOrDefault(t => t.Id == id);
            if (putEvent == null)
            {
                return NotFound();
            }
            putEvent.Details = item.Details;
            putEvent.Source = putEvent.Source;

            _eventcontext.Events.Update(putEvent);
            _eventcontext.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var delEvent = _eventcontext.Events.FirstOrDefault(t => t.Id == id);

            if(delEvent == null)
            {
                return NotFound();
            }
            _eventcontext.Events.Remove(delEvent);
            _eventcontext.SaveChanges();
            return new NoContentResult();
        }


    }
    

}