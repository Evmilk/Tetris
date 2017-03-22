using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    interface IPositions
    {
        string MoveLeft(object data);
        string MoveRight(object data);
       string Down(object data);
        string Switch(object data);
    }
}
