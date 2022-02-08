using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    /// <summary>
    /// Setting Name to the snake + keeping track of the points
    /// Important to make sure that the Posistions are inside of Console window.
    /// </summary>
    internal class Points
    {
        public Position pos;
        public int points;
        public string name;
       /// <summary>
       /// Empty Konstruktor should mainly be used for testing
       /// </summary>
        public Points()
        {
            pos = new Position { x = 0, y = 0 };
            this.points = 0;
            name =  "Bamse";
        }
        public Points(int points, string n ,Position position)
        {
            pos = new Position { x = position.x, y = position.y };
            this.points = points;   
            this.name = n;
        }

        public void AddPoints()
        {
            this.points++;  
        }

        public override string ToString()
        {
            return $"{name}: {points}";
        }

    }
}
