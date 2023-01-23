using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using TCBMTGWebShop.Data;
using TCBMTGWebShop.Models.ViewModels;

namespace TCBMTGWebShop.Pages.Products
{
    public class ShowcaseModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;

        [BindProperty]
        public ShowcaseProductViewModel ShowcaseProductViewModel { get; set; } 
        public ShowcaseModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet(Guid id)
        {
            var Product = dbContext.Products.Find(id);

            if (Product != null) 
            {
                //Convert Domain to View Model
                ShowcaseProductViewModel = new ShowcaseProductViewModel()
                {
                    Id = Product.Id,
                    ProductName = Product.ProductName,
                    ProductDescription = Product.ProductDescription,
                    ProductType = Product.ProductType,
                    productGame = Product.productGame,
                    ProductPrice = Product.ProductPrice,
                    ProductQuantity = Product.ProductQuantity
                };
            }
        }
        public void OnPostUpdate()
        {


            
        }
    }
}
