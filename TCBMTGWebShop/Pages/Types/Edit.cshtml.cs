using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using TCBMTGWebShop.Data;
using TCBMTGWebShop.Models.Domain;
using TCBMTGWebShop.Models.ViewModels;

namespace TCBMTGWebShop.Pages.Types
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;

        [BindProperty]
        public EditTypeViewModel EditTypeViewModel { get; set; } 
        public EditModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet(Guid id)
        {
            var Type = dbContext.Types.Find(id);

            if (Type != null) 
            {
                //Convert Domain to View Model
                EditTypeViewModel = new EditTypeViewModel()
                {
                    Id = Type.Id,
                    ProductType = Type.ProductType,
                    TypeStorageSpace = Type.TypeStorageSpace,
                };
            }
        }
        public void OnPostUpdate()
        {

            if (EditTypeViewModel != null) 
            {
                var existingType = dbContext.Types.Find(EditTypeViewModel.Id);


                if (existingType != null)
                {
                    //Convert View Model to Domain Model

                    existingType.ProductType = EditTypeViewModel.ProductType;
                    existingType.TypeStorageSpace = EditTypeViewModel.TypeStorageSpace;

                    dbContext.SaveChanges();

                    ViewData["Message"] = "Type Modified Succesfully";
                }
            }
        }
        public IActionResult OnPostDelete()
        {
            var ExistingType = dbContext.Types.Find(EditTypeViewModel.Id);

            if(ExistingType != null){
                dbContext.Types.Remove(ExistingType);
                dbContext.SaveChanges();

                return RedirectToPage("/Types/List");
            }

            return Page();
        }
    }
}
