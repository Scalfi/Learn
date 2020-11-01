﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Learn.Controllers.APIsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIProdutoController : ControllerBase
    {
        // GET: api/<APIProdutoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<APIProdutoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<APIProdutoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<APIProdutoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<APIProdutoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
