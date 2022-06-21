using Gerando_QRCode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Gerando_QRCode.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string Caminho)
        {

            if (!String.IsNullOrEmpty(Caminho))
            {
                var byteArray = Funcoes.QRCode_Generate.GenerateByteArray(Caminho);
                string strBase64 = Convert.ToBase64String(byteArray);

                ViewBag.Base64String = "data:image/png;base64," + Convert.ToBase64String(byteArray, 0, byteArray.Length);
            }
            
            return View();
        }


      

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
