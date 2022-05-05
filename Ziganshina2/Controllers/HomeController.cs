using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ziganshina2.Models;

namespace Ziganshina2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult TaskSecond()
        {
            return View();
        }
        public IActionResult TaskThird()
        {
            return View();
        }
        public IActionResult TaskFirst()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TaskSecond(string textTextBox)
        {
            if (textTextBox == null) return View();
            
            var str =
                "";
            var textArr =
                textTextBox.ToCharArray().ToList();

            var newStr =
                textArr.Where(x => x != 'с').ToList();
            newStr.Remove(newStr[newStr.Count-1]);
            newStr.Add('_');
            newStr.ForEach(x=>str += x);
            
            @ViewBag.result = str;
            return View();
        }
        [HttpPost]
        public IActionResult TaskThird(string textTextBox)
        {
            if (textTextBox == null) return View();
            var square = 0.0;
            var str = "";
            var cube = 0.0;
            var size =
                Convert.ToInt32(textTextBox);
            var rand = new Random();
            int[] mas = new int[size];
            
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rand.Next(-100, 100);
            }
            
            mas.ToList().ForEach(x=>str+= $"|{x}|");

            for (int i = 0; i < mas.Length; i++)
            {
                if (i % 2 == 0)
                {
                    square += Math.Pow(mas[i], 2);
                    cube += Math.Pow(mas[i], 3);
                }
            }

            @ViewBag.mas = str;
            @ViewBag.result = $"Сумма квадратов чисел с четными индексами: {square}\n" +
                              $"Сумма кубов чисел с четными индексами: {cube}";
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}