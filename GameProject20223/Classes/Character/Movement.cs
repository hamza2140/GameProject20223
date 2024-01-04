using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject20223.Classes.Character
{
    public enum VerticalDirection
    {
        Up, Down
    }
    public enum HorizontalDirection
    {
        Right, Left
    }
    public class Movement
    {
        public HorizontalDirection HDirection { get; set; }
        public VerticalDirection VDirection { get; set; }
    }
}
