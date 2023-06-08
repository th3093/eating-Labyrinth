using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace eatingAtlabyrinth
{
    /// <summary>
    /// Form automatic solving of the labyrinth; inherits from Game
    /// </summary>
    internal partial class AutoSolve_Form : Game
    {
        /// <summary>
        /// PictureBox p_start displays starting message
        /// </summary>
        protected PictureBox p_start;
        /// <summary>
        /// Stack way as solving way
        /// </summary>
        protected Stack<Tuple<int,int>> way;
        /// <summary>
        /// ComputerPlayer complay as solver object
        /// </summary>
        protected ComputerPlayer complay;
        /// <summary>
        /// Initializing
        /// </summary>
        /// <param name="inp">Labyrinth as char-Array</param>
        internal AutoSolve_Form(char[,] inp): base(inp)           
        {
            //ComputerPlayer init
            complay = new ComputerPlayer(maze,grid);            
            InitializeComponent();
            //set window size
            ClientSize = Client;            
            //PictureBox init
            p_start = new PictureBox();
            p_start.BackColor = Color.Transparent;
            p_start.Size = ClientSize;
            p_start.Location = new Point(0, 0);            
            Controls.Add(p_start);
            p_start.BringToFront();
            p_start.Paint += p_start_Paint;
            Text = "Eating @ Labyrinth";
        }
        /// <summary>
        /// PaintEventHandler for start message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void p_start_Paint(object sender, PaintEventArgs e)
        {
            //init of Graphics element and draw background and signs
            Graphics g = e.Graphics;
            StringFormat f = new StringFormat();
            f.Alignment = StringAlignment.Center;
            g.FillRectangle(brush_rectangleturns, ClientRectangle);
            g.DrawString("Press", font_gameover, brush_turn, new Point(ClientSize.Width / 3, ClientSize.Height / 3-20), f);
            g.DrawString("Any", font_gameover, brush_turn, new Point(ClientSize.Width / 2, ClientSize.Height / 2-20), f);
            g.DrawString("Button!", font_gameover, brush_turn, new Point(ClientSize.Width / 15*10, ClientSize.Height / 15*10-20), f);
        }
        /// <summary>
        /// PreviewKeyDownEventHandler zum Starten des Lösungsvorgangs durch einen Tastendruck
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Game_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //check if it's start
            if (turn == 0)
            {
                //hide start message and start timer
                p_start.Visible = false;
                p_start.SendToBack();
                p_player.Refresh();
                t_move.Start();
            }
        }
        /// <summary>
        /// TimerOnTickEventHandler to start individual way finding calculations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void t_move_Tick(object sender, EventArgs e)
        {
            //check if items left
            if (items != 0)
            {   //start way finding
                way = ComputerPlayer.FindWay(complay, pos_player_index);
                //As long as objects are in stack, they get removed one by one;
                //dots are replaced by spaces in the labyrinth and player gets moved
                while (way.Count != 0)
                {
                    pos_player_index = way.Pop();
                    maze[pos_player_index.Item1, pos_player_index.Item2] = ' ';
                    p_player.Refresh();
                    Thread.Sleep(100);
                }
                //start new search
                t_move.Start();             
            }
        }
    }
}