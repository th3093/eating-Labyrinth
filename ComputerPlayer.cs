using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;

namespace eatingAtlabyrinth
{
    /// <summary>
    /// class ComputerPlayer for calculating way finding
    /// </summary>
    internal class ComputerPlayer
    {
        /// <summary>
        /// char Array maze with labyrinth
        /// Point Array grid with labyrinths points
        /// Field Array fields
        /// </summary>
        internal char[,] maze { get; set; }
        internal Point[,] grid { get; set; }
        internal static Field newDest = new Field(new Tuple<int, int>(0, 0), new Tuple<int, int>(0, 0));
        internal Field[,] fields;

        /// <summary>
        /// constructor for solving information basis (Labyrinth and Positions)
        /// </summary>
        /// <param name="maze">Labyrinth</param>
        /// <param name="grid">positions on screen</param>
        internal ComputerPlayer(char[,] maze, Point[,] grid)
        {
            this.maze = maze;
            this.grid = grid;
            this.fields = new Field[maze.GetLength(0), maze.GetLength(1)];
            for (int i = 0; i < fields.GetLength(0); i++)
            {
                for (int j = 0; j < fields.GetLength(1); j++)
                {
                    fields[i, j] = new Field(new Tuple<int, int>(0, 0), new Tuple<int, int>(0, 0));
                    //felder[i, j].feldinf = FeldInfo.Open;
                }
            }
        }
        /// <summary>
        /// set start and endpoints of individual way solving
        /// </summary>
        /// <param name="cp">information basis</param>
        /// <param name="start">start position</param>
        /// <returns>solved way from pos x to pos y</returns>
        internal static Stack<Tuple<int, int>> FindWay(ComputerPlayer cp, Tuple<int, int> start)
        {
            //Zielpunkt
            Field destination = new Field(new Tuple<int, int>(0, 0), new Tuple<int, int>(0, 0));
            //Startpunkt
            Tuple<int, int> startPoint;
            Stack<Tuple<int, int>> way = new Stack<Tuple<int, int>>();
            //check if items left
            bool items = true;
            if (items)
            {
                //search next item---------------------------------------------------
                destination.h = 10000f;
                Tuple<int, int> tmp = start;
                
                items = false;
                for (int i = 0; i < cp.maze.GetLength(0); i++)
                {
                    for (int j = 0; j < cp.maze.GetLength(1); j++)
                    {
                        if (cp.maze[i, j] == '.')
                        {
                            Field temp = new Field(new Tuple<int, int>(i, j), new Tuple<int, int>(0, 0));
                            temp.h = Math.Abs(Field.Distance(temp.position, tmp));
                            //set new target
                            if (destination.h > temp.h)
                            {
                                destination = temp;
                                items = true;
                            }
                        }
                    }
                }                                 
                tmp = destination.position;
                //-------------------------------------------------------------------
                //find way to this item           
                startPoint = start;
                SearchInfo next = new SearchInfo(startPoint, destination.position, cp);
                SearchWay _way = new SearchWay(next);
                way = _way.FindWay();
            }
            return way;
        }
        /// <summary>
        /// search next item
        /// </summary>
        /// <param name="t">current Position</param>
        /// <param name="cp">information basis</param>
        /// <returns>next target</returns>
        internal static Field NextDestination(Tuple<int, int> t, ComputerPlayer cp)
        {
            bool change = false;
            Field current = new Field(t, new Tuple<int, int>(0, 0));       
            //get possible steps
            IEnumerable<Tuple<int, int>> next = SearchWay.SurroundingPoints(current.position);
            //check if possible and lead to item
            foreach (Tuple<int, int> pos in next)
            {   
                int x = pos.Item1;
                int y = pos.Item2;
                Field tmp;
                try
                {
                    tmp = cp.fields[x, y];
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
                tmp.position = new Tuple<int, int>(x, y);
                if (x < 0 || x >= cp.maze.GetLength(0) || y < 0 || y >= cp.maze.GetLength(1))
                {
                    continue;
                }
                else
                {
                    if (cp.maze[tmp.position.Item1, tmp.position.Item2] == '#')
                    {
                        continue;
                    }
                    else
                    {
                        if (cp.maze[tmp.position.Item1, tmp.position.Item2] == '.' || cp.maze[tmp.position.Item1, tmp.position.Item2] == ' ')
                        {
                            newDest.position = tmp.position;
                            change = true;
                            break;
                        }
                    }
                }                 
            }
            //if no match, search for next closest item
            if (!change)
            {
                newDest.h = 10000f;
                for (int i = 0; i < cp.maze.GetLength(0); i++)
                {
                    for (int j = 0; j < cp.maze.GetLength(1); j++)
                    {
                        if (cp.maze[i, j] == '.')
                        {                           
                            Field temp = new Field(t, new Tuple<int, int>(i, j));
                            temp.h = Field.Distance(t, temp.position);
                            if (newDest.h > temp.h)
                            {
                                newDest = temp;
                            }
                        }                        
                    }
                }               
            }
            return newDest;
        }
    }      
}



