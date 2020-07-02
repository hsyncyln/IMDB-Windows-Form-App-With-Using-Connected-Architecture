using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imdb
{
    public partial class FormMovie : Form
    {
        public Movie _Movie { get; set; }
 
        public FormMovie()
        {           
            InitializeComponent();
        }

        private void FormMovie_Load(object sender, EventArgs e)
        {   
            this.Text = _Movie.Name;

            rchbxRate.Text = _Movie.Rate.ToString();
            rchbxDescription.Text = _Movie.Description;
            rchbxDate.Text = _Movie.Date.ToString();

            if (_Movie.Poster != "") pbxPoster.Load(_Movie.Poster);
            else pbxPoster.Load("https://us.123rf.com/450wm/pavelstasevich/pavelstasevich1811/pavelstasevich181101065/112815953-stock-vector-no-image-available-icon-flat-vector.jpg?ver=6");

            SqlConnection cnn = new SqlConnection(@"server=.\MSSQLServer01;database=Imdb;trusted_connection=true");

            cnn.Open();

            //Mapping tablosunda seçili filme ait olan var mı

            SqlCommand cmdMap = new SqlCommand("select PersonID,RoleID from MoviePerson where MovieID=@movieId", cnn);
            cmdMap.Parameters.AddWithValue("@movieID", _Movie.MovieId);

            SqlDataReader sdrMap = cmdMap.ExecuteReader();      

            if (sdrMap.HasRows)
            {
                sdrMap.Close();
               
                SqlCommand cmdCast = new SqlCommand("select * from MoviePerson mp inner join Person p " +
                    "on mp.PersonID=p.PersonID where mp.MovieID=@Id", cnn);
                cmdCast.Parameters.AddWithValue("@Id", _Movie.MovieId);

                SqlDataReader sdrCast = cmdCast.ExecuteReader();

                while (sdrCast.Read())
                {
                    Cast cast = new Cast();         
                    cast.CastId = sdrCast.GetString(3);
                    cast.FirstName = sdrCast.GetString(4);
                    cast.LastName = sdrCast.GetString(5);
                    cast.BirthDate = sdrCast.GetDateTime(6);
                    cast.City = sdrCast.GetString(7);
                    cast.State = sdrCast.GetString(8);
                    cast.Country = sdrCast.GetString(9);
                    cast.Description = sdrCast.GetString(10);

                    if (sdrCast.GetInt32(2) == 1) lstbxDirector.Items.Add(cast);
                    else if (sdrCast.GetInt32(2) == 2) lstbxWriter.Items.Add(cast);
                    else if (sdrCast.GetInt32(2) == 3) lstbxStar.Items.Add(cast);          
   
                }
                sdrCast.Close();
            
                SqlCommand cmdGenre = new SqlCommand("select GenreName from MovieGenre mg inner join Genre g " +
                    "on mg.GenreID=g.GenreID where MovieID=@Id", cnn);
                cmdGenre.Parameters.AddWithValue("@ID", _Movie.MovieId);

                SqlDataReader sdrGenre= cmdGenre.ExecuteReader();

                while (sdrGenre.Read())
                {
                    lstbxGenre.Items.Add(sdrGenre[0]);
                }
                sdrGenre.Close();
                MessageBox.Show("Veritabanından çekilmilştir.");
                
            }
            
            else
            {
                sdrMap.Close();

                SqlCommand cmdMovie = new SqlCommand("select * from Movie where MovieID=@Id", cnn);
                cmdMovie.Parameters.AddWithValue("@Id", _Movie.MovieId);

                SqlDataReader sdrMovie = cmdMovie.ExecuteReader();

                if (!sdrMovie.HasRows)
                {
                    sdrMovie.Close();
                   _Movie.GetInfo();

                    SqlCommand cmd = new SqlCommand("insert into Movie (MovieID,MovieName,MovieRate,MovieDate,Description,MoviePosterLink) " +
                        "values(@ID,@Name,@Rate,@Date,@Description,@Link)", cnn);
                    cmd.Parameters.AddWithValue("@ID", _Movie.MovieId);
                    cmd.Parameters.AddWithValue("@Name", _Movie.Name);
                    cmd.Parameters.AddWithValue("@Rate",_Movie.Rate);
                    cmd.Parameters.AddWithValue("@Date", _Movie.Date);
                    cmd.Parameters.AddWithValue("@Description", _Movie.Description);
                    cmd.Parameters.AddWithValue("@Link", _Movie.Poster);
                    cmd.ExecuteNonQuery();

                }
                else sdrMovie.Close();

                _Movie.FindCast();
                //_Movie.FindGenre();

                foreach (Cast cast in _Movie.Casts)
                {
                    SqlCommand cmdPerson = new SqlCommand("select PersonID from Person where PersonID=@Id", cnn);
                    cmdPerson.Parameters.AddWithValue("@Id", cast.CastId);

                    if (cmdPerson.ExecuteScalar().GetType()==typeof(DBNull))
                    {

                        cast.GetInfo();
                        SqlCommand cmdCast = new SqlCommand("insert into Person (PersonID,FirstName,LastName,BirthDate,Description,PosterLink,City,State,Country) " +
                            "values(@PersonID,@FirstName,@LastName,@BirthDate,@Description,@PosterLink,@City,@State,@Country)", cnn);
                        cmdCast.Parameters.AddWithValue("@PersonID", cast.CastId);
                        cmdCast.Parameters.AddWithValue("@FirstName", cast.FirstName);
                        cmdCast.Parameters.AddWithValue("@LastName", cast.LastName);
                        cmdCast.Parameters.AddWithValue("@BirthDate", cast.BirthDate);
                        cmdCast.Parameters.AddWithValue("@Description", cast.Description);
                        cmdCast.Parameters.AddWithValue("@PosterLink", cast.PosterLink);
                        cmdCast.Parameters.AddWithValue("@City", cast.City);
                        cmdCast.Parameters.AddWithValue("@State", cast.State);
                        cmdCast.Parameters.AddWithValue("@Country", cast.Country);

                        cmdCast.ExecuteNonQuery();
                    }
                    foreach(Role role in cast.Roles)
                    {
                        SqlCommand cmdMapping = new SqlCommand("insert into MoviePerson (PersonID,MovieID,RoleID) values(@PersonID,@MovieID,@RoleId)", cnn);

                        cmdMapping.Parameters.AddWithValue("@PersonID", cast.CastId);
                        cmdMapping.Parameters.AddWithValue("@MovieID", _Movie.MovieId);
                        
                        if (role.ToString() == "director")
                        {
                            lstbxDirector.Items.Add(cast);
                            cmdMapping.Parameters.AddWithValue("@RoleID", 1 );
                        }
                        else if (role.ToString() == "writer")
                        {
                            lstbxWriter.Items.Add(cast);
                            cmdMapping.Parameters.AddWithValue("@RoleID", 2);
                        }
                        else if (role.ToString() == "star")
                        {
                            lstbxStar.Items.Add(cast);
                            cmdMapping.Parameters.AddWithValue("@RoleID", 3);
                        }
                        else cmdMapping.Parameters.AddWithValue("@RoleID", 4);

                        cmdMapping.ExecuteNonQuery();
                    }

                }

                SqlCommand cmdGenre = new SqlCommand("select GenreID from MovieGenre where MovieID=@ID", cnn);
                cmdGenre.Parameters.Add("@ID", _Movie.MovieId);

                SqlDataReader sdrGenre = cmdGenre.ExecuteReader();

                if (sdrGenre.HasRows)
                {
                    sdrGenre.Close();

                    SqlCommand cmdGenreMap = new SqlCommand("select g.GenreName,g.Url from MovieGenre mg inner join Genre g " +
                        "on mg.GenreID=g.GenreID where MovieID=@ID", cnn);
                    cmdGenreMap.Parameters.Add("@ID", _Movie.MovieId);

                    SqlDataReader sdrGenreMap = cmdGenreMap.ExecuteReader();

                    while (sdrGenreMap.Read())
                    {
                        Genre genre = new Genre(sdrGenreMap[0].ToString(), sdrGenreMap[1].ToString());
                        _Movie.Genres.Add(genre);
                        lstbxGenre.Items.Add(genre);
                    }
                    sdrGenreMap.Close();
                    MessageBox.Show("Veritabanı");
                }
                else
                {
                    sdrGenre.Close();
                    _Movie.FindGenre();

                    foreach (Genre genre in _Movie.Genres)
                    {
                        SqlCommand cmdGenre1 = new SqlCommand("select GenreID from Genre where GenreName=@name", cnn);
                        cmdGenre1.Parameters.Add("@name", genre.GenreName);

                        SqlDataReader sdrGenre1 = cmdGenre1.ExecuteReader();

                        if (!sdrGenre1.HasRows)
                        {
                            sdrGenre1.Close();


                            SqlCommand cmdGenreMap1 = new SqlCommand("insert into Genre (GenreName,GenreUrl) values (@name,@url)", cnn);
                            cmdGenreMap1.Parameters.Add("@name", genre.GenreName);
                            cmdGenreMap1.Parameters.Add("@url", genre.GenreUrl);

                            cmdGenreMap1.ExecuteNonQuery();
                            MessageBox.Show("New");
                        }
                        else
                        {
                            sdrGenre1.Close();
                        }

                        SqlCommand cmdGenreMap = new SqlCommand("select GenreID from Genre where GenreName=@name", cnn);
                        cmdGenreMap.Parameters.Add("@name", genre.GenreName);

                        string id = cmdGenreMap.ExecuteScalar().ToString();

                        SqlCommand cmdGenreMap2 = new SqlCommand("insert into MovieGenre (MovieID,GenreID) values (@MovieId,@GenreId)", cnn);
                        cmdGenreMap2.Parameters.Add("@GenreID", id);
                        cmdGenreMap2.Parameters.Add("@MovieId", _Movie.MovieId);

                        cmdGenreMap2.ExecuteNonQuery();

                        lstbxGenre.Items.Add(genre);
                        MessageBox.Show("Web");
                    }

                }
   
                MessageBox.Show("Web sitesinden çekilmilştir.");
            }
            cnn.Close();
        }
        private void LstbxStar_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Cast cast = (Cast)lstbxStar.SelectedItem;
            FormCast form = new FormCast();
            form._Cast = cast;
            form.Show();
            
            
        }
        private void LstbxWriter_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Cast cast = (Cast)lstbxWriter.SelectedItem;

            FormCast form = new FormCast();
            form._Cast = cast;
            form.Show();

        }
        private void LstbxDirector_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cast cast = (Cast)lstbxDirector.SelectedItem;

            FormCast form = new FormCast();
            form._Cast = cast;

            form.Show();

        }

        private void TerminateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
