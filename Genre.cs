using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb
{
    public class Genre
    {
        public string GenreUrl { get; set; }
        public string GenreName { get; set; }

        public Genre(string genreName,string genreUrl)
        {
            this.GenreUrl = genreUrl;
            this.GenreName = genreName;
        }
        public override string ToString()
        {
            return this.GenreName;
        }
    }
}
