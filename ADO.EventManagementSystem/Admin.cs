using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Ado.EventManagementSystem
{
    internal class Admin
    {
        public static string dataConstr = @"Data Source=LAPTOP-MIL5M1L9;Initial Catalog=Admin;Integrated Security=True";

        public void Handle()
        {
            Login();
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("enter 1 to see the events options ");
                Console.WriteLine("enter 2 to see the options");
                Console.WriteLine("enter 3 to add event");
                Console.WriteLine("enter 4 to add food packages");
                Console.WriteLine("enter 5 to add decor packages");
                Console.WriteLine("enter 6 to add extra Premium packages");
                Console.WriteLine("etner 7 to logout");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1: ShowEvents(); break;
                    case 2: ShowAllItmes(); break;
                    case 3: AddEvent(); break;
                    case 4: AddFoodItems(); break;
                    case 5: AddDecorItems(); break;
                    case 6: AddNecessaryItems(); break;
                    case 7: return;
                    default: Console.WriteLine("Please Enter a valid input"); break;

                }
            }


        }

        public void Login()
        {
            DataTable dt = new DataTable();
            Console.WriteLine("enter your name");
            string name = Console.ReadLine();
            Console.WriteLine("enter password");
            string pass = Console.ReadLine();
            SqlConnection sq = new SqlConnection(dataConstr);
            SqlCommand cmd = new SqlCommand("select * from admins where aname='" + name + "' and apassword='" + pass + "'", sq);
            sq.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            sq.Close();

            if (dt.Rows.Count > 0)
            {
                Console.WriteLine("Welcome  " + dt.Rows[0][1]);
                Menu();
            }
            else
            {
                Console.WriteLine("Either Username or Password is Wrong");
                return;
            }
        }
        public void AddEvent()
        {

            Console.WriteLine("enter a event name to be added");
            string eventname = Console.ReadLine();
            Console.WriteLine("fees to conduct the event ");
            string price = Console.ReadLine();
            SqlConnection sq = new SqlConnection(dataConstr);
            SqlCommand cmd = new SqlCommand("insert into eventtable values('" + eventname + "','" + price + "')", sq);
            sq.Open();
            int res = cmd.ExecuteNonQuery();
            sq.Close();
            if (res > 0)
            {
                Console.WriteLine("Event successfully added!");
            }
        }
        public void AddFoodItems()
        {
            Console.WriteLine("Enter a food item to be added");
            string food = Console.ReadLine();
            Console.WriteLine("enter the price for the food");
            string price = Console.ReadLine();
            SqlConnection sq = new SqlConnection(dataConstr);
            SqlCommand cmd = new SqlCommand("insert into fooditems values('" + food + "','" + price + "')", sq);
            sq.Open();
            int res = cmd.ExecuteNonQuery();
            sq.Close();
            if (res > 0)
            {
                Console.WriteLine("food added successfully");
            }
        }

        public void AddDecorItems()
        {
            Console.WriteLine("enter a decorative item");
            string item = Console.ReadLine();
            Console.WriteLine("enter the price of decorative item");
            string price = Console.ReadLine();
            SqlConnection sq = new SqlConnection(dataConstr);
            SqlCommand cmd = new SqlCommand("insert into dcoritems values('" + item + "','" + price + "')", sq);
            sq.Open();
            int res = cmd.ExecuteNonQuery();
            sq.Close();
            if (res > 0)
            {
                Console.WriteLine("Food added successfully");
            }
        }
        public void AddNecessaryItems()
        {
            Console.WriteLine("Enter necessory item to be added");
            string item = Console.ReadLine();
            Console.WriteLine("Enter the price for the food");
            string price = Console.ReadLine();
            SqlConnection sq = new SqlConnection(dataConstr);
            SqlCommand cmd = new SqlCommand("insert into necessoryitems values('" + item + "','" + price + "')", sq);
            sq.Open();
            int res = cmd.ExecuteNonQuery();
            sq.Close();
            if (res > 0)
            {
                Console.WriteLine("Essential items are added successfully");
            }
        }

        public void ShowAllItmes()
        {
            DataTable dtfood = new DataTable();
            DataTable dtneccitems = new DataTable();
            DataTable dtdecor = new DataTable();
            SqlConnection sq = new SqlConnection(dataConstr);
            SqlCommand cmdf = new SqlCommand("select * from fooditems", sq);
            SqlCommand cmdd = new SqlCommand("select * from dcoritems", sq);
            SqlCommand cmdn = new SqlCommand("select * from necessoryitems", sq);
            sq.Open();
            SqlDataReader drf = cmdf.ExecuteReader();
            dtfood.Load(drf);
            SqlDataReader drn = cmdn.ExecuteReader();
            dtneccitems.Load(drn);
            SqlDataReader drd = cmdd.ExecuteReader();
            dtdecor.Load(drd);
            sq.Close();
            Console.Write("These are the food items along with prices\n");
            Console.WriteLine("no\t\tevent\t\tprice");

            for (int i = 0; i < dtfood.Rows.Count; i++)
            {

                for (int j = 0; j < dtfood.Columns.Count; j++)
                {

                    Console.Write(dtfood.Rows[i][j] + "\t\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("\n These are the decorative items along with prices \n");
            Console.WriteLine("no\t\tevent\t\tprice");


            for (int i = 0; i < dtdecor.Rows.Count; i++)
            {

                for (int j = 0; j < dtdecor.Columns.Count; j++)
                {

                    Console.Write(dtdecor.Rows[i][j] + "\t\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("\nThese are the necessory items along with prices\n");
            Console.WriteLine("no\t\tevent\t\tprice");

            for (int i = 0; i < dtneccitems.Rows.Count; i++)
            {

                for (int j = 0; j < dtneccitems.Columns.Count; j++)
                {

                    Console.Write(dtneccitems.Rows[i][j] + "\t\t");
                }
                Console.WriteLine();
            }

        }

        public void ShowEvents()
        {
            DataTable dt = new DataTable();
            SqlConnection sq = new SqlConnection(dataConstr);
            SqlCommand cmd = new SqlCommand("select * from eventtable", sq);
            sq.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            sq.Close();
            Console.WriteLine("these are the events\n");
            Console.WriteLine("no\t\tevent\t\tprice");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {

                    Console.Write(dt.Rows[i][j] + "\t\t");
                }
                Console.WriteLine();
            }
        }

        public void ViewAndGrantPermission()
        {

        }
    }
}