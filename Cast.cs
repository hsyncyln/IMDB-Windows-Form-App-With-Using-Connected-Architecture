using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Imdb
{
    public enum Role
    {
        director = 1,
        writer = 2,
        star = 3,
        none = 4
    }
    public class Cast
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string CastId { get; set; }
        public string Description { get; set; }
        public string PosterLink { get; set; }
        public List<Movie> Shows { get; set; }
        public List<Role> Roles { get; set; }

        public Cast()
        {
            Roles = new List<Role>();
            Shows = new List<Movie>();
        }
        public Cast(string firstName, string lastName, string castId)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CastId = castId;
            this.Roles = new List<Role>();

        }
        public void GetInfo()
        {
            Shows = new List<Movie>();
            this.BirthDate = BornDate();
            this.Description = CastDescription();
            this.PosterLink = CastPoster();

            string city = "";
            string state = "";
            this.Country = "";
            this.Country = BirthPlace(ref city,ref state);
            this.City = city;
            this.State = state;
        }
        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
        private string CastDescription()
        {
            WebClient webClient = new WebClient();
            string result = webClient.DownloadString("https://www.imdb.com" + this.CastId);

            string description = "";
            int starts_with, ends_with;

            starts_with = result.IndexOf("txt-block");
            if (starts_with == -1) return "---None---";  //description yoksa richtextbox a none yazar
            result = result.Substring(starts_with);
            starts_with = result.IndexOf("inline");
            ends_with = result.IndexOf(">");           //summary_text ten sonraki > ile < arasında description bulunur
            result = result.Substring(ends_with + 1);

            while (true)
            {
                ends_with = result.IndexOf("<");

                if (description.Contains("&raquo;"))
                {
                    description = description.Substring(0, description.IndexOf("&raquo;"));
                    break;
                }
                description += result.Substring(0, ends_with);
                result = result.Substring(ends_with);

                if (result.Substring(0, 5) == "<span") break;

                starts_with = result.IndexOf(">");
                result = result.Substring(starts_with + 1);
            }
            description = description.Replace("Ã¶", "ö");
            description = description.Replace("\n", "");
            return description.Replace("                       ", "");
        }

        private string CastPoster()
        {
            WebClient webClient = new WebClient();
            string result = webClient.DownloadString("https://www.imdb.com" + this.CastId);

            int startsWith = result.IndexOf("name-poster");
            if (startsWith == -1) return "";
            result = result.Substring(startsWith);

            startsWith = result.IndexOf("src");
            result = result.Substring(startsWith + 1);

            startsWith = result.IndexOf('"');
            result = result.Substring(startsWith + 1);
            int endsWith = result.IndexOf('"');

            return result.Substring(0, endsWith);
        }
        private DateTime BornDate()
        {
            WebClient webClient = new WebClient();
            string result = webClient.DownloadString("https://www.imdb.com" + this.CastId);

            int startsWith, endsWith = 0;

            startsWith = result.IndexOf("name-born-info");

            if (startsWith == -1) return Convert.ToDateTime("1/1/1753");
            result = result.Substring(startsWith);
            startsWith = result.IndexOf("datetime");
            result = result.Substring(startsWith + 1);
            startsWith = result.IndexOf('"');
            result = result.Substring(startsWith + 1);
            endsWith = result.IndexOf('"');
            if (Convert.ToDateTime(result.Substring(0, endsWith)).Year < 1753 ) return Convert.ToDateTime("1/1/1753");
            return Convert.ToDateTime(result.Substring(0, endsWith));
        }
        private string BirthPlace(ref string city, ref string area)
        {
            WebClient webClient = new WebClient();
            string result = webClient.DownloadString("https://www.imdb.com" + this.CastId);

            string place;
            int startsWith, endsWith = 0;

            startsWith = result.IndexOf("birth_place");

            if (startsWith == -1) return "";
            result = result.Substring(startsWith);
            startsWith = result.IndexOf(">");
            result = result.Substring(startsWith + 1);
            endsWith = result.IndexOf("<");
            place = result.Substring(0, endsWith);

            string[] places = place.Split(',');

            if (places.Count() == 1)
            {
                return places[0];
            }
            else if (places.Count() == 2)
            {
                city = places[0];
                return places[1];
            }
            else if(places.Count()==3)
            {
                city = places[0];
                area = places[1];
                return places[2];
            }
            else { return  ""; }
                        
        }
 
        public void CastShows()
        {            
            WebClient webClient = new WebClient();
            string result = webClient.DownloadString("https://www.imdb.com/" + this.CastId);

            string showName, showUrl, category;

            int startsWith = result.IndexOf("filmo-head");     //filmler <table> ların arasında olduğundan kontrol edilecek data azaltıldı
            string showTable = result.Substring(startsWith);
            int endsWith = result.IndexOf("<script>");
            showTable = showTable.Substring(endsWith);

            while (showTable.IndexOf("filmo-head") != -1)  // '/title' ile başlayan kısımlar listelenmiş filmleri url leridir. 
            {                                           //Eğer -1 ise aranan filmlerin url leri alınmıştır

                startsWith = showTable.IndexOf("data-category=");          //ilk url'in başlangıç noktasını bulur
                showTable = showTable.Substring(startsWith);
                startsWith = showTable.IndexOf('"');
                showTable = showTable.Substring(startsWith + 1);
                endsWith = showTable.IndexOf('"');

                category = showTable.Substring(0, endsWith);

                showTable = showTable.Substring(endsWith + 1);    //başlangıç noktasını bulunan yere taşır

                while (showTable.IndexOf(category + "-") != -1)   //her itemda category- var(writer-)
                {
                    showTable = showTable.Substring(showTable.IndexOf(category + "-"));
                    startsWith = showTable.IndexOf("<a href");
                    showTable = showTable.Substring(startsWith + 1);
                    startsWith = showTable.IndexOf("/title");
                    showTable = showTable.Substring(startsWith);
                    endsWith = showTable.IndexOf("?");

                    showUrl = showTable.Substring(0, endsWith);

                    startsWith = showTable.IndexOf(">");
                    showTable = showTable.Substring(startsWith + 1);
                    endsWith = showTable.IndexOf("<");

                    showName = showTable.Substring(0, endsWith);

                    Movie show = new Movie(showName+" ( "+category+" ) ", showUrl);
                    this.Shows.Add(show);
                }
                
            }
            
        }
    }
}
