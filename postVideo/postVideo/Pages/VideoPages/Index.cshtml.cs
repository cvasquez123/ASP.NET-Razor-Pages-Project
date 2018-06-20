using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using postVideo.Model;

namespace postVideo.Pages.VideoPages
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _db;
        
        [TempData]
        public string afterAddMessage { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;

        }

        public IEnumerable<Videos> MyVideos { get; set; }
        
        public async Task OnGet()
        {
            MyVideos = await _db.VideoList.ToListAsync();
        }

        public async Task<IActionResult>OnPostDelete(int id)
        {
            var theVideo = _db.VideoList.Find(id);

            _db.VideoList.Remove(theVideo);

            await _db.SaveChangesAsync();

            afterAddMessage = "Video deleted successfully";

            //if you dont place anything in these parentheses then it redirects to the same page (refreshes)
            return RedirectToPage();
        }
    }
}