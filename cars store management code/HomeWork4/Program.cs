using cars_store_Datalayer;
using Microsoft.EntityFrameworkCore;
using services;
using cars_store_Domain;

public class Program
{
    public static void Main(string[] args)
    {//باستخدام عملية ميكريشن تم انشاء قاعدة البيانات واضافة الجداول بشكل كامل

        /////add car +++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        serv_car.addcar("van", "2008", "speed", "white", 144);

        //update car+++++++++++++++++++++++++++++++++++++++++++++++++++++++

        serv_car.updatecar(11, "mm", "2009", "increas_speed", 166, "white");


        // add part+++++++++++++++++++++++++++++++++++++++++++++++++++++
        parts pp = new parts()
        {
            partname = "aaaa",
            price = 123,
            quantity = 1,
            supplierid = 2
        };
        ser_part.addparts(pp);

        //add suppler+++++++++++++++++++++++++++++++++++++++++++++++++++
        suppliers ss = new suppliers()
        {
            suppliername = "ahmad",
            Address = "azaz"
        };
        ser_suppliers.addsupplier(ss);
    }

    }