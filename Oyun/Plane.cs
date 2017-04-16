using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyun
{
    class Plane : Item
    {
        public Plane(int x, int y)
        {
            setSize(50, 50);            // size of empty area
            setType(1);                 // type 1 : plane
            setCoord(x, y);             // set coordinates
            setIMG("war-plane.png");    // set image
            setTime(500);               // plane speed
            createPicture();            // create and print
        }
    }
}
