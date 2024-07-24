﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ADO_Assesment
{
    class Program
    {
        public static SqlConnection con = null;
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        static void Main(string[] args)
        {
            InsertData();
            SelectData();
            Console.Read();
        }
        public static SqlConnection GetConnection()
        {
            con = new SqlConnection("data source = ICS-LT-47758G3;initial catalog = Employeemanagement;" +
                "integrated security = true");
            con.Open();
            return con;

        }

        public static void SelectData()
        {
            con = GetConnection();
            cmd = new SqlCommand("select * from Employee_Details");
            cmd.Connection = con;

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine("Empno : " + dr[0]);
                Console.WriteLine("EmpName : " + dr[1]);
                Console.WriteLine("Emp_sal : " + dr[2]);
                Console.WriteLine("Emptype : " + dr[3]);
            }
        }

        public static void InsertData()
        {
            con = GetConnection();
            int Empno;
            string EmpName;
            int Emp_sal;
            char Emptype;

            try
            {
                Console.Write("Enter employee Name: ");
                EmpName = Console.ReadLine();

                Console.Write("Enter employee salary: ");
                Emp_sal = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter employee type ('F' for Fulltime, 'P' for Parttime): ");
                Emptype = char.ToUpper(Console.ReadKey().KeyChar);

                cmd = new SqlCommand("AddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;



                cmd.Parameters.AddWithValue("@EmpName", EmpName);
                cmd.Parameters.AddWithValue("@Emp_sal", Emp_sal);
                cmd.Parameters.AddWithValue("@Emptype", Emptype);

                con.Open();
                cmd.ExecuteNonQuery();

                Console.WriteLine("\nEmployee added successfully!");
            }
            catch
            {
                //Console.WriteLine();
            }
        }
    }
}