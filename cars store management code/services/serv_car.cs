using cars_store_Datalayer;
using cars_store_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    public class serv_car
    {
        public  static void  getcar()
        {
            using(databasecontext context=new databasecontext())
            {
            var CC=context.tabel_cars.ToList();

                foreach(var item in CC)
                {
                    Console.WriteLine(item.id+".."+
                        item.model+".."+item.year+".."
                        +item.gear+".."+item.KM);
                }
            }
        }

        public static void addcar(string m,string y,string g,string col,double k) 
        {
            using (databasecontext context = new databasecontext())
            {

                Cars cc = new Cars()
                {
                    model = m,
                    year = y,
                    gear = g,
                    KM =k,
                    Color = col
                };
                context.tabel_cars.Add(cc);
                context.SaveChanges();
            }
        }
        //تابع التعديل يستقبل برامترات تتمثل بالرقم الذي اريد البحث من خلاله
        //ويمكن تغييره والبحث من خلال اي خاصية اخرى  
        //بلاضافة للقيم الجديدة للتعديل 
        public static void updatecar(int search,string m,string y,string g,double k,string color)
        {
            using (databasecontext context = new databasecontext())
            {
                var carr = context.tabel_cars
                    .FirstOrDefault(e => e.id == search);
                if (carr != null)
                    //يمكن التغيير في اي خاصية  
                carr.model = m;
                carr.year=y;
                carr.gear = g; 
                carr.KM = k;
                carr.Color = color; 
                context.tabel_cars.Update(carr);
                context.SaveChanges();
            }
        }
        //تابع الحذف تم تمرير الرقم الذي نريد البحث من خلاله ليتم الحذف 
       // ويمكن تغييره والبحث من خلال اي خاصية اخرى
        public static void removecar(int search)
        {
            using (databasecontext context = new databasecontext())
            {
                var carr = context.tabel_cars
                    .FirstOrDefault(e => e.id == search);

                context.tabel_cars.Remove(carr);
                context.SaveChanges();
            }
        }
    }
}
 