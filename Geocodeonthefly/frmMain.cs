using System;
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
                _destinationPath = string.Format(@"{0}\__codeonthefly.csv", browserDialogFindDestination.SelectedPath);
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
                _geocodeService.GenerateGeocodes(_sourcePath, _destinationPath, tboxSeparator.Text[0]);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
