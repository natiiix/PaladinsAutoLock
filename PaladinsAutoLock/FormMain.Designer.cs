namespace PaladinsAutoLock
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.pictureBoxChampionSelect = new System.Windows.Forms.PictureBox();
            this.timerCheckScreen = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChampionSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxChampionSelect
            // 
            this.pictureBoxChampionSelect.Image = global::PaladinsAutoLock.Properties.Resources.ChampionSelectionBitmap;
            this.pictureBoxChampionSelect.InitialImage = null;
            this.pictureBoxChampionSelect.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxChampionSelect.Name = "pictureBoxChampionSelect";
            this.pictureBoxChampionSelect.Size = new System.Drawing.Size(1120, 720);
            this.pictureBoxChampionSelect.TabIndex = 0;
            this.pictureBoxChampionSelect.TabStop = false;
            this.pictureBoxChampionSelect.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxChampionSelect_MouseClick);
            // 
            // timerCheckScreen
            // 
            this.timerCheckScreen.Tick += new System.EventHandler(this.timerCheckScreen_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 720);
            this.Controls.Add(this.pictureBoxChampionSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.Text = "Paladins Auto Lock";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChampionSelect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxChampionSelect;
        private System.Windows.Forms.Timer timerCheckScreen;
    }
}

