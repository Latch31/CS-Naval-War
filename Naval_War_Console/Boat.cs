namespace CS_Naval_War{  
    public class Boat{
        
        public enum boatEnum{ CARRIER, BATTLESHIP, CRUISER, SUBMARINE, DESTROYER,}
        public string name;
        public int size;
        internal Boat(string bName, int bSize){
            this.name = bName;
            this.size = bSize;
        }
    }

    public class BoatFactory{
        static public Boat MakeCarrier(){
            return new Boat("Carrier", 5);            
        }
        static public Boat MakeBattleship(){
            return new Boat("Battleship", 4);            
        }
        static public Boat MakeCruiser(){
            return new Boat("Cruiser", 3);            
        }
        static public Boat MakeSubmarine(){
            return new Boat("Submarine", 3);            
        }
        static public Boat MakeDestroyer(){
            return new Boat("Destroyer", 2);            
        }
    }
}