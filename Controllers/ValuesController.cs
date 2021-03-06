﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
namespace dotnetcoretest.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public static List<string> controllervalues =  new List<string> { "value1", "value2" };
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return controllervalues;
        }

        // GET api/values/5
         [SwaggerResponse(200, Type = typeof(string))]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return controllervalues.ElementAt(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            controllervalues.Add(value);
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
            controllervalues.RemoveAt(id);
        }
    }
}
