using System;
using System.ComponentModel.DataAnnotations;

namespace IndyBooks.Models
{
    public class Book
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string SKU { get; set; }

        public decimal Price { get; set; }

        public string Year { get; set; }

        public Writer Author {get; set; }
    }
}
