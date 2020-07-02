using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Windows.Forms;

namespace Imdb
{
    public partial class FormMain : Form
    {
        List<Movie> _listmovies;
        public FormMain()
        {
            InitializeComponent();
        }

        public void Findmovie(string txt)  //film isimlerini ve urllerini listeye atar
        {
            WebClient webClient = new WebClient();
            string result = webClient.DownloadString("https://www.imdb.com/find?q=" + txt);

            string movieName,movieUrl;

            int startsWith = result.IndexOf("table");     //filmler <table> ların arasında olduğundan kontrol edilecek data azaltıldı
            int endsWith = result.IndexOf("/table");
            if (startsWith == -1) return;
            string movie_table = result.Substring(startsWith, endsWith - startsWith);


            while (movie_table.IndexOf("result_text") != -1)  // '/title' ile başlayan kısımlar listelenmiş filmleri url leridir. 
            {                                           //Eğer -1 ise aranan filmlerin url leri alınmıştır

                startsWith = movie_table.IndexOf("/title");          //ilk url'in başlangıç noktasını bulur
                movie_table = movie_table.Substring(startsWith + 1);    //başlangıç noktasını bulunan yere taşır

                startsWith = movie_table.IndexOf("/title");          //ikinci url'in başlangıç noktasını bulur ve taşır
                movie_table = movie_table.Substring(startsWith);
                endsWith = movie_table.IndexOf('?');               // url " işaretine kadar olan kısım olduğundan son noktasını buldum

                movieUrl = movie_table.Substring(0, endsWith);  //bulduğumuz url 

                endsWith = movie_table.IndexOf(">");
                movie_table = movie_table.Substring(endsWith + 1);     //filmlerin isimlerini bulabilmek için bulduğumuz yeri çıkarıyoruz
                endsWith = movie_table.IndexOf("<");

                movieName = movie_table.Substring(0, endsWith);

                startsWith = movie_table.IndexOf(">");
                movie_table = movie_table.Substring(startsWith + 1);
                endsWith = movie_table.IndexOf("<");

                movieName += movie_table.Substring(0, endsWith);

                Movie movie = new Movie(movieName, movieUrl);  //movie tipinde bir instance olusturur
                _listmovies.Add(movie);
                
                movie_table = movie_table.Substring(endsWith + 1);
            }
            
        }

        private void Btn_search_Click(object sender, EventArgs e)
        {
            //Movie listbox ına filmleri atar
            lstbxMovie.Items.Clear();

            SqlConnection cnn = new SqlConnection(@"server=.\MSSQLServer01;database=IMDB;trusted_connection=true");

            cnn.Open();

            SqlCommand cmd = new SqlCommand("Select * from Movie where MovieName like '%' + @search + '%'", cnn);
            cmd.Parameters.AddWithValue("@search", txtbx.Text);

            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {

                    Movie movie = new Movie();
                    movie.Name = sdr.GetString(1);
                    movie.MovieId = sdr.GetString(0);
                    movie.Rate = Convert.ToSingle(sdr[2]);
                    movie.Date = Convert.ToDateTime(sdr[3]);
                    movie.Description = sdr.GetString(4);
                    movie.Poster = sdr[5].ToString();

                    lstbxMovie.Items.Add(movie);

                }
                MessageBox.Show("Veritabanından çekilmilştir.");
                sdr.Close();
            }
            else
            {
                sdr.Close();
                _listmovies = new List<Movie>();

                Findmovie(txtbx.Text);

                if (_listmovies == null && txtbx.Text=="")
                {
                    MessageBox.Show("Lütfen aratılacak bir değer giriniz");
                    return;
                }
                else if(_listmovies == null && txtbx.Text != "")
                {
                    MessageBox.Show("Aradıgınız sorgu bulunamamakta");
                    return;
                }
              
                foreach (Movie movie in _listmovies)
                {
                    movie.GetInfo();

                    cmd = new SqlCommand("insert into Movie (MovieID,MovieName,MovieRate,MovieDate,Description,MoviePosterLink) " +
                        "values(@ID,@Name,@Rate,@Date,@Description,@Link)", cnn);
                    cmd.Parameters.AddWithValue("@ID", movie.MovieId);
                    cmd.Parameters.AddWithValue("@Name", movie.Name);
                    cmd.Parameters.AddWithValue("@Rate", movie.Rate);
                    cmd.Parameters.AddWithValue("@Date", movie.Date);
                    cmd.Parameters.AddWithValue("@Description", movie.Description);
                    cmd.Parameters.AddWithValue("@Link",  movie.Poster);
                    cmd.ExecuteNonQuery();

                    lstbxMovie.Items.Add(movie);
                }
                MessageBox.Show("Web sitesinden çekilmilştir.");
            }
            cnn.Close();
        }
        
        private void Lstbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Movie bilgilerinin bulundugu formu acar

            Movie movie = (Movie)lstbxMovie.SelectedItem;
            FormMovie form = new FormMovie();
            form._Movie = movie;
            form.Show();
       
        }

        private void Btn_clear_Click(object sender, EventArgs e)   //ekranı temizlemek için kullanılıyor
        {
            txtbx.Clear();
            lstbxMovie.Items.Clear();
            
        }

        private void BtnX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
