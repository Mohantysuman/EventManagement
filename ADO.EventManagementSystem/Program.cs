using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.EventManagement
{
    internal class Program
    {

        static void Main(string[] args)
        {

            SuperAdmin sadmin = new SuperAdmin();
            Admins admins = new Admins();
            Customer customer = new Customer();
            while (true)
            {
                Console.WriteLine("for super admin press 1");
                Console.WriteLine("for  admin press 2");
                Console.WriteLine("for customer admin press 3");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    sadmin.Handle();
                }
                else if (choice == 2)
                {
                    admins.Handle();
                }
                else if (choice == 3)
                {
                    customer.Handle();
                }
                else
                {
                    Console.WriteLine("Enter a Valid Input");
                }

            }

            //sadmin.AddAdmin();

            // admins.Login();
            // admins.AddEvent();
            //admins.AddFoodItems();
            //admins.AddDecorItems();
            // admins.AddNecessaryItems();
            // admins.ShowAllItmes();
            // admins.ShowEvents();


            // customer.Register();
            //customer.Login();
        }
    }
}