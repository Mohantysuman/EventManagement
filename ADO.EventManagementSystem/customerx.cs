using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Ado.EventManagement
{
    internal class Customerx
    {
        public static string dataConstr = @"Data Source=LAPTOP-MIL5M1L9;Initial Catalog=CustomersRecord;Integrated Security=True";
        int cusid;
        private string eAdd;

        public Customerx(int cusid, string eAdd, IEnumerable<int> amounts)
        {
            this.cusid = cusid;
            this.eAdd = eAdd;
            Amounts = amounts;
        }

        public IEnumerable<int> Amounts { get; private set; }

        public void Handle()
        {
            Console.WriteLine("enter 1 for login");
            Console.WriteLine("enter 2 for registration");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Login();
            }
            else if (choice == 2)
            {
                Register();
            }
            else
            {
                Console.WriteLine("enter a valid input");
            }


        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\nEnter 1 to see our Events");
                Console.WriteLine("Enter 2 to see our packages");
                Console.WriteLine("Enter 3 to choose event");
                Console.WriteLine("Enter 4 to choose food options");
                Console.WriteLine("Enter 5 to choose decor packages");
                Console.WriteLine("Enter 6 to choose essential items");
                Console.WriteLine("Enter 7 to find your total billing amount");
                Console.WriteLine("Etner 8 Logout");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1: ShowEvents(); break;
                    case 2: ShowAllItmes(); break;
                    case 3: ChooseEvent(); break;
                    case 4: ChooseFoodItems(); break;
                    case 5: ChooseDecorItems(); break;
                    case 6: ChooseNecessaryItems(); break;
                    case 7: ShowTotalCost(); break;
                    case 8: return;
                    default: Console.WriteLine("enter a Valid Input"); break;

                }
            }


        }
        public void Register()
        {
            Console.WriteLine("enter name");
            string name = Console.ReadLine();
            Console.WriteLine("enter mobile");
            string mobile = Console.ReadLine();
            Console.WriteLine("enter residence");
            string residence = Console.ReadLine();
            Console.WriteLine("enter email");
            string email = Console.ReadLine();
            Console.WriteLine("set a  password");
            string password = Console.ReadLine();
            SqlConnection sq = new SqlConnection(dataConstr);
            SqlCommand cmd = new SqlCommand("insert into customers values('" + name + "','" + mobile + "','" + residence + "','" + email + "','" + password + "')", sq);
            sq.Open();
            int res = cmd.ExecuteNonQuery();
            sq.Close();
            if (res > 0)
            {
                Console.WriteLine("SUCCESSFULLY REGISTERED");
            }
        }
        public void Login()
        {
            DataTable dt = new DataTable();
            Console.WriteLine("enter your email");
            string eaddress = Console.ReadLine();
            Console.WriteLine("enter password");
            string pass = Console.ReadLine();
            SqlConnection sq = new SqlConnection(dataConstr);
            SqlCommand cmd = new SqlCommand("select * from customers where email='" + eAdd + "' and bpassword='" + pass + "'", sq);
            sq.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            sq.Close();

            if (dt.Rows.Count > 0)
            {
                Console.WriteLine("Welcome  " + dt.Rows[0][1]);
                cusid = (int)dt.Rows[0][0];
                Menu();

            }
            else
            {
                Console.WriteLine("Either Username or Password is Wrong");
                return;
            }


        }
        public void ShowEvents()
        {
            DataTable dt = new DataTable();
            SqlConnection sq = new SqlConnection(dataConstr);
            SqlCommand cmd = new SqlCommand("select * from EventManagementTable", sq);
            sq.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            sq.Close();
            Console.WriteLine("these are the events \n");
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

                    Console.Write(dtneccitems.Rows[i][j] + "\t");
                }
                Console.WriteLine();
            }

        }

        public void ChooseEvent()
        {
            int cid = cusid;
            ShowEvents();

            try
            {
                Console.WriteLine("enter event number");
                int eventid = Convert.ToInt32(Console.ReadLine());
                SqlConnection sq = new SqlConnection(dataConstr);
                SqlCommand cmd = new SqlCommand("insert into cEventchose values(" + cid + ",'" + eventid + "')", sq);
                sq.Open();
                int res = cmd.ExecuteNonQuery();
                sq.Close();
                if (res > 0)
                {
                    Console.WriteLine("successfully chosen the event");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("enter a valid event number");
            }

        }
        public void ChooseFoodItems()
        {
            int cid = cusid;
            ShowAllItmes();


            try
            {
                Console.WriteLine("\nenter food item number");
                int dishid = Convert.ToInt32(Console.ReadLine());
                SqlConnection sq = new SqlConnection(dataConstr);
                SqlCommand cmd = new SqlCommand("insert into cfoodchoice values('" + cid + "','" + dishid + "')", sq);
                sq.Open();
                int res = cmd.ExecuteNonQuery();
                sq.Close();
                if (res > 0)
                {
                    Console.WriteLine("successfully chosen the event");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("enter a valid event number");
            }



        }
        public void ChooseDecorItems()
        {
            int cid = cusid;
            ShowAllItmes();

            try
            {
                Console.WriteLine("\nenter decor item number");
                int decorid = Convert.ToInt32(Console.ReadLine());
                SqlConnection sq = new SqlConnection(dataConstr);
                SqlCommand cmd = new SqlCommand("insert into cdecorchoice values('" + cid + "','" + decorid + "')", sq);
                sq.Open();
                int res = cmd.ExecuteNonQuery();
                sq.Close();
                if (res > 0)
                {
                    Console.WriteLine("successfully chosen the event");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Enter a Valid event Number");
            }
        }
        public void ChooseNecessaryItems()
        {
            int cid = cusid;
            ShowAllItmes();

            try
            {
                Console.WriteLine("\nenter necessary item number");
                int necesid = Convert.ToInt32(Console.ReadLine());
                SqlConnection sq = new SqlConnection(dataConstr);
                SqlCommand cmd = new SqlCommand("insert into cnecesschoice values('" + cid + "','" + necesid + "')", sq);
                sq.Open();
                int res = cmd.ExecuteNonQuery();
                sq.Close();
                if (res > 0)
                {
                    Console.WriteLine("Event choosen successfuly");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Enter a Valid Event Number");
            }
        }
        private void ShowTotalCost()
        {
            Console.WriteLine("food cost= " + Foodcost());
            Console.WriteLine("decor cost= " + decorcost());
            Console.WriteLine("other cost= " + necesscost());

            int totalcost = decorcost() + Foodcost() + necesscost();
            Console.WriteLine("the total cost " + totalcost);


        }
        public int decorcost()
        {
            int dcost = 0;
            List<int> amounts = new List<int>();
            int cid = cusid;
            DataTable dt = new DataTable();
            SqlConnection sq = new SqlConnection(dataConstr);
            String query = "select price from customers,dcoritems,cdecorchoice where cid=customer and decoritem=did and cid=" + cid + "";
            SqlDataAdapter adap = new SqlDataAdapter(query, sq);
            adap.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {

                    amounts.Add(Convert.ToInt32(dt.Rows[i][j]));
                }
            }

            foreach (int am in amounts)
            {
                dcost += Convert.ToInt32(am);
            }

            return dcost;
        }

        public int Foodcost()
        {
            int foodcost = 0;
            List<int> amounts = new List<int>();
            int cid = cusid;
            DataTable dt = new DataTable();
            SqlConnection sq = new SqlConnection(dataConstr);
            String query = "select price from customers,fooditems,cfoodchoice where cid=customer and fooditem=fid and cid=" + cid + ";";
            SqlDataAdapter adap = new SqlDataAdapter(query, sq);
            adap.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {

                    amounts.Add(Convert.ToInt32(dt.Rows[i][j]));
                }
            }

            foreach (int am in amounts)
            {
                foodcost += Convert.ToInt32(am);
            }


            return foodcost;
        }

        public int necesscost()
        {
            int ncost = 0;
            List<int> amounts = new List<int>();
            int cid = cusid;
            DataTable dt = new DataTable();
            SqlConnection sq = new SqlConnection(dataConstr);
            String query = "select price from customers,necessoryitems,cnecesschoice where cid=customer and necessitem=nid and cid=" + cid + ";";
            SqlDataAdapter adap = new SqlDataAdapter(query, sq);
            adap.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {

                    amounts.Add(Convert.ToInt32(dt.Rows[i][j]));
                }
            }

            foreach (int am in Amounts)
            {
                ncost += Convert.ToInt32(am);
            }


            return ncost;
        }


    }
}