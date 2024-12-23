﻿using Microsoft.AspNetCore.Mvc;
using ProductsMvc.Infrastructure.Data;
using ProductsMvc.Models;
using System.Security.Claims;

namespace ProductsMvc.Controllers
{
    public class ProductController : Controller
    {
        private ProductsMvcDbContext _context;

        public ProductController(ProductsMvcDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {


            return View(_context.Products.ToList());          
        }

        
        public IActionResult Details(int id)
        {

                Product? p = _context.Products.FirstOrDefault(p => p.Id == id);
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
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            p.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "Guest";

            _context.Products.Add(p);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

       
        public IActionResult Edit(int id) 
        {
            Product? p = _context.Products.FirstOrDefault(p => p.Id == id);
            if (p == null)
            {
                return RedirectToAction("Index");
            }

            return View(p);
        }

        [HttpPost]
        public IActionResult Edit(Product newP)
        {
            if (!ModelState.IsValid)
            {
                return View(newP);
            }
            _context.Products.Update(newP);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            ViewBag.showDialog = true;
            ViewBag.ProductToDelete = id;
            return View("Index", _context.Products.ToList());
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Product? p = _context.Products.FirstOrDefault(p => p.Id == id);
            if (p == null)
            {
                return RedirectToAction("Index");
            }
            _context.Products.Remove(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
