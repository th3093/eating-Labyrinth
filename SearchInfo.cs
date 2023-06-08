using System;

namespace eatingAtlabyrinth
{
    /// <summary>
    /// class for information basis
    /// </summary>
    internal class SearchInfo
    {
        /// <summary>
        /// start point
        /// </summary>
        internal Tuple<int, int> startPoint { get; set; }
        /// <summary>
        /// destination point
        /// </summary>
        internal Tuple<int, int> destinationPoint { get; set; }
        /// <summary>
        /// information basis
        /// </summary>
        internal ComputerPlayer info { get; set; }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="startPoint">start point</param>
        /// <param name="destinationPoint">destination point</param>
        /// <param name="info">information basis</param>
        internal SearchInfo(Tuple<int, int> startPoint, Tuple<int, int> destinationPoint, ComputerPlayer info)
        {
            this.startPoint = startPoint;
            this.destinationPoint = destinationPoint;
            this.info = info;
        }
    }
}
