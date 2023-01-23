using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TCBMTGWebShop.Models.Domain;
using TCBMTGWebShop.Data;
using TCBMTGWebShop.Models.ViewModels;

namespace TCBMTGWebShop.Pages.Games
{
    public class AddModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;

        public AddModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public AddGameViewModel AddGameRequest { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            // Convert View to Domain
            var GameDomainModel = new ProductGame
            {
                productGame = AddGameRequest.productGame,
                GameCreator = AddGameRequest.GameCreator,

            };


            dbContext.Games.Add(GameDomainModel);

            dbContext.SaveChanges();

            ViewData["Message"] = "Game Created Succesfully";
        }
    }
}
