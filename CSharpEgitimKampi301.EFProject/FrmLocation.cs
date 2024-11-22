using CSharpEgitimKampi301.EFProject.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
        AppDbContext context = new AppDbContext();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = context.Locations.ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = context.Guides.Select(x => new
            {
                FullName = x.Name + " " + x.Surname,
                x.Id
            }).ToList();
            cmbGuide.DisplayMember = "FullName";
            cmbGuide.ValueMember = "Id";
            cmbGuide.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location
            {
                Capacity = byte.Parse(nmrCapacity.Value.ToString()),
                City = txtCity.Text,
                Country = txtCountry.Text,
                Price = decimal.Parse(txtPrice.Text),
                DayNight = txtDayNight.Text,
                GuideId = int.Parse(cmbGuide.SelectedValue.ToString())
            };
            context.Locations.Add(location);
            context.SaveChanges();
            MessageBox.Show("Ekleme işlemi başarılı");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var deletedValue = context.Locations.Find(id);
            context.Locations.Remove(deletedValue);
            context.SaveChanges();
            MessageBox.Show("Silme işlemi başarılı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updatedValue = context.Locations.Find(id);
            updatedValue.DayNight = txtDayNight.Text;
            updatedValue.Price = decimal.Parse(txtPrice.Text);
            updatedValue.Capacity = byte.Parse(nmrCapacity.Value.ToString());
            updatedValue.Country = txtCountry.Text;
            updatedValue.City = txtCity.Text;
            updatedValue.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            context.SaveChanges();
            MessageBox.Show("Güncelleme işlemi başarılı");
        }
    }
}
