using ConsoleApp3;

internal class Program
{

    public static void Main(string[] args)
    {
        // retailcostomer انشاء كائن من الكلاس 
        retailcostomer retail1 = new retailcostomer("bushtra",
            "abdullah",
            "090553777888",
            "bushra333@gmail.com",
            "programming");
        //انشاء ثلاثة انواع مختلفة من الحسابات
        BasicAccount basic1 = new BasicAccount();
        SavingAccount save1 = new SavingAccount();
        loanAccount loan1 = new loanAccount();


        // retail1 اسناد الحسابات الثلاثة لهذا لعميل 
        retail1.accounts.Add(basic1);
        retail1.accounts.Add(save1);
        retail1.accounts.Add(loan1);
        //اضافة مبلغ 100 لكل حساب على حدى 
        basic1.deposite(100);
        save1.deposite(100);
        loan1.deposite(100);
        //withdraw 60 from 2 accontes

        basic1.widthdrow(60);
        loan1.widthdrow(60);
        // Call retalCustomer.ToString() to print FullName and total Balance 
        retail1.tostring();

        //#######################################################################/
        // Deine an Individual Customer 
        individualcostomer individu1 = new individualcostomer("bb","abdullah","90553777888"
            ,"bushra333@gmail.com","Azaz");


        //Create 4 different accounts with 4 different types 
        BasicAccount basic2 = new BasicAccount();
        SavingAccount save2 = new SavingAccount();
        loanAccount loan2 = new loanAccount();
        SalaryAccount salary = new SalaryAccount();


        //assign the created accounts to the "individual Customer" 

        individu1.accounts.Add(basic2);
        individu1.accounts.Add(save2);
        individu1.accounts.Add(loan2);
        individu1.accounts.Add(salary);

        //Deposite the(depositable) accounts with 200
        basic2.deposite(200);
        save2.deposite(200);
        loan2.deposite(0);

        // WithDraw 80 From Two Accounts 
        basic2.widthdrow(80);
        loan2.widthdrow(80);
        // Call individualCustomer.ToString() to print FullName and total Balance 
        individu1.tostring();

    }
}