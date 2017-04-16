
namespace Oyun
{
    class Gamer : Item
    {
        public Gamer(int x, int y)
        {
            setSize(50, 50);    // size of gamer
            setType(3);         // type 3 : gamer
            setCoord(x, y);     // set coordinates
            setIMG("gamer.png");// set images
            createPicture();    // create and print
        }
        // movement operations
        public bool moveLeft()
        {
            if (getLeft() > 0)
            {
                setLeft(getLeft() - 1);
                return true;
            }
            return false;
        }
        public bool moveRight()
        {
            if (getLeft() < 29)
            {
                setLeft((getLeft() + 1));
                return true;
            }
            return false;
        }
    }
}
