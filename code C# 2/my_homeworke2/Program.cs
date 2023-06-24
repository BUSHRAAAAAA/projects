using System;
using System.Text;
namespace my_homeworke2
{
    class Program
    {
        public static string get_big_letter(string st)
        {
            StringBuilder sb = new StringBuilder(" ");
            //انشاء كائن من هذا الكلاس من اجل عملية ضم الاحرف الكبيرة معا
            for (int i = 0; i < st.Length; i++)
            // حلقة ليتم الوصول لكل محرف داخل السلسلة
            {
                if (System.Char.IsUpper(st[i]) == true)
                //اختبار فيما اذا لدي حرف كبير حيث اذا
                //تحقق الشرط وكانت النتيجة صحيحة يتم تنفيذ التعليمة التالية  
                {
                    sb.Append(st[i]);// add the big letter using function Append
                    sb.Append(" ");
                }
            }
            return sb.ToString();
        }
      static void Main(string[] args) { 
            Console.Write("enter string    :");
            string st = Console.ReadLine();//ادخال سلسلة نصية من المستخدم 
            Console.WriteLine("======");
            Console.Write("the big letters is :"+get_big_letter(st)+"\n");
            Console.WriteLine("******************************************" + "\n");
            Console.Write("enter string    :");
            string st1 = Console.ReadLine();//ادخال سلسلة نصية من المستخدم 
            Console.WriteLine("===================");
            Console.Write("the big letters is :" + get_big_letter(st1) + "\n");
            Console.WriteLine("******************************************" + "\n");
            Console.Write("enter string    :");
            string st2 = Console.ReadLine();//ادخال سلسلة نصية من المستخدم 
            Console.WriteLine("===================");
            Console.Write("the big letters is :" + get_big_letter(st2) + "\n");
            Console.WriteLine("******************************************" + "\n");
        }
    }
}
