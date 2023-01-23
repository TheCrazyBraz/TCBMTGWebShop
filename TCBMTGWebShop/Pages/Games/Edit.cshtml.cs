using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using TCBMTGWebShop.Data;
using TCBMTGWebShop.Models.Domain;
using TCBMTGWebShop.Models.ViewModels;

namespace TCBMTGWebShop.Pages.Games
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;

        [BindProperty]
        public EditGameViewModel EditGameViewModel { get; set; }
        public EditModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet(Guid id)
        {
            var Game = dbContext.Games.Find(id);

            if (Game != null)
            {
                //Convert Domain to View Model
                EditGameViewModel = new EditGameViewModel()
                {
                    Id = Game.Id,
                    productGame = Game.productGame,
                    GameCreator = Game.GameCreator,
                };
            }
        }
        public void OnPostUpdate()
        {

            if (EditGameViewModel != null)
            {
                var existingGame = dbContext.Games.Find(EditGameViewModel.Id);


                if (existingGame != null)
                {
                    //Convert View Model to Domain Model

                    existingGame.productGame = EditGameViewModel.productGame;
                    existingGame.GameCreator = EditGameViewModel.GameCreator;

                    dbContext.SaveChanges();

                    ViewData["Message"] = "Game Modified Succesfully";
                }
            }
        }
        public IActionResult OnPostDelete()
        {
            var ExistingGame = dbContext.Games.Find(EditGameViewModel.Id);

            if (ExistingGame != null)
            {
                dbContext.Games.Remove(ExistingGame);
                dbContext.SaveChanges();

                return RedirectToPage("/Games/List");
            }

            return Page();
        }
    }
}
