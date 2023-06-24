using cars_store_Datalayer;
using cars_store_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    public class ser_part
    {
        public static void getpart()
        {
            using (databasecontext context = new databasecontext())
            {
                var CC = context.tabel_parts.ToList();

                foreach (var item in CC)
                {
                    Console.WriteLine(item.id + ".." +
                        item.partname + ".." +
                        item.price + ".."+
                        item.quantity + ".." +
                        item.supplierid);
                }
            }
        }



        //تابع الاضافة بحيث تم تمرير نسخة كاملة من الكلاس لينم اضافتها
        public static void addparts(parts cc)
        {
            using (databasecontext context = new databasecontext())
            {
                context.tabel_parts.Add(cc);
                context.SaveChanges();
            }
        }
        //تابع التعديل يستقبل برامترات تتمثل بالرقم الذي اريد البحث من خلاله
        //ويمكن تغييره والبحث من خلال اي خاصية اخرى  
        //بلاضافة للقيم الجديدة للتعديل 
        public static void updatecar(int search, string m, double price, int q, int idsupp)
        {
            using (databasecontext context = new databasecontext())
            {
                var carr = context.tabel_parts
                    .FirstOrDefault(e => e.id == search);
                if (carr != null)
                    //يمكن التغيير في اي خاصية  
                    carr.partname = m;
                carr.price = price;
                carr.quantity=q;
                carr.supplierid=idsupp;
                
                context.tabel_parts.Update(carr);
                context.SaveChanges();
            }
        }
        //تابع الحذف تم تمرير الرقم الذي نريد البحث من خلاله ليتم الحذف 
        // ويمكن تغييره والبحث من خلال اي خاصية اخرى
        public static void removpart(int search)
        {
            using (databasecontext context = new databasecontext())
            {
                var carr = context.tabel_parts
                    .FirstOrDefault(e => e.id == search);

                context.tabel_parts.Remove(carr);
                context.SaveChanges();
            }
        }
    }


   

}
