using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;

        public CategoryController(ApplicationDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult <Category>> Create([FromBody] CreateCategoryDTO createCategory)
        {

            var result = _mapper.Map<Category>(createCategory);
            await _db.Categories.AddAsync(result);
            await _db.SaveChangesAsync();
            return Ok();
                                                    
        }

        [HttpGet]
        public async Task<ActionResult <List<Category>>> GetAll()
        {
            var result = await _db.Categories.ToListAsync();
            return result;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult <Category>> GetById(int id)
        {
            var result = await _db.Categories.FindAsync(id);
            return result;
        }

        [HttpPut]
        public async Task<ActionResult <Category>> Update([FromBody] Category category)
        {
            _db.Categories.Update(category);
            await _db.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Category>> Delete(int id) {

            var result = await _db.Categories.FindAsync(id);
            _db.Categories.Remove(result);
            await _db.SaveChangesAsync();
            return Ok();
        
        }

    }

}
