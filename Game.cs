using System;
using System.Drawing;
using System.Windows.Forms;

namespace eatingAtlabyrinth
{
    /// <summary>
    /// abstract class Game with all settings
    /// </summary>
    internal abstract partial class Game : Form
    {
        /// <summary>
        /// Timer moving speed
        /// </summary>
        protected Timer t_move;
        /// <summary>
        /// GridArray
        /// </summary>
        protected Point[,] grid;
        /// <summary>
        /// Labyrinth
        /// </summary>
        internal char[,] maze;
        /// <summary>
        /// coordinates player
        /// </summary>
        protected Point pos_player_point;
        /// <summary>
        /// Index player in GridArray
        /// </summary>
        protected Tuple<int, int> pos_player_index;
        /// <summary>
        /// number of turns
        /// </summary>
        protected int turn;
        /// <summary>
        /// graphic settings
        /// </summary>
        protected Pen pen_item = new Pen(Color.Blue, 2f);
        protected SolidBrush brush_wall = new SolidBrush(Color.Green);
        protected SolidBrush brush_player = new SolidBrush(Color.Red);
        protected SolidBrush brush_rectangleturns = new SolidBrush(Color.FromArgb(180, Color.Gray));
        protected SolidBrush brush_turn = new SolidBrush(Color.Black);
        protected Font font_wall = new Font("Microsoft Sans Serif", 40f, System.Drawing.FontStyle.Bold,
                                        System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        protected Font font_player = new Font("Microsoft Sans Serif", 30f, System.Drawing.FontStyle.Bold,
                                        System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        protected Font font_gameover = new Font("Microsoft Sans Serif", 50f, System.Drawing.FontStyle.Bold,
                                        System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        /// <summary>
        /// PictureBox for player
        /// </summary>
        protected PictureBox p_player;
        /// <summary>
        /// main menu Button
        /// </summary>
        protected Button b_menu;
        /// <summary>
        /// helper var for moving (direction)
        /// </summary>
        protected string direction;
        /// <summary>
        /// window size
        /// </summary>
        protected Size Client;
        /// <summary>
        /// number of items
        /// </summary>
        protected int items;

        /// <summary>
        /// init
        /// </summary>
        /// <param name="inp">Labyrinth</param>
        internal Game(char[,]inp)
        {
            //maze init
            maze = new char[inp.GetLength(0), inp.GetLength(1)];
            //Search start position; take inpArrays in maze
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    maze[i, j] = inp[i, j];
                    if (maze[i, j] == ' ')
                    {
                        pos_player_index = new Tuple<int, int>(i, j);
                    }
                }
            }
            //create GridArray
            grid = new Point[maze.GetLength(0), maze.GetLength(1)];
            InitializeComponent();
            //set ClientSize
            ClientSize = new Size(grid.GetLength(0) * 25 + 10, grid.GetLength(1) * 35 + 10);
            Client = ClientSize;
            //reference GridArray
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = new Point(ClientRectangle.Width / grid.GetLength(0) * (i),
                                            ClientRectangle.Height / grid.GetLength(1) * (j));
                }
            }
            //PictureBox_player
            p_player = new PictureBox();
            p_player.Size = ClientSize;
            p_player.Location = new Point(0, 0);
            p_player.BackColor = Color.Transparent;
            Controls.Add(p_player);
            p_player.Paint += p_player_Paint;
            //Button_menu
            b_menu = new Button();
            b_menu.Size = new Size(200, 50);
            b_menu.BackColor = Color.LightGray;
            b_menu.Location = new Point(ClientSize.Width / 2 - 100, ClientSize.Height / 2 + 100);
            b_menu.Text = "Hauptmenü";
            b_menu.Font = font_player;
            Controls.Add(b_menu);
            b_menu.BringToFront();
            b_menu.Visible = false;
            b_menu.Click += b_menu_Click;
            //Timer_move
            t_move = new Timer();
            t_move.Interval = 100;
            t_move.Tick += t_move_Tick;            
        }
        /// <summary>
        /// abstract method PreviewKeyDownEventHandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected abstract void Game_PreviewKeyDown(object sender,PreviewKeyDownEventArgs e);
        /// <summary>
        /// PaintEventHandler for drawing labyrinth
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void p_grid_Paint(object sender, PaintEventArgs e)
        {
            //Graphics Element
            Graphics g = e.Graphics;
            //Position Player 
            pos_player_point = grid[pos_player_index.Item1, pos_player_index.Item2];
            //draw labyrinth
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    switch (maze[i, j])
                    {
                        case '#':
                            g.DrawString(maze[i, j].ToString(), font_wall, brush_wall, grid[i, j]);
                            break;
                        case '.':
                            //Items as circles
                            g.DrawEllipse(pen_item, new RectangleF(new PointF(grid[i, j].X + ClientRectangle.Width / grid.GetLength(0) / 2,
                                            grid[i, j].Y + ClientRectangle.Height / grid.GetLength(1) / 2),
                                            new SizeF(ClientRectangle.Width / grid.GetLength(0) / 2, ClientRectangle.Width / grid.GetLength(0) / 2)));
                            break;
                        default:
                            break;
                    }
                }
            }
            //draw number of turns info box
            g.FillRectangle(brush_rectangleturns, ClientSize.Width - 160, 0, 160, 35);
            g.DrawString("Züge:", font_player, brush_turn, new PointF(ClientSize.Width - 155, 0));
        }
        /// <summary>
        /// abstract method TimerOnTickEventHandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected abstract void t_move_Tick(object sender, EventArgs e);
        /// <summary>
        /// main menu-Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void b_menu_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// PaintEventHandler player to draw player on map
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void p_player_Paint(object sender, PaintEventArgs e)
        {
            //Graphics Element
            Graphics g = e.Graphics;
            //direction alignment turn
            StringFormat f = new StringFormat();
            f.Alignment = StringAlignment.Far;
            //coordinates of Player
            pos_player_point = grid[pos_player_index.Item1, pos_player_index.Item2];
            //draw Player
            g.DrawString("@", font_player, brush_player, pos_player_point);
            //draw turn count
            g.DrawString(turn.ToString(), font_player, brush_turn, new PointF(ClientSize.Width - 10, 0), f);
            items = 0;
            //check how many items left
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i, j] == '.')
                    {
                        items += 1;
                    }
                }
            }
            //check if game is end
            if (items == 0)
            {
                //show game ended sign
                f.Alignment = StringAlignment.Center;
                g.FillRectangle(brush_rectangleturns, 0, 0, ClientSize.Width, ClientSize.Height);
                g.DrawString("Gewonnen!", font_gameover, brush_turn, new PointF(ClientSize.Width / 2, ClientSize.Height / 3), f);
                g.DrawString("Gelöst in " + turn + " Zügen!", font_player, brush_turn, new PointF(ClientSize.Width / 2, ClientSize.Height / 3 * 1.5f), f);
                b_menu.Visible = true;
            }
            else
            {
                //increment turns
                turn++;
            }
        }
    }
}


