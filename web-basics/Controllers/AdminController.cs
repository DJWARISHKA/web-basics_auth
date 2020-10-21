using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using web_basics.business.Domains;

namespace web_basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly Account account;

        public AdminController(IConfiguration configuration)
        {
            account = new Account(configuration);
        }

        [HttpGet]
        public IEnumerable<business.ViewModels.Account> Get()
        {
            return account.Get();
        }

        [HttpPost]
        public IActionResult Create(business.ViewModels.Account model)
        {
            model = account.Create(model);
            if (model != null)
                return Ok(model);
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Change([FromBody] business.ViewModels.Account model)
        {
            model = account.Update(model);
            if (model != null)
                return Ok(model);
            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (account.Delete(id))
                return Ok();
            return BadRequest();
        }
    }
}