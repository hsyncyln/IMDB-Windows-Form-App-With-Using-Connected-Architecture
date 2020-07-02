using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Imdb
{
    public class Movie
    {

        public string Name { get; set; }
        public string MovieId { get; set; }
        public List<Cast> Casts { get; set; }
        public List<Genre> Genres { get; set; }
        public float Rate { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }

        public Movie()
        {
            this.Casts = new List<Cast>();
            this.Genres = new List<Genre>();
        }
        public Movie(string movieName, string movieId)
        {
            this.Name = movieName;
            this.MovieId = movieId;
            
        }
        public void GetInfo()
        {
            this.Casts = new List<Cast>();
            this.Genres = new List<Genre>();
            this.Rate = FindRate();
            this.Date = FindDate();
            this.Description = FindDscrptn();
            this.Poster = FindPoster();
        }
        public override string ToString()
        {
            return this.Name;
        }
        private float FindRate()   //filmin puanını bulup geriye döndüren fonksiyon
        {
            WebClient webClient = new WebClient();
            string result = webClient.DownloadString("https://www.imdb.com" + this.MovieId);

            int startsWith = result.IndexOf("ratingValue");
            if (startsWith == -1) return 0;
            result = result.Substring(startsWith);

            startsWith = result.IndexOf('"');             //ratinValueden sonra bir tane " var onu taşımalıyız
            result = result.Substring(startsWith + 1);

            startsWith = result.IndexOf('"');
            result = result.Substring(startsWith + 1);  //ondan sonraki iki " arasında rate yazıyor
            int endsWith = result.IndexOf('"');

            return Convert.ToSingle(result.Substring(0, endsWith));
        }
        private string FindDscrptn()  //filmin descriptionunu bulup geriye döndüren fonksiyon
        {
            WebClient webClient = new WebClient();
            string result = webClient.DownloadString("https://www.imdb.com/" + this.MovieId);

            int starts_with, ends_with;
            starts_with = result.IndexOf("summary_text");
            if (starts_with == -1) return "---None---";  //description yoksa richtextbox a none yazar
            result = result.Substring(starts_with);
            ends_with = result.IndexOf(">");           //summary_text ten sonraki > ile < arasında description bulunur
            result = result.Substring(ends_with + 1);
            ends_with = result.IndexOf("<");

            return result.Substring(0, ends_with);

        }
        private DateTime FindDate()  //filmin yayına girme tarihini geriye döndürür
        {
            WebClient webClient = new WebClient();
            string result = webClient.DownloadString("https://www.imdb.com/" + this.MovieId);

            int startsWith = result.IndexOf("datePublished");
            if (startsWith == -1) return Convert.ToDateTime("1/1/1753");
            result = result.Substring(startsWith);

            startsWith = result.IndexOf('"');             //datepublishedden sonra bir tane " var onu taşımalıyız
            result = result.Substring(startsWith + 1);

            startsWith = result.IndexOf('"');
            result = result.Substring(startsWith + 1);  //ondan sonraki iki " arasında date yazıyor
            int endsWith = result.IndexOf('"');
            if (Convert.ToDateTime(result.Substring(0, endsWith)).Year < 1753) Convert.ToDateTime("1/1/1753");
            return Convert.ToDateTime(result.Substring(0, endsWith));
        }
        private string FindPoster()
        {

            WebClient webClient = new WebClient();
            string result = webClient.DownloadString("https://www.imdb.com/" + this.MovieId);

            int startsWith = result.IndexOf("slate_wrapper");
            if (startsWith == -1) return "";
            result = result.Substring(startsWith);

            startsWith = result.IndexOf("src");
            result = result.Substring(startsWith + 1);

            startsWith = result.IndexOf('"');
            result = result.Substring(startsWith + 1);
            int endsWith = result.IndexOf('"');

            return result.Substring(0, endsWith);
        }
        
        public void FindGenre()
        {
            WebClient webClient = new WebClient();
            string result = webClient.DownloadString("https://www.imdb.com/" + this.MovieId);

            int startsWith = result.IndexOf("titleYear");
            if (startsWith == -1) return ;
            result = result.Substring(startsWith);
            int endsWith = result.IndexOf("</div>");
            result = result.Substring(0, endsWith);

            string name, url;

            startsWith = result.IndexOf("<a href=");
            result = result.Substring(startsWith);
            endsWith = result.IndexOf(">");
            result = result.Substring(endsWith);

            result = result.Substring(startsWith + 1);
 
            while (result.IndexOf("genre") != -1)
            {
                startsWith = result.IndexOf("<a href=");
                result = result.Substring(startsWith);
                endsWith = result.IndexOf("/");
                result = result.Substring(endsWith);
                endsWith = result.IndexOf('"');

                url = result.Substring(0, endsWith);

                endsWith = result.IndexOf(">");
                result = result.Substring(endsWith+1);
                endsWith = result.IndexOf("<");

                name = result.Substring(0,endsWith);

                Genre genre = new Genre(name, url);
                this.Genres.Add(genre);
               
            }

        }
        
        public void FindCast()     //filmin castını bulan method
        {
            WebClient webClient = new WebClient();
            string result = webClient.DownloadString("https://www.imdb.com/" + this.MovieId);
             
             Boolean control=false;                  //ayn isim var mı kontrolunde kullanılıyor
            string roleResult,castUrl;
            string name, role = "";

            int startsWith = result.IndexOf("credit_summary_item");  //herbir castın başında bu item olduğundan başlangıç noktası bu olarak alınır
            result = result.Substring(startsWith);
            int endsWith = result.IndexOf("<script>");
            result = result.Substring(0, endsWith);

            while (result.IndexOf("credit_summary_item") != -1)  //"credit_summary_item" bulamadığında döngü sonlanır
            {
                startsWith = result.IndexOf("credit_summary_item");
                result = result.Substring(startsWith);
                endsWith = result.IndexOf("/div");
                roleResult = result.Substring(0, endsWith);
                result = result.Substring(endsWith);

                if (roleResult.IndexOf("Director") != -1)  role = "Director";
                else if (roleResult.IndexOf("Writer") != -1) role = "Writer";
                else if (roleResult.IndexOf("Star") != -1)  role = "Star";
                    
                roleResult = roleResult.Substring(roleResult.IndexOf(role));
                
                do                     //aynı role içinde birden fazla kişi varsa diye ilki ismi yazıp , varsa devam eder
                {
                    endsWith = roleResult.IndexOf(">");
                    roleResult = roleResult.Substring(endsWith + 1);

                    startsWith = roleResult.IndexOf('"');
                    roleResult = roleResult.Substring(startsWith + 1);
                    endsWith = roleResult.IndexOf('?');
                    castUrl = roleResult.Substring(0, endsWith); // castın url i

                    //iki kez >(tag kapama) geçtikten sonra castın ismi vardır

                    startsWith = roleResult.IndexOf(">");
                    roleResult = roleResult.Substring(startsWith + 1);
                    endsWith = roleResult.IndexOf("<");

                    name = roleResult.Substring(0, endsWith);            //tag kapama ile tag açma arasındaki string cast ismidir
                    name=name.Replace("Ã¶", "ö");

                    roleResult = roleResult.Substring(endsWith + 1);

                    Role role1 = Role.none;
                    if (role == "Director" || role=="Creator") role1 = Role.director;
                    else if (role == "Writer") role1 = Role.writer;
                    else if (role == "Star") role1 = Role.star;

                    for (int i = 0; i < Casts.Count; i++)           //aynı kişi varsa sadece rolüne ekleme yapar
                    {
                        if (Casts[i].CastId==castUrl)
                        {
                            Casts[i].Roles.Add(role1);
                            control = true;                    //aynı kisi varsa kontrolunu yapar
                            break;
                        }
                    }
                    if (control == false)
                    {
                        string first = name;
                        string last="";
                        if(name.Contains(" "))
                        {
                            first = name.Substring(0, name.IndexOf(" "));
                            last = name.Substring(name.IndexOf(" ") + 1);
                           
                        } 
                        
                        Cast cast = new Cast(first, last , castUrl);
                        cast.GetInfo();
                        cast.Roles.Add(role1);

                        Casts.Add(cast);
                    }
                }
                while (roleResult.IndexOf(",") != -1);

                control = false;
            }
            
        }
    }
}
