using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        AppDbContext context = new AppDbContext();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = context.Locations.Count().ToString();

            lblSumCapacity.Text = context.Locations.Sum(x => x.Capacity).ToString();

            lblGuideCount.Text = context.Guides.Count().ToString();

            lblAvgCapacity.Text = Math.Round(context.Locations.Average(x => x.Capacity)).ToString();

            lblAvgLocationPrice.Text = Math.Round(context.Locations.Average(x => x.Price), 2).ToString("C", new CultureInfo("tr-TR"));

            int lastLocationId = context.Locations.Max(x => x.Id);
            lblLastLocationName.Text = context.Locations.Where(x => x.Id == lastLocationId).Select(y => y.City).FirstOrDefault();

            lblCappadociaLocationCapacity.Text = context.Locations.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();

            lblTurkeyCapacityAvg.Text = Math.Round(context.Locations.Where(x => x.Country == "Türkiye").Average(y => y.Capacity)).ToString();

            int romaGuideId = context.Locations.Where(x => x.City == "Roma Turistik").Select(y => y.GuideId).FirstOrDefault();
            lblRomaGuideName.Text = context.Guides.Where(x => x.Id == romaGuideId).Select(y => y.Name + " " + y.Surname).FirstOrDefault().ToString();

            var maxCapacity = context.Locations.Max(x => x.Capacity);
            lblMaxCapacityLocation.Text = context.Locations.Where(x => x.Capacity == maxCapacity).Select(y => y.City).FirstOrDefault();

            var minPrice = context.Locations.Min(x => x.Price);
            lblMinPriceLocation.Text = context.Locations.Where(x => x.Price == minPrice).Select(y => y.City).FirstOrDefault();

            var guideIdByName = context.Guides.Where(x => x.Name == "Ayşegül" && x.Surname == "Çınar").Select(y => y.Id).FirstOrDefault();
            lblGuideNameLocationCount.Text = context.Locations.Where(x => x.GuideId == guideIdByName).Count().ToString();
        }
    }
}
