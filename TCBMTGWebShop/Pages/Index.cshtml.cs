using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TCBMTGWebShop.Data;

namespace TCBMTGWebShop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;

        public List<Models.Domain.Product> Products { get; set; }
        public IndexModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
            Products = dbContext.Products.ToList();
        }
    }
}