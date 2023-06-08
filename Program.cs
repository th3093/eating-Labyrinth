using System;
using System.Windows.Forms;
using System.IO;

namespace eatingAtlabyrinth
{
    /// <summary>
    /// class programm
    /// </summary>
    static class Program
    {
        /// <summary>
        /// entry point of application
        /// </summary>
        [STAThread]
        static void Main(string[]args)
        {
            string[]rawdata;
            //read path from console
            if (args.Length!=0)
            {
                rawdata=File.ReadAllLines(args[0]);
            }
            //if no path, take standard labyrinth
            else
            {
                char[] sep = { '\n' };
                if (!File.Exists("GameEnv_ChangeLog.txt"))
                {
                    rawdata = File.ReadAllLines("maze.dat");
                }
                else
                {
                    rawdata = File.ReadAllLines(File.ReadAllLines("GameEnv_ChangeLog.txt")[0]);
                    File.Delete("GameEnv_ChangeLog.txt");
                }
            }            
            //init columns and rows
            int column;
            int row;
            column=Int32.Parse(rawdata[0]);
            row=Int32.Parse(rawdata[1]);
            //game map as 2D-Array
            char [,] maze=new char[column,row];
            //write map to 2D-Array
            for (int i = 2; i < row+2; i++)
            {
                for(int j=0;j<column;j++)
                {
                    maze[j,i-2]=rawdata[i][j];
                }
            }
            //start application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu_Form(maze));
        }
    }
}

