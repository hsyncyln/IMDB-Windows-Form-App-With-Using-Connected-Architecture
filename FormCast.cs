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
    public partial class FormCast : Form
    {
        public Cast _Cast { get; set; }

        public FormCast()
        {
            InitializeComponent();
        }
       
        private void FormCast_Load(object sender, EventArgs e)
        {
            
            this.Text = _Cast.FirstName + " " + _Cast.LastName;
            rchbxBornInfo.Text = _Cast.BirthDate + " in " + _Cast.City + " " + _Cast.State + " " + _Cast.Country;
            rchbxCastDesc.Text = _Cast.Description;

            _Cast.CastShows();

            foreach (Movie show in _Cast.Shows)
            {
                lstbxShows.Items.Add(show);
            }

            if (_Cast.PosterLink!= null) pbxCastPoster.Load(_Cast.PosterLink);
            else pbxCastPoster.Load("https://us.123rf.com/450wm/pavelstasevich/pavelstasevich1811/pavelstasevich181101065/112815953-stock-vector-no-image-available-icon-flat-vector.jpg?ver=6");

            
        }

        private void LstbxShows_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormMovie form = new FormMovie();
            form._Movie = (Movie)lstbxShows.SelectedItem;
            form._Movie.GetInfo();
            
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
