using System.Collections.Generic;
using System.Threading.Tasks;
using api.Data;
using api.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("v1/categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
        {
            var categories = await context.Category.ToListAsync();
            return  categories;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> Post(
            [FromServices] DataContext context,
            [FromBody] Category model
        ) {
            if (ModelState.IsValid) {
                context.Category.Add(model);
                await context.SaveChangesAsync();
                return model;
            }

            return BadRequest(ModelState);
        }
    }
}