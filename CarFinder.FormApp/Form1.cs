

namespace CarFinder.FormApp
{
    using CarFinder.Services;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Models;
    public partial class MainForm : Form
    {
        private CarFinderService service = new CarFinderService();
        class ComboItem
        {
            public int ID { get; set; }
            public string? Text { get; set; }
        }
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();

            //dt.Columns.Add("ID", typeof(int));
            //dt.Columns.Add("Text");

            //for(int i = 0; i < 283; i++)
            //{
            //    DataRow dr = dt.NewRow();
            //    dr["Text"] = service.GetAllMake()[i].Make;
            //    dr["ID"] = service.GetAllMake()[i].Id;

            //    dt.Rows.Add(dr);
            //}
            ////int a = 0;
            ////while (a <= service.GetAllMake().Count)
            ////{

            ////}

            ////MessageBox.Show(service.GetAllMake()[1].Make);
            //comboBox1.DisplayMember = "Text";
            //comboBox1.ValueMember = "ID";
            //comboBox1.DataSource = dt;
            //comboBox1.SelectedIndex = 0;
        }




        private void SearchForCar(string SearchString)
        {
            try
            {
                dataGridView1.DataSource = service.DetermineGet(SearchString);
                dataGridView1.ReadOnly = true;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[15].Visible = false;
                dataGridView1.Columns[20].Visible = false;
                dataGridView1.Columns[21].Visible = false;
                dataGridView1.Columns[22].Visible = false;
                dataGridView1.Columns[23].Visible = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }







        private void btnPrevious_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }


        private void btnInsert_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchForCar(textBox1.Text);
            //service.DetermineGet();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string trim = row.Cells["Trim"].Value.ToString() ?? throw new ArgumentException("");
                string make = row.Cells["Make"].Value.ToString() ?? throw new ArgumentException("");
                string model = row.Cells["Model"].Value.ToString() ?? throw new ArgumentException("");
                string generation = row.Cells["Generation"].Value.ToString() ?? throw new ArgumentException("");
                string body = row.Cells["Body"].Value.ToString() ?? throw new ArgumentException("");
                string drive = row.Cells["Drive"].Value.ToString() ?? throw new ArgumentException("");
                string gearbox = row.Cells["Gearbox"].Value.ToString() ?? throw new ArgumentException("");
                string engineType = row.Cells["Engine_type"].Value.ToString() ?? throw new ArgumentException("");
                string engineVolume = row.Cells["Engine_Volume"].Value.ToString() ?? throw new ArgumentException("");
                string enginePower = row.Cells["Engine_power"].Value.ToString() ?? throw new ArgumentException("");
                string year = row.Cells["Year"].Value.ToString() ?? throw new ArgumentException("");
                string img = row.Cells["Image"].Value.ToString() ?? throw new ArgumentException("");
                //MessageBox.Show(engineType + engineVolume + enginePower);
                Form2 form2 = new Form2();
                form2.GetParams(trim, make, model, generation, body, drive, gearbox, engineType, engineVolume, enginePower, year, img);
                form2.ShowDialog();
                //form2.PassParams(trim, make, model, generation);
                //string name = dataGridView1.Rows[1]["trim"].ToString();
                //string description = row["description"].ToString();
                //string icoFileName = row["iconFile"].ToString();
                //string installScript = row["installScript"].ToString();

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label4.Text);
        }
    }
}
