using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TCBMTGWebShop.Models.Domain;
using TCBMTGWebShop.Data;
using TCBMTGWebShop.Models.ViewModels;

namespace TCBMTGWebShop.Pages.Products
{
    public class AddModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;

        public AddModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public AddProductViewModel AddProductRequest { get; set; }
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            // Convert View to Domain
            var productDomainModel = new Product
            {
                ProductName = AddProductRequest.ProductName,
                ProductDescription = AddProductRequest.ProductDescription,
                ProductType = AddProductRequest.ProductType,
                ProductPrice = AddProductRequest.ProductPrice,
                ProductQuantity = AddProductRequest.ProductQuantity
            };


            dbContext.Products.Add(productDomainModel);

            dbContext.SaveChanges();

            ViewData["Message"] = "Product Created Succesfully";
        }
    }
}
