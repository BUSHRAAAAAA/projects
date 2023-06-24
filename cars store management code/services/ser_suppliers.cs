using cars_store_Datalayer;
using cars_store_Domain;

namespace services
{
    public class ser_suppliers
    {//function reading++++++++++++++++++++++++++++++++++++++++
        public static void getsuppliers()
        {
            using (databasecontext context = new databasecontext())
            {
                var CC = context.tabel_suppliers.ToList();

                foreach (var item in CC)
                {
                    Console.WriteLine(item.id + ".." +
                        item.suppliername + ".." +
                        item.Address);
                }
            }
        }

        //function adding++++++++++++++++++++++++++++++++++++++++
        public static void addsupplier(suppliers cc)
        {
            using (databasecontext context = new databasecontext())
            {
                context.tabel_suppliers.Add(cc);
                context.SaveChanges();
            }
        }
        //function update+++++++++++++++++++++++++++++++++++++++++++++++++++
        public static void updatesupplier(int search,string nam,string address)
        {
            using (databasecontext context = new databasecontext())
            {
                var carr = context.tabel_suppliers
                    .FirstOrDefault(e => e.id == search);
                if (carr != null)
                    // يمكن التغيير في اي خاصية  
                    carr.suppliername = nam;

                carr.Address = address;
                context.tabel_suppliers.Update(carr);
                context.SaveChanges();
            }


        }
        //function remove++++++++++++++++++++++++++++++++++++++++++++++++++
        public static void removesuppliers(int search)
        {

            using (databasecontext context = new databasecontext())
            {
                var carr = context.tabel_suppliers
                    .FirstOrDefault(e => e.id == search);

                context.tabel_suppliers.Remove(carr);
                context.SaveChanges();
            }

        }
    }

}