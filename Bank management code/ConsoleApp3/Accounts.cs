using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
   public class Account

    {
        public double balance;
        public bool isclosed;
       string createdate;

        public  virtual void delete ()
        {//تابع من  اجل عملية اغلاق الحساب في حال كان الرصيد يساوي الصفر
        if(balance == 0) { isclosed = true; }
         else
            { 
                isclosed = false;
                Console.WriteLine("the balance is not empty");
            
            }
        }
    }



    public class BasicAccount : Account

    {
     //   double balance;
        public double deposite(double d)
            //يتم ايداع مبلغ معين واضافته للرصيد الكلي وتكون النتيجةلعمل التابع
            //هي الرصيد النهائي 
        {

            return balance += d;
        }

        public double widthdrow(double w)
        {

              if (balance == 0)//no found balanceفي حال لم يوجد رصيد يتم طباعةالرسالة
            {
                Console.WriteLine(" no found balance");
                return 0;
            }
            else if (w > balance)//في حال كان المبلغ المراد سحبه اكبر من الرصيد الوجود
            {
                Console.WriteLine("insufficient founds to widthdrow");
                return 0;
            }
           
            else
            {//وعندما يكزن لدي رصيد يتم السحب ويعيد التابع القيمة النهائية للرصيد المتبقي
                return balance -= w;
            }


        }
   
    }
    public class SavingAccount : Account

    {
       // double balance;
        public double deposite(double d)
        //يتم ايداع مبلغ معين واضافته للرصيد الكلي وتكون النتيجةلعمل التابع
        //هي الرصيد النهائي 
        {
            {
            balance += d;
            return balance;
        }

      
    }



    public class loanAccount : Account


    {
        //double balance;
        public double deposite(double d)

        {
            balance += d;
            return balance;
        }



        public double widthdrow(double w)
        {
            //شرط لمعالجة عملية السحب اكثر من مقدار معين 
            
            balance -= w;
            if (balance < -1500)
            {
                Console.WriteLine("no can to widthdrow");
                return 0;
            }
            else

                return balance;

        }
    
      
    }
    public class SalaryAccount : Account

    {
        //double balance;
        public double widthdrow(double w)
        {
            //في حال كان لايوجد رصيد 
             if (balance == 0)
            {
                Console.WriteLine(" no found balance");
                return 0;
            }
            else if(w > balance)
            {
                Console.WriteLine("insufficient founds to widthdrow");
                return 0;
            }
          
            else
            {
                return balance -= w;
            }


        }
      
    }
}
