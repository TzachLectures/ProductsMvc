using Microsoft.AspNetCore.Mvc;
using ProductsMvc.Models;

namespace ProductsMvc.Controllers
{
    public class ProductController : Controller
    {
       static private List<Product> lstP = new List<Product>() {
            new Product() {Id=1, Name = "Pizza" , Description= "erg erg erg" , Price = 15.4 , Quantity = 5 },
            new Product() {Id=2, Name = "Hamburger" , Description= "ge rrrrr erg" , Price = 33 , Quantity = 4 },
            new Product() {Id=3, Name = "moses" , Description= "555 erg v" , Price = 2344 , Quantity = 34 },
            new Product() { Id=4,Name = "dani" , Description= "erg vv ffff" , Price = 1000 , Quantity = 4555 } };

        public IActionResult Index()
        { 

            return View(lstP);          
        }

        
        public IActionResult Details(int id)
        {

                Product? p = lstP.FirstOrDefault(p => p.Id == id);
                if (p == null)
                {
                    return RedirectToAction("Index");
                }

                return View(p);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create (Product p)
        {
            p.Id = lstP.Count + 1;
            lstP.Add(p);
            return RedirectToAction("Index");

        }
    }
}
