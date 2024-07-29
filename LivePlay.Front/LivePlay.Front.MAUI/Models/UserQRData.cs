
namespace LivePlay.Front.MAUI.Models;

public class UserQRData
{
    public string? QRCode { get; set; }
    public DateTime GeneratedDate { get; set; }

    public UserQRData() { }

    public UserQRData(string qrCode, DateTime dateTime)
    {
        QRCode = qrCode;
        GeneratedDate = dateTime;
    }
}
