using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class costomer
    {
       
        
         public string firstName;
        public string lastName; 
        public DateTime birthdate;
        public string phoneNumber;
        public string email;
        public bool isdelete=false;
        //     (object)كل حساب مضاف الى الليستا هو  
        //  (Account)من الكلاسات الثلاثةالتي تورث من الكلاس  
        public List<Account> accounts=new List<Account>();

        public virtual void del_costomer()
        {
            double sum = 0;
            //يتم حذف العميل عندا يتم التأكد ان جميع الحسابات التابعة له فارغة
            //ولايوجد اي رصيد في جميع حساباته

            foreach (var acc in accounts)
                sum = sum + acc.balance;

            if (sum == 0)
                this.isdelete = true;//اي انه في حال وجود رصيد في اي حساب لايتم حذفه
        }
        public virtual void tostring()
        {
            //في حال كان لدي العميل محذوف لايتم القيام باي عملية 
            if (isdelete==true)
                Console.WriteLine(" the costomer is deleted");
            else

            {
                double sum = 0;

                foreach (var acc in accounts)
                    sum += acc.balance;

                Console.WriteLine("the name is :" + firstName + lastName +
                        "__ the total balance for all the accounts  " + sum);
            }

        }

    }
    public class individualcostomer:costomer
    {
        
        public string homeAddress;
        public string workAddress;

        public individualcostomer(string fs, string ls, string ph, string em,string h)
        {//تمت اضافة باني لتهيئة متحولات الكلاس
           firstName = fs;
            lastName = ls;
            phoneNumber = ph;          
            email = em;
            homeAddress = h;
        }
        public override void del_costomer()
        {
            base.del_costomer();
        }
        public override void tostring()
        {
            base.tostring();
        }

    }
    public class retailcostomer:costomer
        
    {
        public string companyAddress;
        public retailcostomer(string fs, string ls, string ph, string em ,string comp)
        {
            
            this.firstName = fs;
            this.lastName = ls;
            this.phoneNumber = ph;
            this.email = em;
            this.companyAddress = comp;
        }
        public  override  void del_costomer()
        {
            base.del_costomer();
        }

            public void tostring()
        {//
         //التنفيذ يتم بحسب التابع في الكلاس الاساسي الذي تمت الوراثة منه
            base.tostring();
        }
                 
    }
}


