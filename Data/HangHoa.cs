using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebFashion.Data
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public Guid MaHangHoa { get; set; }

        [Required]
        [StringLength(100)]
        public string TenHangHoa { get; set; }

        public string MoTa {  get; set; }

        [Range(0, double.MaxValue)]
        public double DonGia { get; set; }

        public byte GiamGia { get; set; }

        //khoa phu voi bang Loai
        public int? MaLoai { get; set; }
        [ForeignKey(nameof(MaLoai))]
        public Loai Loai { get; set; }

        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public HangHoa()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();   
        }
    }
}
