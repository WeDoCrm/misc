using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Elegant.Ui.Samples.ControlsSample
{
    public partial class PopupTopMostForm : Form
    {
        public PopupTopMostForm()
        {
            InitializeComponent();
        }

        private void PopupTopMostForm_Activated(object sender, EventArgs e)
        {
            Console.WriteLine("Activated:" + TopMost);
        }

        protected override bool ShowWithoutActivation
        {
            get {
                Console.WriteLine("ShowWithoutActivation");

                return true; }
        }

          public void ShowPopUp()
        {
            Console.WriteLine("ShowPopUp:" + TopMost);
            TopMost = true;
            //TopLevel = true;
            Show();
        }

        private void PopupTopMostForm_Deactivate(object sender, EventArgs e)
        {
            //if (Owner == null || ! Owner. )
            //    return;
            //bool hasActiveWindow = false;
            //foreach (Form ownedWindow in Owner.OwnedForms)
            //{
            //    if (ownedWindow.WindowState)
            //        hasActiveWindow = true;
            //}

            //if (!hasActiveWindow)
                TopMost = false;
            //TopLevel = false;
                Console.WriteLine("Deactivated:" + TopMost);
        }

        private void PopupTopMostForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            this.Owner.BringToFront();
            e.Cancel = true;
        }

       

    }
}
