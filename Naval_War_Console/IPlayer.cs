using System;
using System.Collections.Generic;

namespace CS_Naval_War{
    interface IPlayer{

        void BoatIdCopy(Dictionary<int, Boat> pBoatPlace);
        void ShootCopy(Board pBoardShoot);
        Board GetBoatBoard();
        String getPlayerName();
        Boat ChooseBoat(Dictionary<int, Boat.boatEnum> boatList);
        String ChooseCoordinate();
        Board.direcEnum ChooseDirection();
        String WhereToShot();
    }
}