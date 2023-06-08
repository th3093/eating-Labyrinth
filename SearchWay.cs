using System;
using System.Collections.Generic;

namespace eatingAtlabyrinth
{
    /// <summary>
    /// calss SearchWay
    /// </summary>
    internal class SearchWay
    {
        /// <summary>
        /// Field array for way finding
        /// </summary>
        internal Field[,] fields;
        /// <summary>
        /// start field
        /// </summary>
        internal Field start;
        /// <summary>
        /// target field
        /// </summary>
        internal Field dest;
        /// <summary>
        /// information basis
        /// </summary>
        internal SearchInfo searchInfo;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="searchInfo">information basis</param>
        internal SearchWay(SearchInfo searchInfo)
        {
            //init field array
            fields = new Field[searchInfo.info.maze.GetLength(0), searchInfo.info.maze.GetLength(1)];
            for (int i = 0; i < fields.GetLength(0); i++)
            {
                for (int j = 0; j < fields.GetLength(1); j++)
                {
                    fields[i, j] = new Field(new Tuple<int, int>(i, j), searchInfo.destinationPoint);
                }
            }
            this.searchInfo = searchInfo;
            this.start = this.fields[searchInfo.startPoint.Item1,searchInfo.startPoint.Item2];
            this.start.fieldinf = FieldInfo.Open;
            this.dest = this.fields[searchInfo.destinationPoint.Item1, searchInfo.destinationPoint.Item2];
        }
        /// <summary>
        /// start way finding
        /// </summary>
        /// <returns>way</returns>
        internal Stack<Tuple<int,int>> FindWay()
        {
            //Stack with waypoints
            Stack<Tuple<int,int>> way = new Stack<Tuple<int,int>>();
            //check if way exists
            bool success = Search(start);
            if (success)
            {
                Field tmp = this.dest;
                while (tmp.ancestor!=null)
                {
                    way.Push(tmp.position);
                    tmp = tmp.ancestor;
                }
            }
            return way;
        }
        /// <summary>
        /// filter ways by lengths
        /// </summary>
        /// <param name="current"></param>
        /// <returns>use field</returns>
        internal bool Search(Field current)
        {
            current.fieldinf = FieldInfo.Closed;
            List<Field> nextstep = Surrounding(current);
            nextstep.Sort((field1, field2) => field1.f.CompareTo(field2.f));
            foreach (Field next in nextstep)
            {
                if (next.position == this.dest.position)
                {
                    return true;
                }
                else
                {
                    if (Search(next))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// filter possibilites and sort by efficiency
        /// </summary>
        /// <param name="fd"></param>
        /// <returns></returns>
        internal List<Field> Surrounding(Field fd)
        {
            List<Field> possible = new List<Field>();
            IEnumerable<Tuple<int, int>> next = SurroundingPoints(fd.position);

            foreach (Tuple<int,int> position in next)
            {
                int x=position.Item1;
                int y=position.Item2;
                if (x<0||x>=searchInfo.info.maze.GetLength(0)||y<0||y>=searchInfo.info.maze.GetLength(1))
                {
                    continue;
                }
                Field tmp = this.fields[x, y];
                if (searchInfo.info.maze[tmp.position.Item1,tmp.position.Item2] == '#')
                {
                    continue;
                }
                if (tmp.fieldinf == FieldInfo.Closed)
                {
                    continue;
                }
                if (tmp.fieldinf == FieldInfo.Open)
                {
                    float distance = Field.Distance(tmp.position, tmp.ancestor.position);
                    float g_tmp = fd.g + distance;
                    if (g_tmp < tmp.g)
                    {
                        tmp.ancestor = fd;
                        possible.Add(tmp);
                    }
                }
                else
                {
                    tmp.ancestor = fd;
                    tmp.fieldinf = FieldInfo.Open;
                    possible.Add(tmp);
                }                
            }
            return possible;
        }
        /// <summary>
        /// list surroinding points reachable by 1 step
        /// </summary>
        /// <param name="t">reference point</param>
        /// <returns>reachable points</returns>
        internal static IEnumerable<Tuple<int,int>> SurroundingPoints(Tuple<int,int> t)
        {
            return new Tuple<int, int>[]
            {
                new Tuple<int, int>(t.Item1 - 1, t.Item2),
                new Tuple<int, int>(t.Item1, t.Item2 - 1),
                new Tuple<int, int>(t.Item1 + 1, t.Item2),
                new Tuple<int, int>(t.Item1, t.Item2 + 1),
            };
        }
    }
}

