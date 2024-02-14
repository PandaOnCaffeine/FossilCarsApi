namespace FossilCarsApi.Models
{
    public class FossilCar
    {
        public int rank { get; set; }
        public string model { get; set; }
        public int quantity { get; set; }
        public int changeQuantityProcent { get; set; }
        public FossilCar(int rank, string model, int quantity, int changeQuantityProcent)
        {
            this.rank = rank;
            this.model = model;
            this.quantity = quantity;
            this.changeQuantityProcent = changeQuantityProcent;
        }
    }
}
