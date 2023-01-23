using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TCBMTGWebShop.Models.Domain;
using TCBMTGWebShop.Data;
using TCBMTGWebShop.Models.ViewModels;

namespace TCBMTGWebShop.Pages.Types
{
    public class AddModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;

        public AddModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public AddTypeViewModel AddTypeRequest { get; set; }
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            // Convert View to Domain
            var typeDomainModel = new productType
            {
                ProductType = AddTypeRequest.ProductType,
                TypeStorageSpace = AddTypeRequest.TypeStorageSpace,

            };


            dbContext.Types.Add(typeDomainModel);

            dbContext.SaveChanges();

            ViewData["Message"] = "Type Created Succesfully";
        }
    }
}
