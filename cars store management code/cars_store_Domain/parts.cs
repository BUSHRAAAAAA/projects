namespace cars_store_Domain
{
    public class parts

    {
        public parts()
        {
            listcars=new List<Cars> ();
        }
        public int id { get; set; }
        public string partname { get; set; }
        public double price { get; set; }
     
        public int quantity { get; set; }
        public int supplierid { get; set;}
        public List<Cars> listcars { get; set; }    
    }
}