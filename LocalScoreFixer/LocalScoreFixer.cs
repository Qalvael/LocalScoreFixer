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
    public struct CustomSong // This structure stores the individual custom song entries from the PlayerData.dat file. 'Alt' properties exist to store values from new format.
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
    public struct SongMapping // This structure stores the mapping between the old hash values and the new songHash values for a given song/folder.
    {
        public string folder;
        public string hash;
        public string songHash;
    }

    public partial class LocalScoreFixer : Form
    {
        public LocalScoreFixer()
        {
            InitializeComponent();
            txtStatus.Text = "Select custom songs folder and relevant files.";
            //fbdCustomSongs.SelectedPath = "E:\\SteamLibrary\\steamapps\\common\\Beat Saber\\Beat Saber_Data\\CustomLevels"; // (specify folder for convenience while testing)
        }

        private void btnFolder_Click(object sender, EventArgs e) // Display the dialog for selecting the CustomLevels folder.
        {
            using (fbdCustomSongs)
            {
                if (fbdCustomSongs.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbdCustomSongs.SelectedPath))
                {
                    txtFolder.Text = fbdCustomSongs.SelectedPath; // Populate the folder path.
                    if (btnPlayerData.Text == "Re-select" && btnSongHashData.Text == "Re-select") // Enable the Go button?
                    {
                        btnGo.Enabled = true;
                        txtStatus.Text = "Ready to process.";
                    }
                }
            }
        }

        private void btnPlayerData_Click(object sender, EventArgs e) // Display the dialog for selecting the PlayerData.dat file.
        {
            using (ofdPlayerData)
            {
                if (ofdPlayerData.ShowDialog() == DialogResult.OK && File.Exists(ofdPlayerData.FileName))
                {
                    btnPlayerData.Text = "Re-select"; // Update the Select button text.
                    if (!string.IsNullOrWhiteSpace(fbdCustomSongs.SelectedPath) && btnSongHashData.Text == "Re-select") // Enable the Go button?
                    {
                        btnGo.Enabled = true;
                        txtStatus.Text = "Ready to process.";
                    }
                }
            }
        }

        private void btnSongHashData_Click(object sender, EventArgs e) // Display the dialog for selecting the SongHashData.dat file.
        {
            using (ofdSongHashData)
            {
                if (ofdSongHashData.ShowDialog() == DialogResult.OK && File.Exists(ofdSongHashData.FileName))
                {
                    btnSongHashData.Text = "Re-select"; // Update the Select button text.
                    if (!string.IsNullOrWhiteSpace(fbdCustomSongs.SelectedPath) && btnPlayerData.Text == "Re-select") // Enable the Go button?
                    {
                        btnGo.Enabled = true;
                        txtStatus.Text = "Ready to process.";
                    }
                }
            }
        }

        private static void Serialise(CustomSong[] input, string strFilename) // Allows a CustomSong array to be output to a file in XML format.
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

        private void btnGo_Click(object sender, EventArgs e)
        {
            // Ensure both files are available to read.
            if (File.Exists(ofdPlayerData.FileName) && File.Exists(ofdSongHashData.FileName))
            {
                txtStatus.Text = "Processing...";
                // Create a copy of PlayerData.dat using the current timestamp in the filename to avoid overwriting old backups.
                File.Copy(ofdPlayerData.FileName, Path.Combine(Path.GetDirectoryName(ofdPlayerData.FileName), "PlayerData_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".dat"));

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
                foreach (Match matchCustomSongs in regex.Matches(strCustomInfo))
                {
                    string strTempReplace = matchCustomSongs.Groups[1].Value.Replace("\\\"", "%%"); // Replace \" with %% to avoid issues with splitting on quotes (").
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
                    customSongs[i].highScoreAlt = "0";
                    customSongs[i].maxComboAlt = "0";
                    customSongs[i].fullComboAlt = "false";
                    customSongs[i].maxRankAlt = "0";
                    customSongs[i].validScoreAlt = "false";
                    customSongs[i].playCountAlt = "0";
                    customSongs[i].skip = false;
                    i++;
                }

                // Read through SongHashData.dat to get the folder and songHash values.
                string strSongHashData = File.ReadAllText(ofdSongHashData.FileName);
                strSongHashData = strSongHashData.Substring(1, strSongHashData.Length - 2);

                // Get each custom song instance and convert them into SongMapping entries.
                string[] strSongMappings = Regex.Split(strSongHashData, @"},");
                SongMapping[] songMappings = new SongMapping[strSongMappings.Count()];
                i = 0;
                foreach (string strTempInfo in strSongMappings)
                {
                    songMappings[i].folder = Regex.Match(strTempInfo, @"\\\\([^\\]*?)\""").Groups[1].Value; // Get the last part of the folder path.
                    songMappings[i].songHash = strTempInfo.Substring(strTempInfo.Length-41, 40);
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
                        string strSongInfo = File.ReadAllText(strSubFolder + "\\info.json");
                        string strSubFolderName = strSubFolder.Split('\\').Last();
                        i = Array.FindIndex(songMappings, item => item.folder == strSubFolderName); // Find the SongMapping entry for this folder.
                        if (i > -1)
                        {
                            songMappings[i].hash = strSongInfo.Substring(strSongInfo.IndexOf("\"hash\":\"") + 8, 32); // v1.0.1.1 - improved obatining of hash value.
                        }
                    }
                }

                // The SongMapping array now contains the old (hash) and new (songHash) values for each custom song currently installed.
                // We can now go through each SongMapping entry and use the hash value to find the matching CustomSong entries (via the levelId property).
                // There can be multiple CustomSong entries where the levelId has the same hash/songHash value so difficulty is also used to find matches.
                // For each match the levelId will then be replaced with the songHash value from the same SongMapping entry (in the format of "custom_level_<songHash>").
                foreach (SongMapping smEntry in songMappings)
                {
                    // Get an array of indexes where the levelId contains the hash value being processed.
                    int[] intAllOldIndexes = customSongs.Select((value, index) => new { Value = value, Index = index })
                                  .Where(item => item.Value.levelId.Contains(smEntry.hash.ToUpper()))
                                  .Select(item => item.Index)
                                  .ToArray();

                    foreach (int intOldIndex in intAllOldIndexes)
                    {
                        customSongs[intOldIndex].levelIdAlt = "custom_level_" + smEntry.songHash;

                        // Get an array of indexes where the levelId contains the songHash value being processed to obtain any details from the new format.
                        int[] intAllNewIndexes = customSongs.Select((value, index) => new { Value = value, Index = index })
                                      .Where(item => item.Value.levelId.Contains(smEntry.songHash.ToUpper()))
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

                // Output info to file (uncomment below lines to see contents of customSongs and/or songMappings array in Local Score Fixer folder).
                //Serialise(customSongs, "CustomSongs.txt");
                //Serialise(songMappings, "SongMappings.txt");

                // Re-generate the PlayerData.dat file by combining the 3 sections mentioned at line 128.
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
            else //We have an issue with accessing the PlayerData.dat and/or SongHashData.dat files.
            {
                MessageBox.Show("Files can't be read. Please ensure the correct files are selected.");
            }
        }
    }
}
