namespace ProjectA.Models
{
	public class GioHangViewModel
	{
		public IEnumerable<GioHang> DsGioHang { get; set; } 
		public HoaDon HoaDon { get; set; }

        // Thêm các thuộc tính cho mã giảm giá
        public string DiscountCode { get; set; }
        public bool IsDiscountApplied { get; set; }
        public bool IsFreeShipApplied { get; set; }
    }
}
