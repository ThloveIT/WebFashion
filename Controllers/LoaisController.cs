using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebFashion.Data;
using WebFashion.Model;

namespace WebFashion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : ControllerBase
    {
        private MyDbContext _context;

        public LoaisController(MyDbContext context) 
        {
            _context = context;
        }

        //lay tat ca
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsLoai = _context.loais.ToList();
            return Ok(dsLoai);
        }

        //lay theo id 
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            try
            {
                var loai = _context.loais.SingleOrDefault(loai => loai.MaLoai == id);
                if (loai != null)
                {
                    return Ok(loai);
                }
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

        //Them moi
        [HttpPost]
        public IActionResult CreateNew(LoaiModel model)
        {
            try
            {
                var loai = new Loai
                {
                    TenLoai = model.TenLoai,
                };
                _context.loais.Add(loai);
                _context.SaveChanges();
                return Ok(loai);
            }
            catch
            {
                return BadRequest();
            }
        }

        //update theo ID
        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, LoaiModel model)
        {
            try
            {
                var loai = _context.loais.SingleOrDefault(loai => loai.MaLoai == id);
                if(loai != null)
                {
                    loai.TenLoai = model.TenLoai;
                    _context.SaveChanges();
                    return Ok();
                }
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

        //xoa 
        [HttpDelete("{id}")]
        public IActionResult DelByID(int id)
        {
            try
            {
                var loai = _context.loais.SingleOrDefault(loai => loai.MaLoai == id);
                if(loai != null)
                {
                    _context.loais.Remove(loai);
                    _context.SaveChanges();
                    return Ok();
                }
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
