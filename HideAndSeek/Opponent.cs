using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeek
{
    class Opponent
    {
        private Location myLocation;
        private Random random;
        public Opponent(Location startingLocation)
        {
            myLocation = startingLocation;
            random = new Random();
        }

        public void Move()
        {
            bool hidden = false;
            while (!hidden)
            {
                if (myLocation is IHasExteriorDoor)
                {
                    IHasExteriorDoor locationWithDoor = myLocation as IHasExteriorDoor;
                    if (random.Next(2) == 1 || myLocation.Exits.Length == 0)
                        myLocation = locationWithDoor.DoorLocation;
                }
                if (myLocation.Exits.Length > 0)
                {
                    int rand = random.Next(myLocation.Exits.Length);
                    myLocation = myLocation.Exits[rand];
                }

                if (myLocation is IHidingPlace)
                    hidden = true;
            }
        }

        public bool Check(Location locationToCheck)
        {
            if (locationToCheck != myLocation)
            {
                return false;
            }
            return true;
        }
    }
}
