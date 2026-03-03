using IndyBooks.Models;
using IndyBooks.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace IndyBooks.Services;

public class Repository
{
    private IndyBooksDataContext _db;

    public Repository(IndyBooksDataContext db)
    {
        _db = db;
    }   

    //Property to return ALL Books on sale (price greater than 90) with the price reduced by 50%
    public decimal Sale{ get; set; } = 0.5m; 
    public int SaleLimit { get;set; } = 90; 
    //the SaleResults property returns all Books with a price greater than the SaleLimit, with the price reduced by the Sale
    public IEnumerable<Book> SaleResults => _db.Books
        .Where(b => b.Price > SaleLimit)
        .Select(b => new Book
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Year = b.Year,
                Price = b.Price * Sale
            });
    public IEnumerable<Book> searchResults(SearchVM searchVM) {
            IQueryable<Book> foundBooks = _db.Books; // start with entire collection

            //Filter the collection using the non-empty Title Field as noted
            if (searchVM.Title != null && searchVM.Title.Trim().Length > 0)
            {
                //Filter the collection by Title which "contains" the given string
                foundBooks = foundBooks
                             .Where(b => b.Title.Contains(searchVM.Title));
            }

            //TODO: Update to use the Author's Name property
        
            if (searchVM.Author != null && searchVM.Author.Trim().Length > 0)
            {
                foundBooks = foundBooks
                            .Where(b => b.Author.Name.Contains(searchVM.Author));
            }
            // Uses similar logic to filter foundbooks collection by price, if given
            if(searchVM.MinPrice > 0)
            {
                foundBooks = foundBooks
                             .Where(b => b.Price > searchVM.MinPrice);
            }
            if(searchVM.MaxPrice > 0)
            {
                foundBooks = foundBooks
                             .Where(b => b.Price < searchVM.MaxPrice);
            } 

            return foundBooks.ToList();
    }   

};     


