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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblHintFolder = new System.Windows.Forms.Label();
            this.lblHintFiles = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.radModeScores = new System.Windows.Forms.RadioButton();
            this.radModePlaylists = new System.Windows.Forms.RadioButton();
            this.lblMode = new System.Windows.Forms.Label();
            this.btnPlaylist = new System.Windows.Forms.Button();
            this.lblPlaylist = new System.Windows.Forms.Label();
            this.ofdPlaylist = new System.Windows.Forms.OpenFileDialog();
            this.lblHintPlaylist = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
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
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGo.Enabled = false;
            this.btnGo.Location = new System.Drawing.Point(33, 232);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 8;
            this.btnGo.Text = "GO!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.Window;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.lblHintPlaylist);
            this.pnlMain.Controls.Add(this.btnPlaylist);
            this.pnlMain.Controls.Add(this.lblPlaylist);
            this.pnlMain.Controls.Add(this.lblMode);
            this.pnlMain.Controls.Add(this.radModePlaylists);
            this.pnlMain.Controls.Add(this.radModeScores);
            this.pnlMain.Controls.Add(this.lblHintFolder);
            this.pnlMain.Controls.Add(this.lblHintFiles);
            this.pnlMain.Controls.Add(this.txtStatus);
            this.pnlMain.Controls.Add(this.lblStatus);
            this.pnlMain.Controls.Add(this.lblFolder);
            this.pnlMain.Controls.Add(this.btnGo);
            this.pnlMain.Controls.Add(this.txtFolder);
            this.pnlMain.Controls.Add(this.btnSongHashData);
            this.pnlMain.Controls.Add(this.btnFolder);
            this.pnlMain.Controls.Add(this.lblSongHashData);
            this.pnlMain.Controls.Add(this.btnPlayerData);
            this.pnlMain.Controls.Add(this.lblPlayerData);
            this.pnlMain.Location = new System.Drawing.Point(12, 56);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(660, 268);
            this.pnlMain.TabIndex = 9;
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
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtStatus.Location = new System.Drawing.Point(186, 234);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(457, 20);
            this.txtStatus.TabIndex = 10;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(136, 237);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Status:";
            // 
            // radModeScores
            // 
            this.radModeScores.AutoSize = true;
            this.radModeScores.Checked = true;
            this.radModeScores.Location = new System.Drawing.Point(186, 144);
            this.radModeScores.Name = "radModeScores";
            this.radModeScores.Size = new System.Drawing.Size(126, 17);
            this.radModeScores.TabIndex = 13;
            this.radModeScores.TabStop = true;
            this.radModeScores.Text = "High Scores/Combos";
            this.radModeScores.UseVisualStyleBackColor = true;
            this.radModeScores.CheckedChanged += new System.EventHandler(this.radModeScores_CheckedChanged);
            // 
            // radModePlaylists
            // 
            this.radModePlaylists.AutoSize = true;
            this.radModePlaylists.Location = new System.Drawing.Point(318, 144);
            this.radModePlaylists.Name = "radModePlaylists";
            this.radModePlaylists.Size = new System.Drawing.Size(100, 17);
            this.radModePlaylists.TabIndex = 14;
            this.radModePlaylists.Text = "Custom Playlists";
            this.radModePlaylists.UseVisualStyleBackColor = true;
            this.radModePlaylists.CheckedChanged += new System.EventHandler(this.radModePlaylists_CheckedChanged);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(3, 146);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(125, 13);
            this.lblMode.TabIndex = 15;
            this.lblMode.Text = "What do you want to fix?";
            // 
            // btnPlaylist
            // 
            this.btnPlaylist.Location = new System.Drawing.Point(186, 176);
            this.btnPlaylist.Name = "btnPlaylist";
            this.btnPlaylist.Size = new System.Drawing.Size(75, 23);
            this.btnPlaylist.TabIndex = 17;
            this.btnPlaylist.Text = "Select";
            this.btnPlaylist.UseVisualStyleBackColor = true;
            this.btnPlaylist.Click += new System.EventHandler(this.btnPlaylist_Click);
            // 
            // lblPlaylist
            // 
            this.lblPlaylist.AutoSize = true;
            this.lblPlaylist.Location = new System.Drawing.Point(3, 181);
            this.lblPlaylist.Name = "lblPlaylist";
            this.lblPlaylist.Size = new System.Drawing.Size(114, 13);
            this.lblPlaylist.TabIndex = 16;
            this.lblPlaylist.Text = "Select your Playlist file:";
            // 
            // ofdPlaylist
            // 
            this.ofdPlaylist.Filter = "BPlist Files|*.bplist";
            // 
            // lblHintPlaylist
            // 
            this.lblHintPlaylist.AutoSize = true;
            this.lblHintPlaylist.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblHintPlaylist.Location = new System.Drawing.Point(3, 202);
            this.lblHintPlaylist.Name = "lblHintPlaylist";
            this.lblHintPlaylist.Size = new System.Drawing.Size(319, 13);
            this.lblHintPlaylist.TabIndex = 18;
            this.lblHintPlaylist.Text = "(Hint: These can be found at <Beat Saber install folder>\\Playlists\\)";
            // 
            // LocalScoreFixer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(684, 336);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.lblTitle);
            this.Name = "LocalScoreFixer";
            this.Text = "Local Score Fixer";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
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
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblHintFiles;
        private System.Windows.Forms.Label lblHintFolder;
        private System.Windows.Forms.RadioButton radModeScores;
        private System.Windows.Forms.RadioButton radModePlaylists;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Button btnPlaylist;
        private System.Windows.Forms.Label lblPlaylist;
        private System.Windows.Forms.OpenFileDialog ofdPlaylist;
        private System.Windows.Forms.Label lblHintPlaylist;
    }
}

