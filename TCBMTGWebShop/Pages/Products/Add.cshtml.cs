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
        public List<ProductGame> Games { get; set; }
        public List<productType> Types { get; set; }


        [BindProperty]

        public AddProductViewModel AddProductRequest { get; set; }
        public void OnGet()
        {
            Games = dbContext.Games.ToList();
            Types = dbContext.Types.ToList();
        }

        public void OnPost() 
        {
            Games = dbContext.Games.ToList();
            Types = dbContext.Types.ToList();
            // Convert View to Domain
            var productDomainModel = new Product
            {
                ProductName = AddProductRequest.ProductName,
                ProductDescription = AddProductRequest.ProductDescription,
                ProductType = AddProductRequest.ProductType,
                productGame = AddProductRequest.productGame,
                ProductPrice = AddProductRequest.ProductPrice,
                ProductQuantity = AddProductRequest.ProductQuantity
            };


            dbContext.Products.Add(productDomainModel);
            dbContext.SaveChanges();

            ViewData["Message"] = "Product Created Succesfully";
        }
    }
}
