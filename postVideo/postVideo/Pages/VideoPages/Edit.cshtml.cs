using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using postVideo.Model;

namespace postVideo.Pages.VideoPages
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Videos video { set; get; }

        [TempData]
        public string afterAddMessage { get; set; }

        public void OnGet(int id)
        {
            video = _db.VideoList.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var videoInDb = _db.VideoList.Find(video.ID);
                videoInDb.Tittle = video.Tittle;
                videoInDb.Category = video.Category;
                videoInDb.VideoDescription = video.VideoDescription;

                await _db.SaveChangesAsync();
                afterAddMessage = "Video has been updated!";

                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}