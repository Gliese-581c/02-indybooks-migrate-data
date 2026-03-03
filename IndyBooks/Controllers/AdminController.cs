using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndyBooks.Models;
using IndyBooks.Services;
using IndyBooks.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IndyBooks.Controllers
{
    public class AdminController : Controller
    {
        private Services.Repository _repo;
        private IndyBooksDataContext _db;
        public AdminController(Services.Repository repo, IndyBooksDataContext db) {
             _repo = repo; 
             _db = db;
        }
    
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(SearchVM searchVM)
        {
            var searchResults = searchVM.HalfPriceSale ?
            new SearchResultsVM { 
                Books = _repo.SaleResults,
                isSale = true
            } : 
            new SearchResultsVM { 
                Books = _repo.searchResults(searchVM).ToList(),
                isSale = false
            }; 

            return View("SearchResults", searchResults);
        }

        //TODO: Add the CreateBook GET method
        [HttpGet]
        public IActionResult CreateBook()
        {
            return View();
        }
 
        [HttpPost]
        public IActionResult CreateBook(CreateBookVM bookVM)
        {
            //TODO: Add Model Validation
            if (!ModelState.IsValid)
            { return View("CreateBook", bookVM); }

            //TODO: Once you've added the Writers DbSet, create a Writer object using the view Model info
            Writer author = new Writer { Name = bookVM.Author };

            //TODO: Once you've added the Writers DbSet, modify the Book using your newly created author.
            Book book = new Book { Title = bookVM.Title, Author = author, Price = bookVM.Price, Year = bookVM.Year, SKU = bookVM.SKU };


            //TODO: Once you've added the Writers DbSet, add author to the dataset
            _db.Writers.Add(author);
            _db.SaveChanges();
      
            return RedirectToAction("Search");
        }
    }
}
