using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TCBMTGWebShop.Data;

namespace TCBMTGWebShop.Pages.Types
{
    public class ListModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;
        public List<Models.Domain.productType> Types { get; set; }
        public ListModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
            Types = dbContext.Types.ToList();
        }
    }
}
