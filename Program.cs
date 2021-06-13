using System;
using Calculation; // first class in a an folder 

namespace Program
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Switch Methode");
            string weekday = Switch_Method(1);
            Console.WriteLine(weekday);
            string if_test = IF_Method(false);
            Console.WriteLine(if_test);
            int result = Calc.Add(1,2);
            Console.WriteLine("1+2 = " + result);

            test_class tc = new test_class(7);
            int Test = tc.Test(5);
            Console.WriteLine(Test);

            Console.WriteLine(string.Format("Wochentag: {0} Tageszeit: {1}", weekday, if_test));
            tc.Name = 30;
            Console.WriteLine(tc.Name);
        }

         static string Switch_Method(int day)
        {

            string weekday;

            switch(day)
            {
                case 1:
                    weekday = "Montag";
                    break;
                case 2:
                    weekday = "Dienstag";
                    break;               
                case 3:
                    weekday = "Mittwoch";
                    break; 
                default:
                    weekday = "none";
                    break;
            }
            return weekday;       
        }

        
        static string IF_Method(bool part_of_day)
        {
            string day_time;
        
            if(part_of_day)
            {
                day_time = "tag";
            }
            else
            {
                day_time = "nacht";
            }
            return day_time;
        }
    }
}
