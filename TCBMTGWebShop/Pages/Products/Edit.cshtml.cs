using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using TCBMTGWebShop.Data;
using TCBMTGWebShop.Models.ViewModels;

namespace TCBMTGWebShop.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;

        [BindProperty]
        public EditProductViewModel EditProductViewModel { get; set; } 
        public EditModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet(Guid id)
        {
            var Product = dbContext.Products.Find(id);

            if (Product != null) 
            {
                //Convert Domain to View Model
                EditProductViewModel = new EditProductViewModel()
                {
                    Id = Product.Id,
                    ProductName = Product.ProductName,
                    ProductDescription = Product.ProductDescription,
                    ProductType = Product.ProductType,
                    ProductPrice = Product.ProductPrice,
                    ProductQuantity = Product.ProductQuantity
                };
            }
        }
        public void OnPostUpdate()
        {

            if (EditProductViewModel != null) 
            {
                var existingProduct = dbContext.Products.Find(EditProductViewModel.Id);


                if (existingProduct != null)
                {
                    //Convert View Model to Domain Model
                    existingProduct.ProductName = EditProductViewModel.ProductName;
                    existingProduct.ProductDescription = EditProductViewModel.ProductDescription;
                    existingProduct.ProductType = EditProductViewModel.ProductType;
                    existingProduct.ProductPrice = EditProductViewModel.ProductPrice;
                    existingProduct.ProductQuantity = EditProductViewModel.ProductQuantity;

                    dbContext.SaveChanges();

                    ViewData["Message"] = "Product Modified Succesfully";
                }
            }
        }
        public IActionResult OnPostDelete()
        {
            var ExistingProduct = dbContext.Products.Find(EditProductViewModel.Id);

            if(ExistingProduct != null){
                dbContext.Products.Remove(ExistingProduct);
                dbContext.SaveChanges();

                return RedirectToPage("/Products/List");
            }

            return Page();
        }
    }
}
