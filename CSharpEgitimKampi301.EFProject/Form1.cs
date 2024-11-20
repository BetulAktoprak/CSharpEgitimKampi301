using CSharpEgitimKampi301.EFProject.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        AppDbContext _context = new AppDbContext();

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = _context.Guides.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Guide guide = new Guide();
            guide.Name = txtName.Text;
            guide.Surname = txtSurname.Text;
            _context.Guides.Add(guide);
            _context.SaveChanges();
            MessageBox.Show("Rehber başarıyla eklendi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var removeValue = _context.Guides.Find(id);
            _context.Guides.Remove(removeValue);
            _context.SaveChanges();
            MessageBox.Show("Rehber başarıyla silindi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updateValue = _context.Guides.Find(id);
            updateValue.Name = txtName.Text;
            updateValue.Surname = txtSurname.Text;
            _context.SaveChanges();
            MessageBox.Show("Rehber başarıyla güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var values = _context.Guides.Where(x => x.Id == id).ToList();
            dataGridView1.DataSource = values;
        }
    }
}
