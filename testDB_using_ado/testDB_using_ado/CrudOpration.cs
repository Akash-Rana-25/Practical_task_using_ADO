﻿using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static testDB_using_ado.Program;

namespace testDB_using_ado
{
    internal class CrudOpration :  ICrudOpration
    {
        string ConString;

        public CrudOpration()
        {
             ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        }

        //public void Add(string FirstName, string MiddleName, string LastName, int EmpCode, ender gender, DateTime DOB, int salary, DateTime JoiningDate, DateTime ResignDate)

        public void Add(Employee employee)
        {
         

            using (SqlConnection connection = new SqlConnection(ConString))
            {
                string sqlText = @"INSERT INTO Employee VALUES (@FirstName,@MiddleName,@LastName,@EmpCode,@gender,@DOB,@salary,@JoiningDate,@ResignDate);";
                SqlCommand cmd = new SqlCommand(sqlText, connection);

                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", employee.MiddleName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@EmpCode", employee.EmpCode);
                cmd.Parameters.AddWithValue("@gender", employee.Gender);
                cmd.Parameters.AddWithValue("@DOB", employee.DOB);
                cmd.Parameters.AddWithValue("@salary", employee.salary);
                cmd.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate);
                cmd.Parameters.AddWithValue("@ResignDate", employee.ResignDate);






                //SqlCommand cmd = new SqlCommand("INSERT INTO Employee VALUES ('Akash','Ishwarbhai','Rana',2512,1,'1999/12/25',54166,'2023/01/02','2023/05/16');", connection);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("\n Records Inserted Successfully");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }
                finally
                {
                    connection.Close();
                    Console.ReadKey();
                }


            }
        }

       public void Delete(int Id) {

            using (SqlConnection connection = new SqlConnection(ConString))
            {



                SqlCommand cmd = new SqlCommand("Delete from Employee where Employee_PK= @Id", connection);
                cmd.Parameters.AddWithValue("@Id", Id);



                try
                {
                    connection.Open();
                    
                    if (cmd.ExecuteNonQuery()==0)
                    {
                        Console.WriteLine("\n Employee Does Not Exist");

                    }
                    else
                    {
                        Console.WriteLine("\n Records Deleted Successfully");
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }
                finally
                {
                    connection.Close();
                    Console.ReadKey();
                }
            }
        }
        public void Update(int Id,Employee employee) {

            using (SqlConnection connection = new SqlConnection(ConString))
            {



                SqlCommand cmd = new SqlCommand("Update Employee set FirstName=@FirstName,MiddleName =@MiddleName,LastName =@LastName,EmpCode=@EmpCode,Gender=@gender,salary=@salary,JoiningDate=@JoiningDate,ResignDate=@ResignDate Where Employee_PK=@Id;", connection);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", employee.MiddleName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@EmpCode", employee.EmpCode);
                cmd.Parameters.AddWithValue("@gender", employee.Gender);
                cmd.Parameters.AddWithValue("@DOB", employee.DOB);
                cmd.Parameters.AddWithValue("@salary", employee.salary);
                cmd.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate);
                cmd.Parameters.AddWithValue("@ResignDate", employee.ResignDate);


                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        Console.WriteLine("\n Employee Does Not Exist");

                    }
                    else
                    {
                        Console.WriteLine("\n Records Updated Successfully");
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }
                finally
                {
                    connection.Close();
                    Console.ReadKey();
                }
            }
        }

        public void Read()
        {

            using (SqlConnection connection = new SqlConnection(ConString))
            {
              
                SqlCommand cm = new SqlCommand("select * from Employee", connection);

                try
                {
                    connection.Open();
                    SqlDataReader sdr = cm.ExecuteReader();
                    var table = new ConsoleTable("Id", "First Name", "Middle Name", "Last Name", "Employee Code", "DOB", "Salary", "Joining Date", "Resign Date");

                    while (sdr.Read())
                    {
                        table.AddRow(sdr["Employee_PK"],sdr["FirstName"],sdr["MiddleName"], sdr["LastName"], sdr["EmpCode"], sdr["DOB"], sdr["Salary"], sdr["JoiningDate"], sdr["ResignDate"]);

                    }
                    table.Options.EnableCount = false;
                    table.Write();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }
                finally
                {
                    connection.Close();
                    Console.ReadKey();
                }


            }
        }
        public void Read(int Id)
        {

            using (SqlConnection connection = new SqlConnection(ConString))
            {

                SqlCommand cm = new SqlCommand("select * from Employee where Employee_PK= @Id", connection);
                cm.Parameters.AddWithValue("@Id", Id);


                try
                {
                    connection.Open();
                    SqlDataReader sdr = cm.ExecuteReader();
                        var table = new ConsoleTable("Id", "First Name", "Middle Name" ,"Last Name","Employee Code","DOB","Salary","Joining Date","Resign Date");

                    while (sdr.Read())

                    { 

                        table.AddRow(sdr["Employee_PK"],sdr["FirstName"],sdr["MiddleName"], sdr["LastName"], sdr["EmpCode"], sdr["DOB"], sdr["Salary"], sdr["JoiningDate"], sdr["ResignDate"]);


                    }
                    table.Options.EnableCount = false;
                    table.Write();

                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }
                finally
                {
                    connection.Close();
                    Console.ReadKey();
                }


            }
        }



    }
}
