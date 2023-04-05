using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsModule.Business.Interfaces;
using NewsModule.DTOs.NewsDtos;
using NewsModule.DTOs.UserDtos;

namespace NewsModule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewsDto newsDto)
        {
            return Ok(await _newsService.Create(newsDto));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _newsService.Delete(id));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,NewsDto newsDto)
        {
            return Ok(await _newsService.Update(id,newsDto));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _newsService.GetById(id));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _newsService.GetAll());
        }
    }
}
