using System;
using System.Windows.Forms;
using System.IO;

namespace eatingAtlabyrinth
{
    /// <summary>
    /// Form to choose game map
    /// </summary>
    public partial class LabChange_Form : Form
    {
        /// <summary>
        /// name of labyrinth to load
        /// </summary>
        private string fileName;
        /// <summary>
        /// init
        /// </summary>
        public LabChange_Form()
        {
            InitializeComponent();
        }
        /// <summary>
        /// b_changeOnKlickEventHandler cahnge map
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_change_Click(object sender, EventArgs e)
        {
            Menu_Form.changed = true;
            Close();
        }
        /// <summary>
        /// b_backOnKlickEventHandler abort changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_back_Click(object sender, EventArgs e)
        {
            File.Delete("GameEnv_ChangeLog.txt");
            Menu_Form.changed = false;
            Close();
        }
        /// <summary>
        /// b_openFileDialogOnKlickEventHandler start openFileDialog 
        /// choose file; path get stored in tmp file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_openFileDialog_Click(object sender, System.EventArgs e)
        {
            openFileDialog1.ShowDialog();
            openFileDialog1.Multiselect = false;
            fileName = openFileDialog1.FileName;
            StreamWriter sw = File.CreateText("GameEnv_ChangeLog.txt");
            sw.Write(fileName);
            sw.Close();
            if (openFileDialog1.SafeFileName!="openFileDialog1")
            {
                t_dateiName.Text = openFileDialog1.SafeFileName;
            }            
        }
    }
}