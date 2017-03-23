using System.Collections.Generic;
using System.Linq;
using dotnetcoretest.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnetcoretest.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Models.Task> Get()
        {
            using (var db = new TicketingContext())
            {
                return db.Tasks;                
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Models.Task Get(int id)
        {
            using (var db = new TicketingContext())
            {
                return db.Tasks.Where(x=>x.IDTask==id).FirstOrDefault();
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)

        {
            Models.Task task = new Models.Task(){IDTask = id};
             using (var db = new TicketingContext())
            {
                 db.Tasks.Attach(task);
                 db.Tasks.Remove(task);
                 db.SaveChanges();
            }
        }
    }
}
