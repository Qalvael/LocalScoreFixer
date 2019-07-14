# Local Score Fixer
<b>Summary</b>

This application was built to consolidate local high score and combo information for custom songs in Beat Saber (PCVR only).

On 11 June 2019 the format being used for custom songs was revised to coincide with the 1.1.0 official update of Beat Saber.

Once a user installed the updated SongCore mod and started Beat Saber a conversion process took place to apply the new format on any custom songs in their collection at the time. This resulted in any previous high scores or combo information for custom songs appearing to be reset when viewing a custom song in the game.

Fortunately, the existing high score and combo information is still present in files stored locally on the user's PC. These were just not being referenced following the conversion to the new custom song format.

The <i>Local Score Fixer</i> application is designed to check certain files on the user's PC in order to consolidate the previous custom song information with the new format. After running this, any historical high score/combo information for custom songs should be visible in Beat Saber again.

<b>NOTE:</b> Currently the application can only consolidate the stats for custom songs which are present on the user's PC. If you have played a custom song prior to the format update but have deleted it before encountering the SongCore conversion process then <i>Local Score Fixer</i> can't map this to the new format (well, not yet...).

Having said that, if a user re-downloads a custom song that they had played previously and this is converted by the SongCore mod then re-running <i>Local Score Fixer</i> will perform the consolidation of stats accordingly.


<br><br><b>Usage</b>

When running <i>Local Score Fixer</i> just specify where the required files/folders are located (guidance is provided on the form) and then click the Go button. This will automatically take a backup of the relevant file before updating it with the consolidated high score and combo information from the old and new format entries.

The user can then jump into Beat Saber to see their historical stats restored.


<br><br><b>Possible enhancements</b>

1. Given that <i>Local Score Fixer</i> currently only works with custom songs that are present on the user's PC, one thing I'd like to do is see if there is a way to leverage the Beat Saver API to get the mapping between the old and new format identifiers for custom songs.


<br><br><b>How does this work?</b>

(Warning: non-essential explanation for anyone who wants to know what is happening under the hood)

The relevant local files and folders which <i>Local Score Fixer</i> needs to check are as follows:
- The new CustomLevels folder which is created following the initial conversion process by the SongCore mod (typically located in <Beat Saber install folder>\Beat Saber_Data\CustomLevels\)
  - Each sub-folder represents a custom song and contains a file named info.json (song information in the old format).

- C:\Users\\\<username>\AppData\LocalLow\Hyperbolic Magnetism\Beat Saber\PlayerData.dat
  - This contains the individual entries for both official and custom songs for the user in relation to Solo mode.
  - After the SongCore mod's conversion process is performed there will be entries in both the old and new format for any existing custom songs.

- C:\Users\\\<username>\AppData\LocalLow\Hyperbolic Magnetism\Beat Saber\LocalLeaderboards.dat
  - This contains the individual entries for both official and custom songs for the user in relation to Party mode.
  - After the SongCore mod's conversion process is performed there will be entries in both the old and new format for any existing custom songs.

- C:\Users\\\<username>\AppData\LocalLow\Hyperbolic Magnetism\Beat Saber\SongHashData.dat
  - This contains references to the folders where each custom song is stored as well as the new songHash identifier.

Once these files and folders are specified the application then runs through the following steps:
1. When cleaning up Solo mode stats, the PlayerData.dat file is read, broken  up into sections and then all of the song details are stored in a new CustomSong struct. Each entry represents a specific difficulty level for a song (so a song could have multiple CustomSong entries). A similar exercise happens for fixing Party mode stats, except that the LocalLeaderboards.dat file is read and stored in a new LeaderboardScore struct.

2. Read the SongHashData.dat file and store the folder and new format's identifier into a new SongMapping struct.

3. Check the sub-folders within CustomLevels (except for .cache) and read the info.json file in each one to update the appropriate SongMapping entry with the old format's identifier. After this step the SongMapping entries should all know the old and new identifiers for each song.

4. The new content for the PlayerData.dat or LocalLeaderboards.dat file is then put together by finding the matching CustomSong/LeaderboardScore entries based on the identifier mapping present in the SongMapping entries. In Solo mode, if a user has recorded a high score/combo for a song prior to the conversion and again after the conversion then the best score/combo will be populated. Alternatively, if a user has recorded a high score for a song prior to the conversion and again after the conversion within Party mode then these will be brought together and sorted accordingly based on the scores.
