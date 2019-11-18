using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
        MovieDatabase movieDataBase = new MovieDatabase();

        public List<Movie> Movies;

        public void OnGet()
        {
            Movies = movieDataBase.All;
        }

        public void OnPost(string search, List<string> rating)
        {
            if (search != null && rating.Count != 0)
            {
                Movies = movieDataBase.SearchAndFilter(search, rating);
            }
            else if (rating.Count != 0)
            {
                Movies = movieDataBase.Filter(rating);
            }
            else if (search != null)
            {
                Movies = movieDataBase.Search(search);
            }
            else
            {
                Movies = movieDataBase.All;
            }
        }
    }
}
