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
            this.lblAppData = new System.Windows.Forms.Label();
            this.txtCustomFolder = new System.Windows.Forms.TextBox();
            this.btnCustomFolder = new System.Windows.Forms.Button();
            this.ofdSongHashData = new System.Windows.Forms.OpenFileDialog();
            this.btnGo = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.radModePartyScores = new System.Windows.Forms.RadioButton();
            this.btnAppDataFolder = new System.Windows.Forms.Button();
            this.txtAppDataFolder = new System.Windows.Forms.TextBox();
            this.lblHintPlaylist = new System.Windows.Forms.Label();
            this.btnPlaylist = new System.Windows.Forms.Button();
            this.lblPlaylist = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.radModePlaylists = new System.Windows.Forms.RadioButton();
            this.radModeSoloScores = new System.Windows.Forms.RadioButton();
            this.lblHintFolder = new System.Windows.Forms.Label();
            this.lblHintFiles = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.ofdPlaylist = new System.Windows.Forms.OpenFileDialog();
            this.fbdAppData = new System.Windows.Forms.FolderBrowserDialog();
            this.ofdLeaderboards = new System.Windows.Forms.OpenFileDialog();
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
            // lblAppData
            // 
            this.lblAppData.AutoSize = true;
            this.lblAppData.Location = new System.Drawing.Point(3, 66);
            this.lblAppData.Name = "lblAppData";
            this.lblAppData.Size = new System.Drawing.Size(173, 13);
            this.lblAppData.TabIndex = 2;
            this.lblAppData.Text = "Specify the local Beat Saber folder:";
            // 
            // txtCustomFolder
            // 
            this.txtCustomFolder.Location = new System.Drawing.Point(186, 7);
            this.txtCustomFolder.Name = "txtCustomFolder";
            this.txtCustomFolder.ReadOnly = true;
            this.txtCustomFolder.Size = new System.Drawing.Size(376, 20);
            this.txtCustomFolder.TabIndex = 4;
            // 
            // btnCustomFolder
            // 
            this.btnCustomFolder.Location = new System.Drawing.Point(568, 5);
            this.btnCustomFolder.Name = "btnCustomFolder";
            this.btnCustomFolder.Size = new System.Drawing.Size(75, 23);
            this.btnCustomFolder.TabIndex = 5;
            this.btnCustomFolder.Text = "Browse";
            this.btnCustomFolder.UseVisualStyleBackColor = true;
            this.btnCustomFolder.Click += new System.EventHandler(this.btnCustomFolder_Click);
            // 
            // ofdSongHashData
            // 
            this.ofdSongHashData.FileName = "SongHashData*";
            this.ofdSongHashData.Filter = "Dat Files|*.dat";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGo.Enabled = false;
            this.btnGo.Location = new System.Drawing.Point(33, 207);
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
            this.pnlMain.Controls.Add(this.radModePartyScores);
            this.pnlMain.Controls.Add(this.btnAppDataFolder);
            this.pnlMain.Controls.Add(this.txtAppDataFolder);
            this.pnlMain.Controls.Add(this.lblHintPlaylist);
            this.pnlMain.Controls.Add(this.btnPlaylist);
            this.pnlMain.Controls.Add(this.lblPlaylist);
            this.pnlMain.Controls.Add(this.lblMode);
            this.pnlMain.Controls.Add(this.radModePlaylists);
            this.pnlMain.Controls.Add(this.radModeSoloScores);
            this.pnlMain.Controls.Add(this.lblHintFolder);
            this.pnlMain.Controls.Add(this.lblHintFiles);
            this.pnlMain.Controls.Add(this.txtStatus);
            this.pnlMain.Controls.Add(this.lblStatus);
            this.pnlMain.Controls.Add(this.lblFolder);
            this.pnlMain.Controls.Add(this.btnGo);
            this.pnlMain.Controls.Add(this.txtCustomFolder);
            this.pnlMain.Controls.Add(this.btnCustomFolder);
            this.pnlMain.Controls.Add(this.lblAppData);
            this.pnlMain.Location = new System.Drawing.Point(12, 56);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(660, 243);
            this.pnlMain.TabIndex = 9;
            // 
            // radModePartyScores
            // 
            this.radModePartyScores.AutoSize = true;
            this.radModePartyScores.Location = new System.Drawing.Point(342, 113);
            this.radModePartyScores.Name = "radModePartyScores";
            this.radModePartyScores.Size = new System.Drawing.Size(153, 17);
            this.radModePartyScores.TabIndex = 21;
            this.radModePartyScores.Text = "Party High Scores/Combos";
            this.radModePartyScores.UseVisualStyleBackColor = true;
            this.radModePartyScores.CheckedChanged += new System.EventHandler(this.radModePartyScores_CheckedChanged);
            // 
            // btnAppDataFolder
            // 
            this.btnAppDataFolder.Location = new System.Drawing.Point(568, 61);
            this.btnAppDataFolder.Name = "btnAppDataFolder";
            this.btnAppDataFolder.Size = new System.Drawing.Size(75, 23);
            this.btnAppDataFolder.TabIndex = 20;
            this.btnAppDataFolder.Text = "Browse";
            this.btnAppDataFolder.UseVisualStyleBackColor = true;
            this.btnAppDataFolder.Click += new System.EventHandler(this.btnAppDataFolder_Click);
            // 
            // txtAppDataFolder
            // 
            this.txtAppDataFolder.Location = new System.Drawing.Point(186, 63);
            this.txtAppDataFolder.Name = "txtAppDataFolder";
            this.txtAppDataFolder.ReadOnly = true;
            this.txtAppDataFolder.Size = new System.Drawing.Size(376, 20);
            this.txtAppDataFolder.TabIndex = 19;
            // 
            // lblHintPlaylist
            // 
            this.lblHintPlaylist.AutoSize = true;
            this.lblHintPlaylist.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblHintPlaylist.Location = new System.Drawing.Point(3, 171);
            this.lblHintPlaylist.Name = "lblHintPlaylist";
            this.lblHintPlaylist.Size = new System.Drawing.Size(319, 13);
            this.lblHintPlaylist.TabIndex = 18;
            this.lblHintPlaylist.Text = "(Hint: These can be found at <Beat Saber install folder>\\Playlists\\)";
            // 
            // btnPlaylist
            // 
            this.btnPlaylist.Location = new System.Drawing.Point(186, 145);
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
            this.lblPlaylist.Location = new System.Drawing.Point(3, 150);
            this.lblPlaylist.Name = "lblPlaylist";
            this.lblPlaylist.Size = new System.Drawing.Size(114, 13);
            this.lblPlaylist.TabIndex = 16;
            this.lblPlaylist.Text = "Select your Playlist file:";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(3, 115);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(125, 13);
            this.lblMode.TabIndex = 15;
            this.lblMode.Text = "What do you want to fix?";
            // 
            // radModePlaylists
            // 
            this.radModePlaylists.AutoSize = true;
            this.radModePlaylists.Location = new System.Drawing.Point(501, 113);
            this.radModePlaylists.Name = "radModePlaylists";
            this.radModePlaylists.Size = new System.Drawing.Size(100, 17);
            this.radModePlaylists.TabIndex = 14;
            this.radModePlaylists.Text = "Custom Playlists";
            this.radModePlaylists.UseVisualStyleBackColor = true;
            this.radModePlaylists.CheckedChanged += new System.EventHandler(this.radModePlaylists_CheckedChanged);
            // 
            // radModeSoloScores
            // 
            this.radModeSoloScores.AutoSize = true;
            this.radModeSoloScores.Checked = true;
            this.radModeSoloScores.Location = new System.Drawing.Point(186, 113);
            this.radModeSoloScores.Name = "radModeSoloScores";
            this.radModeSoloScores.Size = new System.Drawing.Size(150, 17);
            this.radModeSoloScores.TabIndex = 13;
            this.radModeSoloScores.TabStop = true;
            this.radModeSoloScores.Text = "Solo High Scores/Combos";
            this.radModeSoloScores.UseVisualStyleBackColor = true;
            this.radModeSoloScores.CheckedChanged += new System.EventHandler(this.radModeSoloScores_CheckedChanged);
            // 
            // lblHintFolder
            // 
            this.lblHintFolder.AutoSize = true;
            this.lblHintFolder.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblHintFolder.Location = new System.Drawing.Point(3, 31);
            this.lblHintFolder.Name = "lblHintFolder";
            this.lblHintFolder.Size = new System.Drawing.Size(374, 13);
            this.lblHintFolder.TabIndex = 12;
            this.lblHintFolder.Text = "(Hint: Browse to <Beat Saber install folder>\\Beat Saber_Data\\CustomLevels\\)";
            // 
            // lblHintFiles
            // 
            this.lblHintFiles.AutoSize = true;
            this.lblHintFiles.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblHintFiles.Location = new System.Drawing.Point(3, 86);
            this.lblHintFiles.Name = "lblHintFiles";
            this.lblHintFiles.Size = new System.Drawing.Size(463, 13);
            this.lblHintFiles.TabIndex = 11;
            this.lblHintFiles.Text = "(Hint: Browse to C:\\Users\\<username>\\AppData\\LocalLow\\Hyperbolic Magnetism\\Beat S" +
    "aber\\)";
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtStatus.Location = new System.Drawing.Point(186, 209);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(457, 20);
            this.txtStatus.TabIndex = 10;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(136, 212);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Status:";
            // 
            // ofdPlaylist
            // 
            this.ofdPlaylist.Filter = "BPlist Files|*.bplist";
            // 
            // fbdAppData
            // 
            this.fbdAppData.ShowNewFolderButton = false;
            // 
            // ofdLeaderboards
            // 
            this.ofdLeaderboards.Filter = "Dat Files|*.dat";
            // 
            // LocalScoreFixer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(684, 311);
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
        private System.Windows.Forms.Label lblAppData;
        private System.Windows.Forms.TextBox txtCustomFolder;
        private System.Windows.Forms.Button btnCustomFolder;
        private System.Windows.Forms.OpenFileDialog ofdSongHashData;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblHintFiles;
        private System.Windows.Forms.Label lblHintFolder;
        private System.Windows.Forms.RadioButton radModeSoloScores;
        private System.Windows.Forms.RadioButton radModePlaylists;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Button btnPlaylist;
        private System.Windows.Forms.Label lblPlaylist;
        private System.Windows.Forms.OpenFileDialog ofdPlaylist;
        private System.Windows.Forms.Label lblHintPlaylist;
        private System.Windows.Forms.TextBox txtAppDataFolder;
        private System.Windows.Forms.Button btnAppDataFolder;
        private System.Windows.Forms.FolderBrowserDialog fbdAppData;
        private System.Windows.Forms.OpenFileDialog ofdLeaderboards;
        private System.Windows.Forms.RadioButton radModePartyScores;
    }
}

