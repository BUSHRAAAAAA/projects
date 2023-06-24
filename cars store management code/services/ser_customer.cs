using cars_store_Datalayer;
using cars_store_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    public class ser_customer
    {
        public static void getcustomer()
        {
            using (databasecontext context = new databasecontext())
            {
                var CC = context.tabel_Costomer.ToList();

                foreach (var item in CC)
                {
                    Console.WriteLine(item.id+ ".." +
                        item.name+ ".." + item.age + ".."
                        + item.Address );
                }
            }
        }


        public static void addcostomer(coustomer cc)
        {
            using (databasecontext context = new databasecontext())
            {
                context.tabel_Costomer.Add(cc);
                context.SaveChanges();
            }
        }
        //تابع التعديل يستقبل برامترات تتمثل بالرقم الذي اريد البحث من خلاله
        //ويمكن تغييره والبحث من خلال اي خاصية اخرى  
        //بلاضافة للقيم الجديدة للتعديل 
        public static void updatecar(int search, string nam, int age, string address)
        {
            using (databasecontext context = new databasecontext())
            {
                var carr = context.tabel_Costomer
                    .FirstOrDefault(e => e.id == search);
                if (carr != null)
                    //يمكن التغيير في اي خاصية  
                carr.name = nam;
                carr.age=age;
                carr.Address= address;
                context.tabel_Costomer.Update(carr);
                context.SaveChanges();
            }
        }
        //تابع الحذف تم تمرير الرقم الذي نريد البحث من خلاله ليتم الحذف 
        // ويمكن تغييره والبحث من خلال اي خاصية اخرى
        public static void removecostomer(int search)
        {
            using (databasecontext context = new databasecontext())
            {
                var carr = context.tabel_Costomer
                    .FirstOrDefault(e => e.id == search);

                context.tabel_Costomer.Remove(carr);
                context.SaveChanges();
            }
        }
    }
}
