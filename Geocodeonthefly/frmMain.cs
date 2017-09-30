using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geocodeonthefly
{
    public partial class FrmMain : Form
    {
        private Services.GeocodeService _geocodeService;
        private string _destinationPath;
        private string _sourcePath;

        public FrmMain()
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
            if (saveFileDialogDestination.ShowDialog() == DialogResult.OK)
            {
                _destinationPath = saveFileDialogDestination.FileName;
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

                await Task.Run(async () =>
                {
                    await _geocodeService.GenerateGeocodes(_sourcePath, _destinationPath);
                });

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

        private void aPIKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var modal = new ModalConfigApiKey();
            modal.ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogExcelModel.ShowDialog() == DialogResult.OK)
            {
                var sourceFilePath = string.Format(@"{0}/Resources/model.xlsx", Helpers.appPath);
                var destinationPath = string.Format(@"{0}/geocodeonthefly_model.xlsx", folderBrowserDialogExcelModel.SelectedPath);
                File.Copy(sourceFilePath, destinationPath, true);

                MessageBox.Show(@"File ""geocodeonthefly_model.xlsx"" was saved in the selected folder!", "File saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
