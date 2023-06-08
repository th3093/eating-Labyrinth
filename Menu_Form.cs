using System;
using System.Windows.Forms;

namespace eatingAtlabyrinth
{
    /// <summary>
    /// class main menu
    /// </summary>
    internal partial class Menu_Form : Form
    {
        /// <summary>
        /// Game_Form
        /// </summary>
        private Game_Form gf;
        /// <summary>
        /// AutoSolve_Form
        /// </summary>
        private AutoSolve_Form af;
        /// <summary>
        /// LabChange_Form
        /// </summary>
        private LabChange_Form lc;
        /// <summary>
        /// Labyrinth Char-Array
        /// </summary>
        internal static char[,] maze;

        internal static bool changed;
        /// <summary>
        /// init
        /// </summary>
        /// <param name="inp">Labyrinth</param>
        public Menu_Form(char[,]inp)
        {
            InitializeComponent();
            maze = inp;
            gf = new Game_Form(inp);
            gf.FormClosed += gf_FormClosed;
            af = new AutoSolve_Form(inp);
            af.FormClosed+=af_FormClosed;
            lc = new LabChange_Form();
            lc.FormClosed += lc_FormClosed;
        }
        /// <summary>
        /// ButtonOnClickEventHandler start player game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_start_Click(object sender, EventArgs e)
        {          
            this.Visible = false;
            gf.Show();
        }
        /// <summary>
        /// FormClosedEventHandler show main menu and create new instance of Game_Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gf_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
            gf = new Game_Form(maze);
            gf.FormClosed += gf_FormClosed;
        }
        /// <summary>
        /// ButtonOnClickEventHandler start bot game (autosolve)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_auto_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            af.Show();
        }
        /// <summary>
        /// FormClosedEventHandler show main menu and create new instance of AutoSolve_Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void af_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
            af = new AutoSolve_Form(maze);
            af.FormClosed += af_FormClosed;
        }
        /// <summary>
        /// ButtonOnClickEventHandler change labyrinth
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_labChange_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            lc.Show();
        }
        /// <summary>
        /// FormClosedEventHandler restart application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void lc_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (changed)
            {
                Application.Restart();
            }
        }
        /// <summary>
        /// ButtonOnClickEventHandler exit application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
