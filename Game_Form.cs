using System;
using System.Windows.Forms;

namespace eatingAtlabyrinth
{
    /// <summary>
    /// Form for player game; inherits from Game
    /// </summary>
    internal partial class Game_Form:Game
    {
        /// <summary>
        /// init
        /// </summary>
        /// <param name="inp">Labyrinth as Char-Array</param>
        internal Game_Form(char[,]inp):base(inp)
        {
            InitializeComponent();
            //window size
            ClientSize = Client;
        }
        /// <summary>
        /// PreviewKeyDownEventHandler to move character with buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Game_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if main menu button is hidden, game is still active
            if(b_menu.Visible==false)
            {
                //get direction and check for collision with wall
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        if (maze[pos_player_index.Item1, pos_player_index.Item2 - 1] == '#')
                        {
                            break;
                        }
                        else
                        {
                            direction = "up";
                        }
                        break;
                    case Keys.Down:
                        if (maze[pos_player_index.Item1, pos_player_index.Item2 + 1] == '#')
                        {
                            break;
                        }
                        else
                        {
                            direction = "down";
                        }
                        break;
                    case Keys.Right:
                        if (maze[pos_player_index.Item1 + 1, pos_player_index.Item2] == '#')
                        {
                            break;
                        }
                        else
                        {
                            direction = "right";
                        }
                        break;

                    case Keys.Left:
                        if (maze[pos_player_index.Item1 - 1, pos_player_index.Item2] == '#')
                        {
                            break;
                        }
                        else
                        {
                            direction = "left";
                        }
                        break;
                    default:
                        break;
                }
                //start timer movement speed t_move
                t_move.Start();
            }
        }
        /// <summary>
        /// TimerOnTickEventHandler to move character
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void t_move_Tick(object sender, EventArgs e)
        {
            //differentiate direction through helper var
            switch (direction)
            {
                case "up":
                    //set new index
                    pos_player_index = new Tuple<int, int>(pos_player_index.Item1, pos_player_index.Item2 - 1);
                    //overwrite index of item with space -> item has been collected
                    maze.SetValue(' ', pos_player_index.Item1, pos_player_index.Item2);
                    //redraw character
                    p_player.Refresh();
                    break;

                case "down":
                    pos_player_index = new Tuple<int, int>(pos_player_index.Item1, pos_player_index.Item2 + 1);
                    maze.SetValue(' ', pos_player_index.Item1, pos_player_index.Item2);
                    p_player.Refresh();
                    break;

                case "right":
                    pos_player_index = new Tuple<int, int>(pos_player_index.Item1 + 1, pos_player_index.Item2);
                    maze.SetValue(' ', pos_player_index.Item1, pos_player_index.Item2);
                    p_player.Refresh();
                    break;

                case "left":

                    pos_player_index = new Tuple<int, int>(pos_player_index.Item1 - 1, pos_player_index.Item2);
                    maze.SetValue(' ', pos_player_index.Item1, pos_player_index.Item2);
                    p_player.Refresh();
                    break;

                default:
                    break;
            }
            //set direction to default
            direction = null;
        }
    }
}