using System;
using Microsoft.AspNetCore.Mvc;
using WorkingWithVisualStudio.Models;
using System.Linq;

namespace WorkingWithVisualStudio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View(ProductRepository.SharedRepository.Products
                                            .Where(p => p?.Price < 50));
      
    }
}
