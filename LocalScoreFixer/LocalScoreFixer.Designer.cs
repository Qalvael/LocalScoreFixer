namespace LocalScoreFixer
{
    partial class LocalScoreFixer
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.ofdPlayerData = new System.Windows.Forms.OpenFileDialog();
            this.fbdCustomSongs = new System.Windows.Forms.FolderBrowserDialog();
            this.lblFolder = new System.Windows.Forms.Label();
            this.lblPlayerData = new System.Windows.Forms.Label();
            this.lblSongHashData = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btnFolder = new System.Windows.Forms.Button();
            this.btnPlayerData = new System.Windows.Forms.Button();
            this.ofdSongHashData = new System.Windows.Forms.OpenFileDialog();
            this.btnSongHashData = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblHintFiles = new System.Windows.Forms.Label();
            this.lblHintFolder = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(233, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(214, 33);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Local Score Fixer";
            // 
            // ofdPlayerData
            // 
            this.ofdPlayerData.FileName = "PlayerData*";
            this.ofdPlayerData.Filter = "Dat Files|*.dat";
            // 
            // fbdCustomSongs
            // 
            this.fbdCustomSongs.ShowNewFolderButton = false;
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(3, 10);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(155, 13);
            this.lblFolder.TabIndex = 1;
            this.lblFolder.Text = "Specify the custom song folder:";
            // 
            // lblPlayerData
            // 
            this.lblPlayerData.AutoSize = true;
            this.lblPlayerData.Location = new System.Drawing.Point(3, 66);
            this.lblPlayerData.Name = "lblPlayerData";
            this.lblPlayerData.Size = new System.Drawing.Size(152, 13);
            this.lblPlayerData.TabIndex = 2;
            this.lblPlayerData.Text = "Select your PlayerData.dat file:";
            // 
            // lblSongHashData
            // 
            this.lblSongHashData.AutoSize = true;
            this.lblSongHashData.Location = new System.Drawing.Point(3, 95);
            this.lblSongHashData.Name = "lblSongHashData";
            this.lblSongHashData.Size = new System.Drawing.Size(173, 13);
            this.lblSongHashData.TabIndex = 3;
            this.lblSongHashData.Text = "Select your SongHashData.dat file:";
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(186, 7);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.ReadOnly = true;
            this.txtFolder.Size = new System.Drawing.Size(376, 20);
            this.txtFolder.TabIndex = 4;
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(568, 5);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(75, 23);
            this.btnFolder.TabIndex = 5;
            this.btnFolder.Text = "Browse";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // btnPlayerData
            // 
            this.btnPlayerData.Location = new System.Drawing.Point(186, 61);
            this.btnPlayerData.Name = "btnPlayerData";
            this.btnPlayerData.Size = new System.Drawing.Size(75, 23);
            this.btnPlayerData.TabIndex = 6;
            this.btnPlayerData.Text = "Select";
            this.btnPlayerData.UseVisualStyleBackColor = true;
            this.btnPlayerData.Click += new System.EventHandler(this.btnPlayerData_Click);
            // 
            // ofdSongHashData
            // 
            this.ofdSongHashData.FileName = "SongHashData*";
            this.ofdSongHashData.Filter = "Dat Files|*.dat";
            // 
            // btnSongHashData
            // 
            this.btnSongHashData.Location = new System.Drawing.Point(186, 90);
            this.btnSongHashData.Name = "btnSongHashData";
            this.btnSongHashData.Size = new System.Drawing.Size(75, 23);
            this.btnSongHashData.TabIndex = 7;
            this.btnSongHashData.Text = "Select";
            this.btnSongHashData.UseVisualStyleBackColor = true;
            this.btnSongHashData.Click += new System.EventHandler(this.btnSongHashData_Click);
            // 
            // btnGo
            // 
            this.btnGo.Enabled = false;
            this.btnGo.Location = new System.Drawing.Point(33, 157);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 8;
            this.btnGo.Text = "GO!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblHintFolder);
            this.panel1.Controls.Add(this.lblHintFiles);
            this.panel1.Controls.Add(this.txtStatus);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.lblFolder);
            this.panel1.Controls.Add(this.btnGo);
            this.panel1.Controls.Add(this.txtFolder);
            this.panel1.Controls.Add(this.btnSongHashData);
            this.panel1.Controls.Add(this.btnFolder);
            this.panel1.Controls.Add(this.lblSongHashData);
            this.panel1.Controls.Add(this.btnPlayerData);
            this.panel1.Controls.Add(this.lblPlayerData);
            this.panel1.Location = new System.Drawing.Point(12, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 193);
            this.panel1.TabIndex = 9;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(186, 159);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(457, 20);
            this.txtStatus.TabIndex = 10;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(136, 162);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Status:";
            // 
            // lblHintFiles
            // 
            this.lblHintFiles.AutoSize = true;
            this.lblHintFiles.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblHintFiles.Location = new System.Drawing.Point(1, 116);
            this.lblHintFiles.Name = "lblHintFiles";
            this.lblHintFiles.Size = new System.Drawing.Size(642, 13);
            this.lblHintFiles.TabIndex = 11;
            this.lblHintFiles.Text = "(Hint: PlayerData and SongHashData can be found in C:\\Users\\<username>\\AppData\\Lo" +
    "calLow\\Hyperbolic Magnetism\\Beat Saber\\)";
            // 
            // lblHintFolder
            // 
            this.lblHintFolder.AutoSize = true;
            this.lblHintFolder.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblHintFolder.Location = new System.Drawing.Point(3, 31);
            this.lblHintFolder.Name = "lblHintFolder";
            this.lblHintFolder.Size = new System.Drawing.Size(425, 13);
            this.lblHintFolder.TabIndex = 12;
            this.lblHintFolder.Text = "(Hint: This can be found at <Beat Saber install folder>\\Beat Saber_Data\\CustomLev" +
    "els\\)";
            // 
            // LocalScoreFixer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(684, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitle);
            this.Name = "LocalScoreFixer";
            this.Text = "Local Score Fixer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.OpenFileDialog ofdPlayerData;
        private System.Windows.Forms.FolderBrowserDialog fbdCustomSongs;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.Label lblPlayerData;
        private System.Windows.Forms.Label lblSongHashData;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.Button btnPlayerData;
        private System.Windows.Forms.OpenFileDialog ofdSongHashData;
        private System.Windows.Forms.Button btnSongHashData;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblHintFiles;
        private System.Windows.Forms.Label lblHintFolder;
    }
}

