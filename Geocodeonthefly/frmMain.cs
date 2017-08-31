using System;
using System.Windows.Forms;

namespace Geocodeonthefly
{
    public partial class frmMain : Form
    {
        private Services.GeocodeService _geocodeService;

        public frmMain()
        {
            InitializeComponent();
            _geocodeService = new Services.GeocodeService();
        }

        private async void btnFind_Click(object sender, EventArgs e)
        {
            if (openFileDialogCsv.ShowDialog() == DialogResult.OK)
            {
                string sourcePath = openFileDialogCsv.FileName;
                string destinationPath = "C:\\__codeonthefly.csv";

                tboxFileLocation.Text = sourcePath;
                await _geocodeService.GenerateGeocodes(sourcePath, destinationPath);
            }
        }
    }
}
