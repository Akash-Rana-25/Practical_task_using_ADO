using ConsoleTables;
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

        public void Add()
        {
         

            using (SqlConnection connection = new SqlConnection(ConString))
            {
                //string sqlText = @"INSERT INTO Employee VALUES (@FirstName,@MiddleName,@LastName,@EmpCode,@gender,@DOB,@salary,@JoiningDate,@ResignDate);";
                //SqlCommand cmd = new SqlCommand(sqlText, connection);

                //cmd.Parameters.AddWithValue("@FirstName", FirstName);
                //cmd.Parameters.AddWithValue("@MiddleName", MiddleName);
                //cmd.Parameters.AddWithValue("@LastName", LastName);
                //cmd.Parameters.AddWithValue("@EmpCode", EmpCode);
                //cmd.Parameters.AddWithValue("@gender", gender);
                //cmd.Parameters.AddWithValue("@DOB", DOB);
                //cmd.Parameters.AddWithValue("@salary", salary);
                //cmd.Parameters.AddWithValue("@JoiningDate", JoiningDate);
                //cmd.Parameters.AddWithValue("@ResignDate", ResignDate);






                SqlCommand cmd = new SqlCommand("INSERT INTO Employee VALUES ('Akash','Ishwarbhai','Rana',2512,1,'1999/12/25',54166,'2023/01/02','2023/05/16');", connection);

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
        public void Update(int Id) {

            using (SqlConnection connection = new SqlConnection(ConString))
            {



                SqlCommand cmd = new SqlCommand("Update Employee set FirstName='karan',MiddleName ='S',LastName ='Raj',EmpCode=1007,gender=1,salary=202020,JoiningDate='2022-01-07',ResignDate='2024-2-2' Where Employee_PK=@Id;", connection);
                cmd.Parameters.AddWithValue("@Id", Id);


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
