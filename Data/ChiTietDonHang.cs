namespace WebFashion.Data
{
    public class ChiTietDonHang
    {
        public Guid MaDH { get; set; }
        public Guid MaHangHoa { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }

        public byte GiamGia { get; set; }

        //relationship
        public DonHang DonHang { get; set; }
        public HangHoa HangHoa { get; set; }

    }
}
