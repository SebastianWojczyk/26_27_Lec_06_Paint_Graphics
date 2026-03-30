using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Paint_Graphics
{
    // Represents a sequence of points drawn with a specific pen.
    internal class MyLine
    {
        private readonly List<Point> points;
        private readonly Pen pen;
        
        public int Count => points.Count;

        public Pen Pen => pen;

        public MyLine(Pen pen)
        {
            // Clone the pen to ensure that changes to the original pen do not affect this line.
            this.pen = (Pen)pen.Clone();
            points = new List<Point>();
        }
        public void AddPoint(Point point)
        {
            points.Add(point);
        }

        // Indexer for read access to points.
        public Point this[int index]
        {
            get
            {
                //ToDo chceck index range
                return points[index];
            }
        }
    }
}
