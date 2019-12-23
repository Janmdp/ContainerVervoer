namespace ContainerVervoerClassLibrary
{
    public class Container
    {
        //fields
        private int weight;

        private CargoType.Cargo cargoType;
        private int id;
        private static int nextId = 1;

        //constructor
        public Container(int weight, CargoType.Cargo cargoType)
        {
            this.weight = weight;
            this.cargoType = cargoType;
            this.id = nextId;
            nextId++;
        }

        //properties
        public int Weight { get => weight; set => weight = value; }

        public CargoType.Cargo CargoType { get => cargoType; set => cargoType = value; }
        public int Id { get => id; }

        //methods
        public override string ToString()
        {
            return $"Container {id}, {CargoType.ToString()}";
        }
    }
}