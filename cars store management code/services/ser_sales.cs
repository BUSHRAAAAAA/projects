using cars_store_Datalayer;
using cars_store_Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
   public class ser_sales

    {       // function reading++++++++++++++++++++++++++++++++++++++
        public static void getsales()
        {
            using (databasecontext context = new databasecontext())
            {
                var CC = context.tabel_sales.ToList();

                foreach (var item in CC)
                {
                    Console.WriteLine(item.id + ".." +
                        item.total + ".." +
                        item.carid + ".." +
                        item.coustomerid );
                }
            }
        }
        //function adding++++++++++++++++++++++++++++++++++++++++
        public static void addsales(sales cc)
        {
            using (databasecontext context = new databasecontext())
            {
                context.tabel_sales.Add(cc);
                context.SaveChanges();
            }
        }

        //function update+++++++++++++++++++++++++++++++++++++++++++++++++++
        public static void updatesales(int search, int total, int idcar, int idcos)
        {
            using (databasecontext context = new databasecontext())
            {
                var carr = context.tabel_sales
                    .FirstOrDefault(e => e.id == search);
                if (carr != null)
                    // يمكن التغيير في اي خاصية  
                    carr.total = total;
                carr.carid = idcar;
                carr.coustomerid = idcos;

                context.tabel_sales.Update(carr);
                context.SaveChanges();
            }


        }
        //function remove++++++++++++++++++++++++++++++++++++++++++++++++++
        public static void removesales(int search)
        {

            using (databasecontext context = new databasecontext())
            {
                var carr = context.tabel_sales
                    .FirstOrDefault(e => e.id == search);

                context.tabel_sales.Remove(carr);
                context.SaveChanges();
            }

        }
       
    }
}

