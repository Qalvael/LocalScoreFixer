using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace LocalScoreFixer
{
    [Serializable]
    public struct CustomSong // This structure stores an individual custom song entry from the PlayerData.dat file. 'Alt' properties exist to store values from new format.
    {
        public string levelId;
        public string difficulty;
        public string beatmapCharacteristicName;
        public string highScore;
        public string maxCombo;
        public string fullCombo;
        public string maxRank;
        public string validScore;
        public string playCount;
        public string levelIdAlt;
        public string highScoreAlt;
        public string maxComboAlt;
        public string fullComboAlt;
        public string maxRankAlt;
        public string validScoreAlt;
        public string playCountAlt;
        public bool skip;
    }

    [Serializable]
    public struct LeaderboardScore // This structure stores high score information for an individual song/difficulty from the LocalLeaderboards.dat file. 'Alt' properties exist to store values from new format.
    {
        public string leaderboardId;
        public string difficulty;
        public string scores;
        public string leaderboardIdAlt;
        public bool skip;
    }

    public struct LBScore // This structure is used for storing all individual scores relating to a single song/difficulty combination.
    {
        public int score;
        public string playerName;
        public string fullCombo;
        public string timestamp;
    }

    [Serializable]
    public struct PlaylistSong // This structure stores an individual custom song entry for a given song in a playlist.
    {
        public string name;
        public string hash;
        public string songHash;
    }

    [Serializable]
    public struct SongMapping // This structure stores the mapping between the old hash values and the new songHash values for a given song/folder.
    {
        public string name;
        public string folder;
        public string hash;
        public string songHash;
    }

    public partial class LocalScoreFixer : Form
    {
        public LocalScoreFixer()
        {
            InitializeComponent();

            // Hide playlist UI elements.
            DisplayPlaylistElements(false);

            txtStatus.Text = "Select the folders for custom songs and local Beat Saber data.";
            //fbdCustomSongs.SelectedPath = "E:\\SteamLibrary\\steamapps\\common\\Beat Saber\\Beat Saber_Data\\CustomLevels"; // (specify folder for convenience while testing)
            //fbdAppData.SelectedPath = "C:\\Users\\Admin\\AppData\\LocalLow\\Hyperbolic Magnetism\\Beat Saber"; // (specify folder for convenience while testing)
        }

        private void DisplayPlaylistElements(bool blnDisplay) // Showe or hide playlist UI elements.
        {
            if (blnDisplay)
            {
                this.Height = 350;
                pnlMain.Height = 243;
                lblPlaylist.Enabled = true;
                lblPlaylist.Visible = true;
                btnPlaylist.Enabled = true;
                btnPlaylist.Visible = true;
                lblHintPlaylist.Enabled = true;
                lblHintPlaylist.Visible = true;
            }
            else
            {
                lblPlaylist.Enabled = false;
                lblPlaylist.Visible = false;
                btnPlaylist.Enabled = false;
                btnPlaylist.Visible = false;
                lblHintPlaylist.Enabled = false;
                lblHintPlaylist.Visible = false;
                pnlMain.Height = 193;
                this.Height = 300;
            }
        }

        private OpenFileDialog ReadFile(OpenFileDialog ofdFile, string strFilename) // Read the specified file into the OpenFileDialog.
        {
            using (ofdFile)
            {
                ofdFile.FileName = fbdAppData.SelectedPath + "\\" + strFilename;
                if (File.Exists(ofdFile.FileName))
                {
                    return ofdFile;
                }
                else
                {
                    return ofdFile;
                }
            }
        }

        private bool FileFolderCheck() // Determine if the required files and folders are accessible.
        {
            if (radModeSoloScores.Checked) // Solo mode processing requires the CustomLevels folder along with PlayerData.dat and SongHashData.dat files.
            {
                if (!string.IsNullOrWhiteSpace(fbdCustomSongs.SelectedPath) && File.Exists(ofdPlayerData.FileName) && File.Exists(ofdSongHashData.FileName))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (radModePartyScores.Checked) // Party mode processing requires the CustomLevels folder along with PlayerData.dat, SongHashData.dat and LocalLeaderboards.dat files.
            {
                if (!string.IsNullOrWhiteSpace(fbdCustomSongs.SelectedPath) && File.Exists(ofdPlayerData.FileName) && File.Exists(ofdSongHashData.FileName) && File.Exists(ofdLeaderboards.FileName))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else // Playlist processing requires the CustomLevels folder along with PlayerData.dat, SongHashData.dat and a specified playlist file.
            {
                if (!string.IsNullOrWhiteSpace(fbdCustomSongs.SelectedPath) && File.Exists(ofdPlayerData.FileName) && File.Exists(ofdSongHashData.FileName) && File.Exists(ofdPlaylist.FileName))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        private void btnCustomFolder_Click(object sender, EventArgs e) // Display the dialog for selecting the CustomLevels folder.
        {
            using (fbdCustomSongs)
            {
                if (fbdCustomSongs.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbdCustomSongs.SelectedPath))
                {
                    txtCustomFolder.Text = fbdCustomSongs.SelectedPath; // Populate the folder path.

                    // Enable the Go button?
                    if (FileFolderCheck())
                    {
                        btnGo.Enabled = true;
                        txtStatus.Text = "Ready to process.";
                    }
                    else
                    {
                        btnGo.Enabled = false;
                        txtStatus.Text = "Select the folders for custom songs and local Beat Saber data.";
                    }
                }
            }
        }

        private void btnAppDataFolder_Click(object sender, EventArgs e) // Display the dialog for selecting the Beat Saber folder under AppData.
        {
            using (fbdAppData)
            {
                if (fbdAppData.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbdAppData.SelectedPath))
                {
                    txtAppDataFolder.Text = fbdAppData.SelectedPath; // Populate the folder path.
                    ofdPlayerData = ReadFile(ofdPlayerData, "PlayerData.dat");
                    ofdSongHashData = ReadFile(ofdSongHashData, "SongHashData.dat");
                    ofdLeaderboards = ReadFile(ofdLeaderboards, "LocalLeaderboards.dat");

                    // Enable the Go button?
                    if (FileFolderCheck())
                    {
                        btnGo.Enabled = true;
                        txtStatus.Text = "Ready to process.";
                    }
                    else
                    {
                        btnGo.Enabled = false;
                        txtStatus.Text = "Select the folders for custom songs and local Beat Saber data.";
                    }
                }
            }
        }

        private void radModeSoloScores_CheckedChanged(object sender, EventArgs e)
        {
            DisplayPlaylistElements(false);

            // Enable the Go button?
            if (FileFolderCheck())
            {
                btnGo.Enabled = true;
                txtStatus.Text = "Ready to process.";
            }
            else
            {
                btnGo.Enabled = false;
                txtStatus.Text = "Select the folders for custom songs and local Beat Saber data.";
            }
        }

        private void radModePartyScores_CheckedChanged(object sender, EventArgs e)
        {
            DisplayPlaylistElements(false);

            // Enable the Go button?
            if (FileFolderCheck())
            {
                btnGo.Enabled = true;
                txtStatus.Text = "Ready to process.";
            }
            else
            {
                btnGo.Enabled = false;
                txtStatus.Text = "Select the folders for custom songs and local Beat Saber data.";
            }
        }

        private void radModePlaylists_CheckedChanged(object sender, EventArgs e)
        {
            DisplayPlaylistElements(true);

            // Enable the Go button?
            if (FileFolderCheck())
            {
                btnGo.Enabled = true;
                txtStatus.Text = "Ready to process.";
            }
            else
            {
                btnGo.Enabled = false;
                txtStatus.Text = "Select the folders for custom songs and local Beat Saber data.";
            }
        }

        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            using (ofdPlaylist)
            {
                if (ofdPlaylist.ShowDialog() == DialogResult.OK && File.Exists(ofdPlaylist.FileName))
                {
                    btnPlaylist.Text = "Re-select";// Update the Select button text.

                    if (FileFolderCheck())
                    {
                        btnGo.Enabled = true;
                        txtStatus.Text = "Ready to process.";
                    }
                    else
                    {
                        btnGo.Enabled = false;
                        txtStatus.Text = "Select the folders for custom songs and local Beat Saber data.";
                    }
                }
            }
        }
        
        private string GetPartyModeDifficulty(string strSongDetails)
        {
            if (strSongDetails.EndsWith("Easy"))
            {
                return "Easy";
            }
            if (strSongDetails.EndsWith("Normal"))
            {
                return "Normal";
            }
            if (strSongDetails.EndsWith("Hard"))
            {
                return "Hard";
            }
            if (strSongDetails.EndsWith("Expert"))
            {
                return "Expert";
            }
            if (strSongDetails.EndsWith("ExpertPlus"))
            {
                return "ExpertPlus";
            }
            else
            {
                return string.Empty;
            }
        }
        private static void Serialise(CustomSong[] input, string strFilename) // Allows a CustomSong array to be output to a file in XML format.
        {
            var serializer = new XmlSerializer(input.GetType());
            var sw = new StreamWriter(strFilename);
            serializer.Serialize(sw, input);
            sw.Close();
        }

        private static void Serialise(LeaderboardScore[] input, string strFilename) // Allows a LeaderboardScore array to be output to a file in XML format.
        {
            var serializer = new XmlSerializer(input.GetType());
            var sw = new StreamWriter(strFilename);
            serializer.Serialize(sw, input);
            sw.Close();
        }

        private static void Serialise(PlaylistSong[] input, string strFilename) // Allows a PlaylistSong array to be output to a file in XML format.
        {
            var serializer = new XmlSerializer(input.GetType());
            var sw = new StreamWriter(strFilename);
            serializer.Serialize(sw, input);
            sw.Close();
        }

        private static void Serialise(SongMapping[] input, string strFilename) // Allows a SongMapping array to be output to a file in XML format.
        {
            var serializer = new XmlSerializer(input.GetType());
            var sw = new StreamWriter(strFilename);
            serializer.Serialize(sw, input);
            sw.Close();
        }

        private SongMapping[] GenerateSongMapping()
        {
            // Read through SongHashData.dat to get the folder and songHash values.
            string strSongHashData = File.ReadAllText(ofdSongHashData.FileName);
            strSongHashData = strSongHashData.Substring(1, strSongHashData.Length - 3);

            // Get each custom song instance and convert them into SongMapping entries.
            string[] strSongMappings = Regex.Split(strSongHashData, @"},");
            SongMapping[] songMappings = new SongMapping[strSongMappings.Count()];
            int i = 0;
            foreach (string strTempInfo in strSongMappings)
            {
                songMappings[i].folder = Regex.Match(strTempInfo, @"\\\\([^\\]*?)\""").Groups[1].Value; // Get the last part of the folder path.
                songMappings[i].songHash = strTempInfo.Substring(strTempInfo.Length - 41, 40);
                i++;
            }

            // Check the sub-folders in the specified CustomLevels folder (except .cache).
            // In each folder read the info.json file to get the hash value.
            // The hash value will be populated in the appropriate SongMapping entry for the folder in question.
            string[] strSubFolders = Directory.GetDirectories(fbdCustomSongs.SelectedPath);
            foreach (string strSubFolder in strSubFolders)
            {
                if (strSubFolder.Substring(strSubFolder.Length - 6, 6) != ".cache") // Skip the .cache folder.
                {
                    string strSubFolderName = strSubFolder.Split('\\').Last();
                    i = Array.FindIndex(songMappings, item => item.folder == strSubFolderName); // Find the SongMapping entry for this folder.
                    if (i > -1)
                    {
                        if (File.Exists(strSubFolder + "\\info.json")) // v1.0.2.3 - Only try to read a file that exists.
                        {
                            string strSongInfo = File.ReadAllText(strSubFolder + "\\info.json");
                            int intSongNameStart = strSongInfo.IndexOf("\"songName\":\"") + 12;
                            songMappings[i].name = strSongInfo.Substring(intSongNameStart, strSongInfo.IndexOf("\",\"", intSongNameStart) - intSongNameStart);
                            songMappings[i].hash = strSongInfo.Substring(strSongInfo.IndexOf("\"hash\":\"") + 8, 32); // v1.0.1.1 - Improved obtaining of hash value.
                        }
                        else
                        {
                            string strSongInfo = File.ReadAllText(strSubFolder + "\\info.dat");
                            int intSongNameStart = strSongInfo.IndexOf("\"_songName\":") + 14;
                            songMappings[i].name = strSongInfo.Substring(intSongNameStart, strSongInfo.IndexOf("\",", intSongNameStart) - intSongNameStart);
                            songMappings[i].hash = string.Empty;
                        }
                    }
                }
            }

            return songMappings;
        }

        private void FixSoloScores() // Fix up local high scores and combo stats for Solo-mode.
        {
            // Read through PlayerData.dat to break the content into sections:
            // 1. Initial player information.
            // 2. Custom song information.
            // 3. Mission information.
            string strPlayerData = File.ReadAllText(ofdPlayerData.FileName);
            int intLevelsStatsData = strPlayerData.IndexOf("\"levelsStatsData\":") + 19;
            int intMissionsStatsData = strPlayerData.IndexOf("],\"missionsStatsData\":");
            string strPlayerInfo = strPlayerData.Substring(0, intLevelsStatsData); // strPlayerInfo = section #1.
            string strCustomInfo = strPlayerData.Substring(intLevelsStatsData, intMissionsStatsData - intLevelsStatsData); // strCustomInfo = section #2.
            string strMissionInfo = strPlayerData.Substring(intMissionsStatsData, strPlayerData.Length - intMissionsStatsData); // strMissionInfo = section #3.

            // Get each custom song instance and convert them into CustomSong entries.
            Regex regex = new Regex(@"{([^{}]+)}*"); // Separate the custom song information by getting the text between {} brackets.
            CustomSong[] customSongs = new CustomSong[regex.Matches(strCustomInfo).Count];
            int i = 0;
            foreach (Match matchCustomSong in regex.Matches(strCustomInfo))
            {
                string strTempReplace = matchCustomSong.Groups[1].Value.Replace("\\\"", "%%"); // Replace \" with %% to avoid issues with splitting on quotes (").
                string[] strTempInfo = strTempReplace.Split('"');

                // Populate the CustomSong entry.
                customSongs[i].levelId = strTempInfo[3];
                customSongs[i].difficulty = strTempInfo[6].Substring(1, strTempInfo[6].Length - 2);
                customSongs[i].beatmapCharacteristicName = strTempInfo[9];
                customSongs[i].highScore = strTempInfo[12].Substring(1, strTempInfo[12].Length - 2);
                customSongs[i].maxCombo = strTempInfo[14].Substring(1, strTempInfo[14].Length - 2);
                customSongs[i].fullCombo = strTempInfo[16].Substring(1, strTempInfo[16].Length - 2);
                customSongs[i].maxRank = strTempInfo[18].Substring(1, strTempInfo[18].Length - 2);
                customSongs[i].validScore = strTempInfo[20].Substring(1, strTempInfo[20].Length - 2);
                customSongs[i].playCount = strTempInfo[22].Substring(1, strTempInfo[22].Length - 1);
                customSongs[i].levelIdAlt = string.Empty;
                customSongs[i].highScoreAlt = "0";
                customSongs[i].maxComboAlt = "0";
                customSongs[i].fullComboAlt = "false";
                customSongs[i].maxRankAlt = "0";
                customSongs[i].validScoreAlt = "false";
                customSongs[i].playCountAlt = "0";
                customSongs[i].skip = false;
                i++;
            }

            SongMapping[] songMappings = GenerateSongMapping(); // Create SongMapping entries for comparison with CustomSong entries.

            // The SongMapping array now contains the old (hash) and new (songHash) values for each custom song currently installed.
            // We can now go through each SongMapping entry and use the hash value to find the matching CustomSong entries (via the levelId property).
            // There can be multiple CustomSong entries where the levelId has the same hash/songHash value so difficulty is also used to find matches.
            // For each match the levelId will then be replaced with the songHash value from the same SongMapping entry (in the format of "custom_level_<songHash>").
            foreach (SongMapping smEntry in songMappings)
            {
                if (smEntry.hash.Length > 0) // v1.0.2.3 - Only try to map an entry with a hash value.
                {
                    // Get an array of indexes where the levelId contains the hash value being processed.
                    int[] intAllOldIndexes = customSongs.Select((value, index) => new { Value = value, Index = index })
                                  .Where(item => item.Value.levelId.ToUpper().Contains(smEntry.hash.ToUpper()))
                                  .Select(item => item.Index)
                                  .ToArray();

                    foreach (int intOldIndex in intAllOldIndexes)
                    {
                        customSongs[intOldIndex].levelIdAlt = "custom_level_" + smEntry.songHash;

                        // Get an array of indexes where the levelId contains the songHash value being processed to obtain any details from the new format.
                        int[] intAllNewIndexes = customSongs.Select((value, index) => new { Value = value, Index = index })
                                      .Where(item => item.Value.levelId.ToUpper().Contains(smEntry.songHash.ToUpper()))
                                      .Select(item => item.Index)
                                      .ToArray();

                        foreach (int intNewIndex in intAllNewIndexes)
                        {
                            if (customSongs[intOldIndex].difficulty == customSongs[intNewIndex].difficulty) // Only update when the difficulties match.
                            {
                                // Update the CustomSong entry with the alternate details.
                                customSongs[intOldIndex].highScoreAlt = customSongs[intNewIndex].highScore;
                                customSongs[intOldIndex].maxComboAlt = customSongs[intNewIndex].maxCombo;
                                customSongs[intOldIndex].fullComboAlt = customSongs[intNewIndex].fullCombo;
                                customSongs[intOldIndex].maxRankAlt = customSongs[intNewIndex].maxRank;
                                customSongs[intOldIndex].validScoreAlt = customSongs[intNewIndex].validScore;
                                customSongs[intOldIndex].playCountAlt = customSongs[intNewIndex].playCount;
                                customSongs[intNewIndex].skip = true;
                            }
                        }
                    }
                }
            }

            // Output info to file (uncomment below lines to see contents of customSongs and/or songMappings array in Local Score Fixer folder).
            //Serialise(customSongs, "CustomSongs.txt");
            //Serialise(songMappings, "SongMappings.txt");

            // Create a copy of PlayerData.dat using the current timestamp in the filename to avoid overwriting old backups.
            File.Copy(ofdPlayerData.FileName, Path.Combine(Path.GetDirectoryName(ofdPlayerData.FileName), "PlayerData_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".dat"));

            // Re-generate the PlayerData.dat file by combining the 3 sections mentioned at line 400.
            StringBuilder sbNewPlayerData = new StringBuilder(strPlayerInfo); // Start a new string with section #1 from the original PlayerData.dat read.
            i = 0;
            foreach (CustomSong csEntry in customSongs) // Create section #2 manually by using information in customSongs entries.
            {
                if (!csEntry.skip) // Only include CustomSong entries that aren't flagged to be skipped.
                {
                    if (i > 0)
                    {
                        sbNewPlayerData.Append(","); // Add a comma for every entry after the first one.
                    }
                    sbNewPlayerData.Append("{\"levelId\":\"");
                    if (String.IsNullOrEmpty(csEntry.levelIdAlt)) // Check if an updated levelId value (i.e. the new format) has been specified or not.
                    {
                        sbNewPlayerData.AppendFormat("{0}\",", csEntry.levelId);
                    }
                    else
                    {
                        sbNewPlayerData.AppendFormat("{0}\",", csEntry.levelIdAlt);
                    }
                    sbNewPlayerData.AppendFormat("\"difficulty\":{0},", csEntry.difficulty);
                    sbNewPlayerData.AppendFormat("\"beatmapCharacteristicName\":\"{0}\",", csEntry.beatmapCharacteristicName);
                    sbNewPlayerData.AppendFormat("\"highScore\":{0},", Math.Max(Convert.ToInt32(csEntry.highScore), Convert.ToInt32(csEntry.highScoreAlt)).ToString()); // Choose higher value.
                    sbNewPlayerData.AppendFormat("\"maxCombo\":{0},", Math.Max(Convert.ToInt32(csEntry.maxCombo), Convert.ToInt32(csEntry.maxComboAlt)).ToString()); // Choose higher value.
                    if (Convert.ToBoolean(csEntry.fullCombo) || Convert.ToBoolean(csEntry.fullComboAlt)) // If either are true then set as true.
                    {
                        sbNewPlayerData.Append("\"fullCombo\":true,");
                    }
                    else
                    {
                        sbNewPlayerData.Append("\"fullCombo\":false,");
                    }
                    sbNewPlayerData.AppendFormat("\"maxRank\":{0},", Math.Max(Convert.ToInt32(csEntry.maxRank), Convert.ToInt32(csEntry.maxRankAlt)).ToString()); // Choose higher value.
                    if (Convert.ToBoolean(csEntry.validScore) || Convert.ToBoolean(csEntry.validScoreAlt)) // If either are true then set as true.
                    {
                        sbNewPlayerData.Append("\"validScore\":true,");
                    }
                    else
                    {
                        sbNewPlayerData.Append("\"validScore\":false,");
                    }
                    int intPlayCount = Convert.ToInt32(csEntry.playCount) + Convert.ToInt32(csEntry.playCountAlt);
                    sbNewPlayerData.AppendFormat("\"playCount\":{0}", intPlayCount.ToString()); // Add both figures.
                    sbNewPlayerData.Append("}");
                    i++;
                }
            }
            sbNewPlayerData.Append(strMissionInfo); // Add section #3 from the original PlayerData.dat read to the end of the content.
            File.WriteAllText(ofdPlayerData.FileName, sbNewPlayerData.ToString()); // Overwrite the existing information in the PlayerData.dat file.
            txtStatus.Text = "Process completed successfully.";
        }

        private void FixPartyScores() // v1.0.3.4 - Fix up local high scores for Party-mode.
        {
            // Read through LocalLeaderboards.dat to break the content into sections:
            // 1. Initial leaderboard information.
            // 2. Custom song information.
            string strLeaderboardData = File.ReadAllText(ofdLeaderboards.FileName);
            int intLeaderboardData = strLeaderboardData.IndexOf("[{\"_leaderboardId\":") + 1;
            string strLeaderboardInfo = strLeaderboardData.Substring(0, intLeaderboardData); // strLeaderboardInfo = section #1.
            string strPartyScoreInfo = strLeaderboardData.Substring(intLeaderboardData, strLeaderboardData.Length - intLeaderboardData - 2); // strPartySongInfo = section #2.

            // Get each party mode high score instance and convert them into LeaderboardScore entries.
            string[] arrPartyScoreInfo = strPartyScoreInfo.Split(new string[] { "]}," }, StringSplitOptions.None); // Divide into separate song/difficulty entries.
            LeaderboardScore[] leaderboardScores = new LeaderboardScore[arrPartyScoreInfo.Count()];
            int i;

            for (i = 0; i < arrPartyScoreInfo.Count(); i++)
            {
                string strTempReplace = arrPartyScoreInfo[i].Replace("\\\"", "%%"); // Replace \" with %% to avoid issues with splitting on quotes (").
                int intSongIdStart = strTempReplace.IndexOf('"', 19);
                string strTempSongInfo = strTempReplace.Substring(19, intSongIdStart - 19);

                // Populate the LeaderboardScore entry.
                leaderboardScores[i].leaderboardId = strTempSongInfo.Replace("%%", "\\\""); // Revert %% back to \" so that the original value is stored.
                leaderboardScores[i].difficulty = GetPartyModeDifficulty(strTempSongInfo);
                leaderboardScores[i].scores = arrPartyScoreInfo[i].Substring(arrPartyScoreInfo[i].IndexOf(":[{") + 2);
                leaderboardScores[i].leaderboardIdAlt = string.Empty;
                leaderboardScores[i].skip = false;
            }

            SongMapping[] songMappings = GenerateSongMapping(); // Create SongMapping entries for comparison with LeaderboardScore entries.

            // The SongMapping array now contains the old (hash) and new (songHash) values for each custom song currently installed.
            // We can now go through each SongMapping entry and use the hash value to find the matching LeaderboardScore entries (via the leaderboardId property).
            // For each match the leaderboardId will then be replaced with the songHash value from the same SongMapping entry (in the format of "custom_level_<songHash>").
            foreach (SongMapping smEntry in songMappings)
            {
                if (smEntry.hash.Length > 0) // v1.0.2.3 - Only try to map an entry with a hash value.
                {
                    // Get an array of indexes where the levelId contains the hash value being processed.
                    int[] intAllOldIndexes = leaderboardScores.Select((value, index) => new { Value = value, Index = index })
                                  .Where(item => item.Value.leaderboardId.ToUpper().Contains(smEntry.hash.ToUpper()))
                                  .Select(item => item.Index)
                                  .ToArray();

                    foreach (int intOldIndex in intAllOldIndexes)
                    {
                        leaderboardScores[intOldIndex].leaderboardIdAlt = "custom_level_" + smEntry.songHash + leaderboardScores[intOldIndex].difficulty;

                        // Get an array of indexes where the leaderboardId contains the songHash value being processed to obtain any details from the new format.
                        int[] intAllNewIndexes = leaderboardScores.Select((value, index) => new { Value = value, Index = index })
                                      .Where(item => item.Value.leaderboardId.ToUpper().Contains(smEntry.songHash.ToUpper()))
                                      .Select(item => item.Index)
                                      .ToArray();

                        foreach (int intNewIndex in intAllNewIndexes)
                        {
                            if (leaderboardScores[intOldIndex].difficulty == leaderboardScores[intNewIndex].difficulty) // Only update when the difficulties match.
                            {
                                // Consolidate any additional scores, sort them by highest score and update the LeaderboardScore entry.
                                string strAllScores = leaderboardScores[intOldIndex].scores + "," + leaderboardScores[intNewIndex].scores;
                                StringBuilder sbScoreInfo = new StringBuilder();
                                Regex regex = new Regex(@"{([^{}]+)}*"); // Separate the score information by getting the text between {} brackets.
                                LBScore[] allScores = new LBScore[regex.Matches(strAllScores).Count];
                                i = 0;
                                foreach (Match matchScore in regex.Matches(strAllScores))
                                {
                                    string[] strTempInfo = matchScore.Value.Split(',');
                                    allScores[i].score = Convert.ToInt32(strTempInfo[0].Substring(strTempInfo[0].IndexOf(':')+1));
                                    allScores[i].playerName = strTempInfo[1].Substring(strTempInfo[1].IndexOf(':') + 1);
                                    allScores[i].fullCombo = strTempInfo[2].Substring(strTempInfo[2].IndexOf(':') + 1);
                                    allScores[i].timestamp = strTempInfo[3].Substring(strTempInfo[3].IndexOf(':') + 1);
                                    i++;
                                }

                                IEnumerable<LBScore> query = allScores.OrderByDescending(item => item.score);
                                i = 0;
                                foreach (LBScore item in query.ToArray())
                                {
                                    if (i > 0)
                                    {
                                        sbScoreInfo.Append(",");
                                    }
                                    sbScoreInfo.Append("{");
                                    sbScoreInfo.AppendFormat("\"_score\":{0},\"_playerName\":{1},\"_fullCombo\":{2},\"_timestamp\":{3}", item.score.ToString(), item.playerName, item.fullCombo, item.timestamp);
                                    i++;
                                }
                                leaderboardScores[intOldIndex].scores = sbScoreInfo.ToString();
                                leaderboardScores[intNewIndex].skip = true;
                            }
                        }
                    }
                }
            }

            // Output info to file (uncomment below lines to see contents of leaderboardScores and/or songMappings array in Local Score Fixer folder).
            //Serialise(leaderboardScores, "LeaderboardScore.txt");
            //Serialise(songMappings, "SongMappings.txt");

            // Create a copy of LocalLeaderboards.dat using the current timestamp in the filename to avoid overwriting old backups.
            File.Copy(ofdLeaderboards.FileName, Path.Combine(Path.GetDirectoryName(ofdLeaderboards.FileName), "LocalLeaderboards_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".dat"));

            // Re-generate the LocalLeaderboards.dat file by combining the 2 sections mentioned at line 546.
            StringBuilder sbNewLeaderboardData = new StringBuilder(strLeaderboardInfo); // Start a new string with section #1 from the original PlayerData.dat read.
            i = 0;
            foreach (LeaderboardScore lbEntry in leaderboardScores) // Create section #2 manually by using information in customSongs entries.
            {
                if (!lbEntry.skip) // Only include LeaderboardScore entries that aren't flagged to be skipped.
                {
                    if (i > 0)
                    {
                        sbNewLeaderboardData.Append(","); // Add a comma for every entry after the first one.
                    }
                    sbNewLeaderboardData.Append("{\"_leaderboardId\":\"");
                    if (String.IsNullOrEmpty(lbEntry.leaderboardIdAlt)) // Check if an updated leaderboardId value (i.e. the new format) has been specified or not.
                    {
                        sbNewLeaderboardData.AppendFormat("{0}\",\"_scores\":", lbEntry.leaderboardId);
                    }
                    else
                    {
                        sbNewLeaderboardData.AppendFormat("{0}\",\"_scores\":", lbEntry.leaderboardIdAlt);
                    }
                    sbNewLeaderboardData.AppendFormat("[{0}", lbEntry.scores);
                    sbNewLeaderboardData.Append("]}");
                    i++;
                }
            }
            if (!(sbNewLeaderboardData.ToString().Substring(sbNewLeaderboardData.Length - 5) == "}]}]}")) // v1.0.3.5 - Lazy way of setting correct brackets at end of file.
            {
                sbNewLeaderboardData.Append("]}");
            }
            File.WriteAllText(ofdLeaderboards.FileName, sbNewLeaderboardData.ToString()); // Overwrite the existing information in the LocalLeaderboards.dat file.
            txtStatus.Text = "Process completed successfully.";
        }

        private void FixPlaylist() // Fix up custom playlist.
        {
            // Read through playlist file to break the content into sections:
            // 1. Playlist information.
            // 2. Custom song information.
            string strPlaylistFile = File.ReadAllText(ofdPlaylist.FileName);
            int intPlaylistSongs = strPlaylistFile.IndexOf("\"songs\":") + 9;
            string strPlaylistInfo = strPlaylistFile.Substring(0, intPlaylistSongs); // strPlaylistInfo = section #1.
            string strPlaylistSongInfo = strPlaylistFile.Substring(intPlaylistSongs, strPlaylistFile.Length - intPlaylistSongs - 2); // strPlaylistSongInfo = section #2.

            bool blnSongListCompare = false;

            // Get each playlist song instance and convert them into PlaylistSong entries.
            Regex regex = new Regex(@"{([^{}]+)}*"); // Separate the playlist song information by getting the text between {} brackets.
            PlaylistSong[] playlistSongs = new PlaylistSong[regex.Matches(strPlaylistSongInfo).Count];
            int i = 0;
            foreach (Match matchPlaylistSongs in regex.Matches(strPlaylistSongInfo))
            {
                string[] strTempInfo = matchPlaylistSongs.Groups[1].Value.Split(new string[] { ",\"" }, StringSplitOptions.None);

                // Populate the PlaylistSong entry.
                string strTempHash = strTempInfo[0].Substring(8, strTempInfo[0].Length - 9); // The hash value could be in the old or new format.
                if (strTempHash.Length == 32) // Old format hash value is 32 characters.
                {
                    blnSongListCompare = true; // Set this flag so that we know to check the SongMapping array.
                    playlistSongs[i].hash = strTempHash;
                    playlistSongs[i].songHash = string.Empty;
                }
                else // New format hash value is 40 characters.
                {
                    playlistSongs[i].hash = string.Empty;
                    playlistSongs[i].songHash = strTempHash;
                }

                if (strTempInfo.Count() > 1)
                {
                    playlistSongs[i].name = strTempInfo[1].Substring(11, strTempInfo[1].Length - 12);
                }
                else
                {
                    blnSongListCompare = true; // Set this flag so that we know to check the SongMapping array.
                    playlistSongs[i].name = string.Empty;
                }
                i++;
            }

            SongMapping[] songMappings = GenerateSongMapping(); // Create SongMapping entries for comparison with PlaylistSong entries.

            // The PlaylistSong array will be compared against the SongMapping array to ensure that the songHash values are populated.
            // This step will only be performed if the PlaylistSong array has at leasat one old hash value.
            if (blnSongListCompare)
            {
                for (i = 0; i < playlistSongs.Count(); i++)
                {
                    if (playlistSongs[i].songHash.Length == 0) // Do we need to populate the songHash value?
                    {
                        playlistSongs[i].songHash = songMappings.First(item => item.hash.ToUpper() == playlistSongs[i].hash.ToUpper()).songHash;
                    }

                    if (playlistSongs[i].name.Length == 0) // Do we need to populate the name value?
                    {
                        playlistSongs[i].name = songMappings.First(item => item.songHash.ToUpper() == playlistSongs[i].songHash.ToUpper()).name;
                    }
                }
            }

            // Output info to file (uncomment below lines to see contents of playlistSongs array in Local Score Fixer folder).
            //Serialise(playlistSongs, "PlaylistSongs.txt");
            //Serialise(songMappings, "SongMappings.txt");

            // Create a copy of the selected playlist file using the current timestamp in the filename to avoid overwriting old backups.
            File.Copy(ofdPlaylist.FileName, Path.Combine(Path.GetDirectoryName(ofdPlaylist.FileName), ofdPlaylist.FileName + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".bplist.txt"));

            // Re-generate the playlist file by combining the 2 sections mentioned at line 677.
            StringBuilder sbNewPlaylistFile = new StringBuilder(strPlaylistInfo); // Start a new string with section #1 from the original playlist file read.
            i = 0;
            foreach (PlaylistSong plEntry in playlistSongs) // Create section #2 manually by using information in playlistSongs entries.
            {
                if (i > 0)
                {
                    sbNewPlaylistFile.Append(","); // Add a comma for every entry after the first one.
                }
                sbNewPlaylistFile.Append("{\"hash\":\"");
                sbNewPlaylistFile.AppendFormat("{0}\",", plEntry.songHash);
                sbNewPlaylistFile.AppendFormat("\"songName\":\"{0}\"", plEntry.name);
                sbNewPlaylistFile.Append("}");
                i++;
            }
            sbNewPlaylistFile.Append("]}");
            File.WriteAllText(ofdPlaylist.FileName, sbNewPlaylistFile.ToString()); // Overwrite the existing information in the playlist file.
            txtStatus.Text = "Process completed successfully.";
        }
        
        private void btnGo_Click(object sender, EventArgs e)
        {
            txtStatus.Text = "Processing...";

            if (radModeSoloScores.Checked)
            {
                FixSoloScores();
            }
            else if (radModePartyScores.Checked)
            {
                FixPartyScores();
            }
            else if (radModePlaylists.Checked)
            {
                FixPlaylist();
            }
        }
    }
}
