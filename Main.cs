//Features to implement
//
//Python version
// Dragged text
// HTML parsing
// PDF support
// Gutenberg + library link
// EPUB support
// Images ??? 
// Keyboard commands 
//     o          - Open file
//     space      - Play/pause
//     left/right - prev/next cluster
//     s          - Split content/view
// Dyanmically modulating WPM and chunk size (training) 
// Keep the FOV the same, regardless of DPI
// DOM support? i.e. parse the DOM of sites like Wikipedia
// Learning ?
// Scrolling "zooms into entire text" at smaller font but with highlight
// Stop at end with reading statistics

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SpeedReader
{
    public partial class Main : Form
    {
        private string[] words;
        private int clusterSize;
        private int startWord;
        private int endWord;

        Timer readingTimer = new Timer();

        public Main()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Main_DragEnter);
            this.DragDrop += new DragEventHandler(Main_DragDrop);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            trbLocation.Enabled = false;
            chkPlayPause.Enabled = false;

            numClusterSize.Value = 1;
            numWPM.Value = 250;

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            readingTimer.Tick += new EventHandler(readingTimer_Tick);

            KeyPreview = true;
            KeyPress += new KeyPressEventHandler(Main_KeyPress);
        }

        void Main_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Space))
            {
                chkPlayPause.Checked = !chkPlayPause.Checked;
                chkPlayPause_CheckedChanged(this, null);
            }

            switch (e.KeyChar.ToString().ToUpper())
            {
                case "O":
                    cmdOpenFile_Click(this, null);
                    break;
                default:
                    break;
            }

            e.Handled = true;
            return;
        }

        void Main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }

            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        void Main_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string dropText = (string)e.Data.GetData(DataFormats.StringFormat);
                words = dropText.Split(' ', '\r', '\n');

                SetupText();
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] draggedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (draggedFiles.Length > 0)
                {
                    LoadFile(draggedFiles[0]);
                }
            }
            else
            {

            }
        }

        private void cmdOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = dialog.FileName;

                if (filePath != null)
                {
                    LoadFile(filePath);
                }
            }
            lblTextView.Select();
        }

        private string[] ReadFile(string filePath)
        {
            StringBuilder sb = new StringBuilder();

            //Flatten the text
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" ");
                }

                sb.Append(line);
            }
            string flattened = sb.ToString();
            return flattened.Split(' ', '\r', '\n');
        }

        private void LoadFile(string filePath)
        {
            words = ReadFile(filePath);
            if (words.Length > 0)
            {
                SetupText();
            }
        }

        public string GetReadableTimeSpan(TimeSpan value)
        {
            string duration = "";

            var totalDays = (int)value.TotalDays;
            if (totalDays >= 1)
            {
                duration = totalDays + " day" + (totalDays > 1 ? "s" : string.Empty);
                value = value.Add(TimeSpan.FromDays(-1 * totalDays));
            }

            var totalHours = (int)value.TotalHours;
            if (totalHours >= 1)
            {
                if (totalDays >= 1)
                {
                    duration += ", ";
                }
                duration += totalHours + " hour" + (totalHours > 1 ? "s" : string.Empty);
                value = value.Add(TimeSpan.FromHours(-1 * totalHours));
            }

            var totalMinutes = (int)value.TotalHours;
            if (totalMinutes >= 1)
            {
                if (totalHours >= 1)
                {
                    duration += ", ";
                }
                duration += totalMinutes + " minute" + (totalMinutes > 1 ? "s" : string.Empty);
            }

            return duration;
        }
 
        private void SetupText()
        {
            startWord = 0;
            endWord = startWord + clusterSize;
            trbLocation.Minimum = 0;
            trbLocation.Maximum = (int)(words.Length / clusterSize);
            UpdateText(GetNextWords(WordDirection.Forward));
            trbLocation.Enabled = true;
            chkPlayPause.Enabled = true;

            //Compute reading time
            string readingTimeStr = "";

            double sec = (double)(words.Length / numWPM.Value) * 60;
            TimeSpan Duration = TimeSpan.FromSeconds(sec);
            DateTime EndTime = DateTime.Now.Add(Duration);

            UpdateText("Read " + words.Length.ToString("#,##0") + " words\r\n" + " in " +
                 GetReadableTimeSpan(Duration) +
                 "\r\n" + " by " + EndTime.ToString("hh:mm:ss"));
 
            //Remove noise
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].ToUpper();

                if (words[i].Equals("A")) words[i] = "";
                if (words[i].Equals("AN")) words[i] = "";
                if (words[i].Equals("AND")) words[i] = "";
                if (words[i].Equals("THE")) words[i] = "";
                if (words[i].Equals("OF")) words[i] = ""; 
                if (words[i].Equals("THIS")) words[i] = "";
                if (words[i].Equals("ITS")) words[i] = "";
                if (words[i].Equals("THEN")) words[i] = "";
                if (words[i].Equals("FURTHER")) words[i] = "";
                if (words[i].Equals("FURTHERMORE")) words[i] = "";
                if (words[i].Equals("ARE")) words[i] = "";
                if (words[i].Equals("HAS")) words[i] = "";
                if (words[i].Equals("AS")) words[i] = "";
                if (words[i].Equals("BE")) words[i] = "";
                if (words[i].Equals("CAN")) words[i] = "";
                if (words[i].Equals("TO")) words[i] = "";
                if (words[i].Equals("FOR")) words[i] = "";
                if (words[i].Equals("BY")) words[i] = "";
                if (words[i].Equals("WITH")) words[i] = "";
                if (words[i].Equals("IS")) words[i] = "";
                if (words[i].Equals("SO")) words[i] = "";
                if (words[i].Equals("THAT")) words[i] = "";
                if (words[i].Equals("IN")) words[i] = "";
                if (words[i].Equals("IT")) words[i] = "";

                words[i] = words[i].Replace(";", "");
                words[i] = words[i].Replace("-", "");
                words[i] = words[i].Replace("—", "");
                words[i] = words[i].Replace(",", "");
                words[i] = words[i].Replace(".", "");
                words[i] = words[i].Replace("\"", "");
                words[i] = words[i].Replace(":", "");
                words[i] = words[i].Replace(".", "");
                words[i] = words[i].Replace("*", "");
            }
        }

        private void chkPlayPause_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPlayPause.Checked)
            {
                chkPlayPause.Text = "Pause";

                numWPM_ValueChanged(this, null);
                readingTimer.Start();
            }
            else
            {
                chkPlayPause.Text = "Play";
                readingTimer.Stop();
            
            }
            lblTextView.Select();
        }

        /// <summary>
        /// Handle the playback of text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void readingTimer_Tick(object sender, EventArgs e)
        {
            UpdateText(GetNextWords(WordDirection.Forward));
            trbLocation.Value = startWord / clusterSize;
        }

        /// <summary>
        /// Get words in direction
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        enum WordDirection
        {
            Forward,
            Reverse
        }
        private string GetNextWords(WordDirection direction)
        {
            StringBuilder sb = new StringBuilder();

            if (direction == WordDirection.Forward)
            {
                startWord += clusterSize;
                if ((startWord + clusterSize) > words.Length)
                {
                    startWord = 0;
                }
            }
            else if (direction == WordDirection.Reverse)
            {
                startWord -= clusterSize;
                if (startWord < 0)
                {
                    startWord = words.Length - clusterSize;
                }
            }
            endWord = (startWord + clusterSize);
            for (int word = startWord; word < endWord; word++)
            {
                sb.Append(words[word]);
                sb.Append(" ");
            }

            return sb.ToString();
        }

        private string GetWords(int location)
        {
            StringBuilder sb = new StringBuilder();

            startWord = location;
            endWord = startWord + clusterSize;

            if (endWord > words.Length)
            {
                endWord = 0;
            }

            for (int word = startWord; word < endWord; word++)
            {
                sb.Append(words[word]);
                sb.Append(" ");
            }

            return sb.ToString();
        }

        delegate void UpdateTextCallback(string text);
        void UpdateText(string text)
        {
            if (this.lblTextView.InvokeRequired)
            {
                UpdateTextCallback d = new UpdateTextCallback(UpdateText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lblTextView.Text = text.ToUpper();
            }
        }

        private void numClusterSize_ValueChanged(object sender, EventArgs e)
        {
            clusterSize = (int)numClusterSize.Value;
        }

        private void numWPM_ValueChanged(object sender, EventArgs e)
        {
            int wpm = (int)numWPM.Value;
            readingTimer.Interval = (int)(60000 / (wpm / clusterSize));
        }
 
        private void trbLocation_Scroll(object sender, EventArgs e)
        {
            UpdateText(GetWords(trbLocation.Value * clusterSize));
        }
    }
}