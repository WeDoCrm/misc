using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Elegant.Ui.Samples.ControlsSample
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ControlsNavigationBar = new Elegant.Ui.NavigationBar();
            this.MsgrServerPageToggleButton = new Elegant.Ui.ToggleButton();
            this.MsgrClientPageToggleButton = new Elegant.Ui.ToggleButton();
            this.IPPhonePageToggleButton = new Elegant.Ui.ToggleButton();
            this.KeyPhonePageToggleButton = new Elegant.Ui.ToggleButton();
            this.toggleButton2 = new Elegant.Ui.ToggleButton();
            this.toggleButton1 = new Elegant.Ui.ToggleButton();
            this.FormFrameSkinner = new Elegant.Ui.FormFrameSkinner();
            this.ControlsSamplePageContainer = new Elegant.Ui.Samples.ControlsSample.ControlsSamplePageContainer();
            this.ControlsNavigationBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlsNavigationBar
            // 
            this.ControlsNavigationBar.Controls.Add(this.MsgrServerPageToggleButton);
            this.ControlsNavigationBar.Controls.Add(this.MsgrClientPageToggleButton);
            this.ControlsNavigationBar.Controls.Add(this.IPPhonePageToggleButton);
            this.ControlsNavigationBar.Controls.Add(this.KeyPhonePageToggleButton);
            this.ControlsNavigationBar.Controls.Add(this.toggleButton2);
            this.ControlsNavigationBar.Controls.Add(this.toggleButton1);
            this.ControlsNavigationBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.ControlsNavigationBar.Id = "cba39524-c60d-4bb0-8dcf-15df5e41b782";
            this.ControlsNavigationBar.Location = new System.Drawing.Point(0, 0);
            this.ControlsNavigationBar.Name = "ControlsNavigationBar";
            this.ControlsNavigationBar.Size = new System.Drawing.Size(173, 495);
            this.ControlsNavigationBar.TabIndex = 0;
            this.ControlsNavigationBar.Text = "ControlsNavigationBar";
            this.ControlsNavigationBar.UseTabToNavigate = false;
            this.ControlsNavigationBar.WrapNavigation = false;
            // 
            // MsgrServerPageToggleButton
            // 
            this.MsgrServerPageToggleButton.Id = "2f4d8d5b-6f74-4018-8808-6a45ca0e1451";
            this.MsgrServerPageToggleButton.KeyTip = "13";
            this.MsgrServerPageToggleButton.Location = new System.Drawing.Point(2, 2);
            this.MsgrServerPageToggleButton.Name = "MsgrServerPageToggleButton";
            this.MsgrServerPageToggleButton.RadioGroupName = "NavigationBarToggleButtons";
            this.MsgrServerPageToggleButton.Size = new System.Drawing.Size(169, 24);
            this.MsgrServerPageToggleButton.TabIndex = 17;
            this.MsgrServerPageToggleButton.Text = "메신저 서버";
            this.MsgrServerPageToggleButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MsgrServerPageToggleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // MsgrClientPageToggleButton
            // 
            this.MsgrClientPageToggleButton.Id = "77d61db3-230d-43b5-af56-3bab4c3ad555";
            this.MsgrClientPageToggleButton.KeyTip = "13";
            this.MsgrClientPageToggleButton.Location = new System.Drawing.Point(2, 28);
            this.MsgrClientPageToggleButton.Name = "MsgrClientPageToggleButton";
            this.MsgrClientPageToggleButton.RadioGroupName = "NavigationBarToggleButtons";
            this.MsgrClientPageToggleButton.Size = new System.Drawing.Size(169, 24);
            this.MsgrClientPageToggleButton.TabIndex = 18;
            this.MsgrClientPageToggleButton.Text = "메신저 클라이언트";
            this.MsgrClientPageToggleButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MsgrClientPageToggleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.MsgrClientPageToggleButton.PressedChanged += new System.EventHandler(this.MsgrClientPageToggleButton_PressedChanged);
            // 
            // IPPhonePageToggleButton
            // 
            this.IPPhonePageToggleButton.Id = "7d3afc65-5dad-4fb9-a191-4ef86e8d3ecd";
            this.IPPhonePageToggleButton.KeyTip = "13";
            this.IPPhonePageToggleButton.Location = new System.Drawing.Point(2, 54);
            this.IPPhonePageToggleButton.Name = "IPPhonePageToggleButton";
            this.IPPhonePageToggleButton.RadioGroupName = "NavigationBarToggleButtons";
            this.IPPhonePageToggleButton.Size = new System.Drawing.Size(169, 24);
            this.IPPhonePageToggleButton.TabIndex = 19;
            this.IPPhonePageToggleButton.Text = "IP 폰 연동";
            this.IPPhonePageToggleButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.IPPhonePageToggleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // KeyPhonePageToggleButton
            // 
            this.KeyPhonePageToggleButton.Id = "64628963-75fb-4590-acb8-2e3fc25fb3ee";
            this.KeyPhonePageToggleButton.KeyTip = "13";
            this.KeyPhonePageToggleButton.Location = new System.Drawing.Point(2, 80);
            this.KeyPhonePageToggleButton.Name = "KeyPhonePageToggleButton";
            this.KeyPhonePageToggleButton.RadioGroupName = "NavigationBarToggleButtons";
            this.KeyPhonePageToggleButton.Size = new System.Drawing.Size(169, 24);
            this.KeyPhonePageToggleButton.TabIndex = 22;
            this.KeyPhonePageToggleButton.Text = "키폰 연동";
            this.KeyPhonePageToggleButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.KeyPhonePageToggleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // toggleButton2
            // 
            this.toggleButton2.Id = "0879b485-6711-4352-903f-882881d59afa";
            this.toggleButton2.KeyTip = "13";
            this.toggleButton2.Location = new System.Drawing.Point(2, 106);
            this.toggleButton2.Name = "toggleButton2";
            this.toggleButton2.RadioGroupName = "NavigationBarToggleButtons";
            this.toggleButton2.Size = new System.Drawing.Size(169, 24);
            this.toggleButton2.TabIndex = 21;
            this.toggleButton2.Text = "CID 발신 장치 연동";
            this.toggleButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toggleButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // toggleButton1
            // 
            this.toggleButton1.Id = "1536eb77-3ebd-45c1-aea0-4d7d83d3d672";
            this.toggleButton1.KeyTip = "13";
            this.toggleButton1.Location = new System.Drawing.Point(2, 132);
            this.toggleButton1.Name = "toggleButton1";
            this.toggleButton1.RadioGroupName = "NavigationBarToggleButtons";
            this.toggleButton1.Size = new System.Drawing.Size(169, 24);
            this.toggleButton1.TabIndex = 20;
            this.toggleButton1.Text = "SIP 메시지 분석";
            this.toggleButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toggleButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // FormFrameSkinner
            // 
            this.FormFrameSkinner.Form = this;
            // 
            // ControlsSamplePageContainer
            // 
            this.ControlsSamplePageContainer.ControlsSamplePage = null;
            this.ControlsSamplePageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControlsSamplePageContainer.Location = new System.Drawing.Point(173, 0);
            this.ControlsSamplePageContainer.Name = "ControlsSamplePageContainer";
            this.ControlsSamplePageContainer.Size = new System.Drawing.Size(766, 495);
            this.ControlsSamplePageContainer.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 495);
            this.Controls.Add(this.ControlsSamplePageContainer);
            this.Controls.Add(this.ControlsNavigationBar);
            this.MinimumSize = new System.Drawing.Size(946, 529);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "위두 기능 테스트 툴 v 0.51";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ControlsNavigationBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NavigationBar ControlsNavigationBar;
        private FormFrameSkinner FormFrameSkinner;
        private ControlsSamplePageContainer ControlsSamplePageContainer;
        private ToggleButton MsgrServerPageToggleButton;
        private ToggleButton MsgrClientPageToggleButton;
        private ToggleButton IPPhonePageToggleButton;
        private ToggleButton KeyPhonePageToggleButton;
        private ToggleButton toggleButton2;
        private ToggleButton toggleButton1;
    }
}

