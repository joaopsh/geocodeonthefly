using System;
using System.Net;
using System.Windows.Forms;

namespace Geocodeonthefly
{
    public partial class frmMain : Form
    {
        private Services.GeocodeService _geocodeService;
        private string _destinationPath;
        private string _sourcePath;

        public frmMain()
        {
            InitializeComponent();
            _geocodeService = new Services.GeocodeService();

            // Setup of how many concurrent requests the application is allowed to make with HttpClient.
            ServicePointManager.DefaultConnectionLimit = 50;

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (openFileDialogCsv.ShowDialog() == DialogResult.OK)
            {
                _sourcePath = openFileDialogCsv.FileName;
                tboxSourceFileLocation.Text = _sourcePath;
            }
        }

        private void btnFindDestinationLocation_Click(object sender, EventArgs e)
        {
            if (browserDialogFindDestination.ShowDialog() == DialogResult.OK)
            {
                _destinationPath = string.Format(@"{0}\__codeonthefly.xlsx", browserDialogFindDestination.SelectedPath);
                tboxDestinationFileLocation.Text = _destinationPath;
            }
        }

        private async void btnGo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_sourcePath) || string.IsNullOrWhiteSpace(_sourcePath))
            {
                MessageBox.Show("You must select the source file and output destination!");
                return;
            }

            try
            {
                btnGo.Enabled = false;
                btnFindDestinationLocation.Enabled = false;
                btnFindSourceFile.Enabled = false;
                btnGo.Text = "Working...";
                
                await _geocodeService.GenerateGeocodes(_sourcePath, _destinationPath);

                btnGo.Enabled = true;
                btnFindDestinationLocation.Enabled = true;
                btnFindSourceFile.Enabled = true;
                _destinationPath = string.Empty;
                _sourcePath = string.Empty;
                tboxDestinationFileLocation.Text = string.Empty;
                tboxSourceFileLocation.Text = string.Empty;
                btnGo.Text = "Go!";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
