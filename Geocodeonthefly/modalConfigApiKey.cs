using System;
using System.Windows.Forms;

namespace Geocodeonthefly
{
    public partial class ModalConfigApiKey : Form
    {
        public ModalConfigApiKey()
        {
            InitializeComponent();
            txtBoxApiKey.Text = Helpers.GetAppSetting("gmaps-api-key");
        }

        private void btnSaveApiKey_Click(object sender, EventArgs e)
        {
            Helpers.SetAppSetting("gmaps-api-key", txtBoxApiKey.Text);
            this.Close();
        }
    }
}
