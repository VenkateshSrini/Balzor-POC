using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCRUD.Server.Services;
using BlazorCRUD.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceipeController : ControllerBase
    {
        readonly IReceipeServices receipeServices;
        public ReceipeController(IReceipeServices receipeServices)
        {
            this.receipeServices = receipeServices;
        }
        public async Task<ActionResult<List<Receipe>>> GetAllReceipes()
        {
            var results = await receipeServices.GetAllReceipes();
            return Ok(results);
        }
        public async Task<ActionResult<List<Receipe>>> GetAReceipes(string Id)
        {
            var results = await receipeServices.GetReceipeById(Id);
            return Ok(results);
        }
        [HttpPost]
        public async Task<ActionResult<Receipe>>AddReceipe([FromBody]Receipe receipe)
        {
            var result = await receipeServices.Add(receipe);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<bool>> Update([FromBody]Receipe receipe)
        {
            var result = await receipeServices.Update(receipe);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<ActionResult<bool>>Remove(Receipe receipe)
        {
            var result = await receipeServices.Remove(receipe);
            return Ok(result);
        }
    }
}
