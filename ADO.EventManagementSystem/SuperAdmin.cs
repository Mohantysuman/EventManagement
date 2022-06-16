using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Ado.EventManagement
{
    internal class SuperAdmin
    {
        string currentsa;
        public static string dataConstr = @"Data Source=LAPTOP-MIL5M1L9;Initial Catalog=SuperAdmin;Integrated Security=True";
        public void Handle()
        {

        }
        public void Login()
        {
            DataTable dt = new DataTable();
            Console.WriteLine("enter your name");
            string name = Console.ReadLine();
            Console.WriteLine("enter password");
            string pass = Console.ReadLine();
            SqlConnection sq = new SqlConnection(dataConstr);
            SqlCommand cmd = new SqlCommand("select * from superadmins where sname='" + name + "' and spassword='" + pass + "'", sq);
            sq.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            sq.Close();

            if (dt.Rows.Count > 0)
            {
                Console.WriteLine("Welcome  " + dt.Rows[0][1]);
                currentsa = (string)dt.Rows[0][1];
            }
            else
            {
                Console.WriteLine("Either Username or Password is Wrong");
            }


        }
        public void AddAdmin()
        {
            Console.WriteLine("enter name");
            string name = Console.ReadLine();
            Console.WriteLine("enter mobile");
            string password = Console.ReadLine();
            Console.WriteLine("enter residence");
            string role = Console.ReadLine();
            SqlConnection sq = new SqlConnection(dataConstr);
            SqlCommand cmd = new SqlCommand("insert into admins values('" + name + "','" + password + "','" + role + "')", sq);
            sq.Open();
            int res = cmd.ExecuteNonQuery();
            sq.Close();
            if (res > 0)
            {
                Console.WriteLine("successfully registered");
            }


        }
        public void removeAdmin()
        {

        }
        public void ViewAndGrantPermission()
        {

        }
    }
}