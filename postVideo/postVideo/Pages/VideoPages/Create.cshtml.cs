using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using postVideo.Model;

namespace postVideo.Pages.VideoPages
{
    public class CreateModel : PageModel
    {
        private ApplicationDbContext _db;

        [TempData]
        public string afterAddMessage { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;

        }
        
        [BindProperty]
        public Videos video { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                //return to a page and not a view
                return Page();
            }
            else
            {
                // if it is valid then we'll add our video post to our table
                _db.VideoList.Add(video);

                await _db.SaveChangesAsync();

                afterAddMessage = "New Movie added!"; 

                return RedirectToPage("Index");
            }
        }

    }
}
