using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebFashion.Model;
using WebFashion.Sevice;

namespace WebFashion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly ILoaiRepository _loaiRepository; 

        public LoaiController(ILoaiRepository loaiRepository)
        {
            _loaiRepository = loaiRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_loaiRepository.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = _loaiRepository.GetById(id);
                if(data != null)
                {
                    return Ok(data);
                }
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, LoaiVM loai)
        {
            if (id != loai.MaLoai)
            {
                return BadRequest();
            }
            try
            {
                
                _loaiRepository.Update(loai);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add(LoaiModel loai)
        {
            try
            {
                return Ok(_loaiRepository.Add(loai));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            try
            {
                _loaiRepository.Delete(id);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    } 
}
