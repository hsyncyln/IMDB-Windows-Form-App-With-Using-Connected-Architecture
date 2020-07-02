using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb
{
    class Image
    {
        public string ImageUrl { get; set; }
        public string ImageName { get; set; }

        public Image(string imageName,string imageUrl)
        {
            this.ImageUrl = imageUrl;
            this.ImageName=imageName;
        }
    }
}
