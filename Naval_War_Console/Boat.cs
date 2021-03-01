namespace CS_Naval_War{  
    public class Boat{
        
        public enum boatEnum{ CARRIER, BATTLESHIP, CRUISER, SUBMARINE, DESTROYER,}
        public string name;
        public int size;
        public int hp;
        internal Boat(string bName, int bSize, int bHp){
            this.name = bName;
            this.size = bSize;
            this.hp   = bHp;
        }

        public int takeDamage(){
            this.hp = hp - 1;
            return hp;
        }

        public bool isAlive(){
            return this.hp != 0;
        }
    }

    public class BoatFactory{
        static public Boat MakeCarrier(){
            return new Boat("Carrier", 5, 5);            
        }
        static public Boat MakeBattleship(){
            return new Boat("Battleship", 4, 4);            
        }
        static public Boat MakeCruiser(){
            return new Boat("Cruiser", 3, 3);            
        }
        static public Boat MakeSubmarine(){
            return new Boat("Submarine", 3, 3);            
        }
        static public Boat MakeDestroyer(){
            return new Boat("Destroyer", 2, 2);            
        }
    }
}