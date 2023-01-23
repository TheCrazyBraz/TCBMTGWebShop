using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TCBMTGWebShop.Data;

namespace TCBMTGWebShop.Pages.Games
{
    public class ListModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;
        public List<Models.Domain.ProductGame> Games { get; set; }
        public ListModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
            Games = dbContext.Games.ToList();
        }
    }
}
