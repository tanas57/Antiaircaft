namespace Oyun
{
    class Space : Item
    {
        public Space(int x, int y)
        {
            setSize(25, 25);     // size of empty area
            setType(4);          // type 4 : space
            setCoord(x, y);      // set coordinates
            setIMG("empty.png"); // set image
            setTime(0);          // there is no timer
            createPicture();     // create and print
        }
    }
}
