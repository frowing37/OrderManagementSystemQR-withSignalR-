using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Drawing.Imaging;
using QRCoder;
using SignalRWebUI.Models.Dto_s;

namespace SignalRWebUI.Controllers;

public class QRCodeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        QRCode QR = new QRCode()
        {
            ImageURL = "aa"
        };
        
        return View(QR);
    }
    
    [HttpPost]
    public IActionResult Index(string value)
    {
        QRCodeGenerator QRGen = new QRCoder.QRCodeGenerator();
        var QRData = QRGen.CreateQrCode(value, QRCoder.QRCodeGenerator.ECCLevel.Q);
        BitmapByteQRCode bitmap = new BitmapByteQRCode(QRData);
        byte[] QRCodeAsBytes = bitmap.GetGraphic(20);

        QRCode QR = new QRCode()
        {
            ImageURL = $"data:image/png;base64,{Convert.ToBase64String(QRCodeAsBytes)}"
        }; 
        
        return View(QR);
    }
    
}