using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WebFashion.Model;

namespace WebFashion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa> ();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                return Ok(hangHoa);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hangHoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia
            };
            hangHoas.Add(hangHoa);
            return Ok(new
            {
                Success = true, Data = hangHoa
            });
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, HangHoa hangHoa)
        {
            try
            {
                // ckeck dinh dang Id trong URL
                if(!Guid.TryParse(id, out Guid guidId))
                {
                    return BadRequest("ID khong hop le");
                }
                //kiem tra id trong body
                if(hangHoa.MaHangHoa == null && hangHoa.MaHangHoa != guidId)
                {
                    return BadRequest("ID khong trung khop");
                }
                // tim hang hoa
                var hh = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == guidId);
                if(hh == null)
                {
                    return NotFound("Khong tim thay hang hoa");
                }
                //cap nhat du lieu
                hh.TenHangHoa = hangHoa.TenHangHoa;
                hh.DonGia = hangHoa.DonGia;

                return Ok("Put thanh cong");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                // kiem tra id
                if(!Guid.TryParse(id, out Guid guidId))
                {
                    return BadRequest("Id khong hop le");
                }
                //tim hang hoa trong list
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == guidId);
                if(hangHoa == null)
                {
                    return NotFound();
                }
                hangHoas.Remove(hangHoa);
                return Ok("Da xoa hang hoa thanh cong");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
