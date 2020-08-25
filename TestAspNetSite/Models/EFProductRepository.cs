using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;

namespace TestAspNetSite.Models
{
    public class EFProductRepository :IProductRepository
    {
        public ApplicationDbContext context { get; set; }
        public EFProductRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public List<Product> Products => context.Products.ToList();
        public void SaveProduct(Product product)
        {
            if(product.ProductId == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
                if(dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Category = product.Category;
                    dbEntry.Image_Url = product.Image_Url;
                    dbEntry.Url_to_Download = product.Url_to_Download;
                }
            }
            context.SaveChanges();
        }
        public Product DeleteProduct(int product_id)
        {
            Product dbEntry = context.Products.FirstOrDefault(p => p.ProductId == product_id);
            if(dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
