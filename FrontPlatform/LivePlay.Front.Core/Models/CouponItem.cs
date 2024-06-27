
namespace LivePlay.Front.Core.Models;

public class CouponItem
{
    public string Title { get; set; } = string.Empty;
    public string DescriptionMini { get; set; } = string.Empty;
    public string DescriptionFull { get; set; } = string.Empty;
    public byte[] Image { get; set; } = [];
    public string CouponS {  set; get; } = string.Empty;
    public DateTime FinalDate { get; set; } = DateTime.Now;
    public string FinalDateView { get => FinalDate.ToString("dd.MM.yyyy"); }
    public int Price { get; set; }
}
