using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarFinder.FormApp
{
    public partial class Form2 : Form
    {
        public string Trim = "";
        public string Make = "";
        public string Model = "";
        public string Generation = "";
        public string Body = "";
        public string Drive = "";
        public string Gearbox = "";
        public string EngineType = "";
        public string EngineVolume = "";
        public string EnginePower = "";
        public string Year = "";
        public string Img = "https://info-km.com/api/GoogleAPI/fetchGoogleAPI.php?img=";
        //public string Img = "http://www.regcheck.org.uk/image.aspx/@";

        public void GetParams(string trim, string make, string model, string generation, string body, string drive, string gearbox, string enginetype, string enginevolume, string enginepower, string year, string img)
        {
            Trim = trim;
            Make = make;
            Model = model;
            Generation = generation;
            Body = body;
            Drive = drive;
            Gearbox = gearbox;
            EngineType = enginetype;
            EngineVolume = enginevolume;
            EnginePower = enginepower;
            Year = year;
            Img = Img + img);
            //Img = Img + Convert.ToBase64String(Encoding.UTF8.GetBytes(img));
            //MessageBox.Show(trim);
        }
        static public void fillPictureBox(PictureBox pbox, Bitmap bmp)
        {
            pbox.SizeMode = PictureBoxSizeMode.Normal;
            bool source_is_wider = (float)bmp.Width / bmp.Height > (float)pbox.Width / pbox.Height;

            var resized = new Bitmap(pbox.Width, pbox.Height);
            var g = Graphics.FromImage(resized);
            var dest_rect = new Rectangle(0, 0, pbox.Width, pbox.Height);
            Rectangle src_rect;

            if (source_is_wider)
            {
                float size_ratio = (float)pbox.Height / bmp.Height;
                int sample_width = (int)(pbox.Width / size_ratio);
                src_rect = new Rectangle((bmp.Width - sample_width) / 2, 0, sample_width, bmp.Height);
            }
            else
            {
                float size_ratio = (float)pbox.Width / bmp.Width;
                int sample_height = (int)(pbox.Height / size_ratio);
                src_rect = new Rectangle(0, (bmp.Height - sample_height) / 2, bmp.Width, sample_height);
            }

            g.DrawImage(bmp, dest_rect, src_rect, GraphicsUnit.Pixel);
            g.Dispose();

            pbox.Image = resized;
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            labeltrim.Text = Trim;
            labelmake.Text = Make;
            labelmodel.Text = Model;
            labelgeneration.Text = Generation;
            labelbody.Text = Body;
            labeldrive.Text = Drive;
            labelgearbox.Text = Gearbox;
            labelenginetype.Text = EngineType;
            labelenginevolume.Text = EngineVolume;
            labelenginepower.Text = EnginePower;
            labelyear.Text = Year;

            var request = WebRequest.Create(Img);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                Bitmap bmp = new Bitmap(Bitmap.FromStream(stream));
                fillPictureBox(pictureBox1, bmp);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
