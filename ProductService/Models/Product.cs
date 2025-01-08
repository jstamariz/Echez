using System;
using ProductService.Models.ValueObjects;

namespace ProductService.Models
{
    public class Product()
    {
        public int Id { get; set; }
        public required ProductName Name { get; set; }
        public required Price Price { get; set; }
        public required Description Description { get; set; }
        public Uri? Image {get; set;}
    }
}
