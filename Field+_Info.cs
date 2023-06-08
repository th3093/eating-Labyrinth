using System;

namespace eatingAtlabyrinth
{
    /// <summary>
    /// class Field
    /// </summary>
    internal class Field
    {
        /// <summary>
        /// Position index
        /// </summary>
        internal Tuple<int, int> position { get; set; }
        /// <summary>
        /// way from start in turns
        /// </summary>
        internal float g { get; set; }
        /// <summary>
        /// estimated way to end in turns
        /// </summary>
        internal float h { get; set; }
        /// <summary>
        /// total way in turns
        /// </summary>
        internal float f { get{return this.g + this.h; } }
        /// <summary>
        /// Information on status of field
        /// </summary>
        internal FieldInfo fieldinf { get; set; }
        /// <summary>
        /// field ancestor
        /// </summary>
        internal Field ancestor;
        internal Field Ancestor{
            get { return this.ancestor; }
            set{
            this.ancestor = value;
            this.g = this.ancestor.g + Distance(this.position,this.ancestor.position);
            }
        }
        /// <summary>
        /// Field constructor
        /// </summary>
        /// <param name="pos">current postition</param>
        /// <param name="dest">target position</param>
        internal Field(Tuple<int,int>pos, Tuple<int,int>dest){
            this.position = pos;
            this.fieldinf = FieldInfo.Unknown;
            this.h = Distance(this.position, dest);
            this.g = 0;
        }
        /// <summary>
        /// direct distance of two fields
        /// </summary>
        /// <param name="t1">Field 1</param>
        /// <param name="t2">Field 2</param>
        /// <returns></returns>
        internal static float Distance(Tuple<int, int> t1, Tuple<int, int> t2)
        {
            float x = t2.Item1 - t1.Item1;
            float y = t2.Item2 - t1.Item2;
            return (float)Math.Sqrt(x * x + y * y);
        }
    }
    /// <summary>
    /// declaration of states
    /// </summary>
    internal enum FieldInfo { Unknown, Open, Closed } 
}
