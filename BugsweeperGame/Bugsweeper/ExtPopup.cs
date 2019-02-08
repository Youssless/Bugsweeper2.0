using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bugsweeper
{
    public partial class ExtPopup : Form
    {
        private string popupTitle;
        private string popupMsg;

        public ExtPopup()
        {
            InitializeComponent();
            popupMsg = "Default";
            popupTitle = "Default";
        }

        public ExtPopup(string popupTitle, string popupMsg) {
            InitializeComponent();
            this.popupTitle = popupTitle;
            this.popupMsg = popupMsg;
        }

        private void Popup_Load(object sender, EventArgs e)
        {
            Text = popupTitle;
            this.BackColor = Color.GhostWhite;
            msgBox.Text = popupMsg;
            msgBox.SelectionStart = 0;
            msgBox.ReadOnly = true;
            msgBox.BackColor = Color.GhostWhite;
        }

        private void msgBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void BtnPlayAgain(object sender, EventArgs e)
        {

        }

        private void BtnMainMenu(object sender, EventArgs e)
        {

        }
    }
}
