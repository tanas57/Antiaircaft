using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyun
{
    class Bullet : Item
    {
        public Bullet(int x, int y)
        {
            setSize(25, 25);     // size of bullet
            setType(2);          // type 2 : bullet
            setCoord(x, y);      // set coordinates
            setIMG("bullet.png");// set image
            setTime(250);        // bullet speed is 250ms
            createPicture();     // create and print
        }
    }
}
