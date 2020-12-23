using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Example.Member.Models;
using CQRSlite.Commands;
using CQRSlite.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Example.Member
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly ICommandSender _commandSender;
        private readonly IQueryProcessor _queryProcessor;

        public MemberController(ICommandSender commandSender, IQueryProcessor queryProcessor)
        {
            _commandSender = commandSender;
            _queryProcessor = queryProcessor;
        }


        // GET: api/Member
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Member/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Member
        [HttpPost]
        public IActionResult RegisterMember(RegisterMemberRequest value)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Authenticate()
        {
            return Ok();
        }

        // PUT: api/Member/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
