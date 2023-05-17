using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace testDB_using_ado
{
    internal class Program
    {
        public enum crud
        {
            Getall=0,
            insert =1,
            update =2,
            delete =3,
            GetByID=4
        }
        public enum Gender
        {
            other = 0,
            male = 1,
            female = 2
        }
        static void Main(string[] args)
        {
            string status;

            do
            {
                Console.WriteLine($"\n Enter Your Choice:");
                Console.WriteLine($"0 - Get ALL");
                Console.WriteLine($"1 - Insert");
                Console.WriteLine($"2 - Update");
                Console.WriteLine($"3 - Delete");
                Console.WriteLine($"4 - Get BY ID \n");



                string choice = Console.ReadLine();
                int intChoice = Convert.ToInt32(choice);
                crud userSelected = (crud)intChoice;

                switch (userSelected)
                {
                    case crud.insert:


                        // Method IF Want Insert Data With User Input
                        //InsertDataUserIP();


                        var newEmployee = new Employee()
                        {
                            FirstName = "Pranaya",
                            MiddleName = "J",
                            LastName = "Rout",
                            EmpCode = 12,
                            Gender = 1,
                            DOB = DateTime.Now,
                            salary = 54166,
                            JoiningDate = DateTime.Now,
                            ResignDate = DateTime.Now,

                        };
                        CrudOpration insert = new CrudOpration();
                        insert.Add(newEmployee);
                        break;

                    case crud.update:
                        Console.WriteLine("Enter Id: ");
                        int UpdateId;

                        if (int.TryParse(Console.ReadLine(), out UpdateId))
                        {
                            CrudOpration update = new CrudOpration();
                            update.Update(UpdateId);
                        }
                        else
                        {
                            Console.WriteLine("Pelese Provide Valid Input");

                        }
                        break;

                    case crud.delete:
                        Console.WriteLine("Enter Id: ");
                        int Id;
                        if (int.TryParse(Console.ReadLine(), out Id))
                        {
                            CrudOpration remove = new CrudOpration();
                            remove.Delete(Id);
                        }
                        else
                        {
                            Console.WriteLine("Pelese Provide Valid Input");

                        }

                        break;

                    case crud.Getall:
                        CrudOpration read = new CrudOpration();
                        read.Read();

                        break;



                    case crud.GetByID:
                        Console.WriteLine("Enter Id : ");
                        int readId;
                        if (int.TryParse(Console.ReadLine(), out readId))
                        {
                            CrudOpration readByID = new CrudOpration();
                            readByID.Read(readId);
                        }
                        else
                        {
                            Console.WriteLine("Pelese Provide Valid Input");

                        }

                        break;

                    default:
                        Console.WriteLine("Pelese Provide Valid Input");
                        break;
                }

                Console.ReadLine();
                Console.Write("Do you want to continue(y/n):");
                status = Console.ReadLine();
            }
            while (status == "y" || status == "Y");



            Console.ReadKey();
        }

        //private static void InsertDataUserIP()
        //{
        //      Console.WriteLine("Enter First Name: ");
        //                string FirstName = Console.ReadLine().ToString();

        //                Console.WriteLine("Enter Middle Name: ");
        //                string MiddleName = Console.ReadLine().ToString();

        //                Console.WriteLine("Enter Last Name: ");
        //                string LastName = Console.ReadLine().ToString();

        //                Console.WriteLine("Enter Employee Code: ");
        //                int temp, EmpCode = 0;

        //                if (int.TryParse(Console.ReadLine(), out temp))
        //                {
        //                    EmpCode = temp;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Pelese Provide Valid Input");

        //                }

        //                Console.WriteLine("Enter Employee Gender: ");
        //                Gender gender;
        //                if (Enum.TryParse(Console.ReadLine(), true, out gender) && Enum.IsDefined(typeof(Gender), gender))
        //                {
        //                    Console.WriteLine("You entered: " + gender);
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Invalid input! Please enter a valid gender.");
        //                }


        //                Console.WriteLine("Enter Employee DOB (Format YYYY-MM-DD): ");
        //                DateTime DOB = Convert.ToDateTime(Console.ReadLine());

        //                Console.WriteLine("Enter Employee Salary: ");
        //                int tempSalary, salary = 0;

        //                if (int.TryParse(Console.ReadLine(), out tempSalary))
        //                {
        //                    salary = tempSalary;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Pelese Provide Valid Input");

        //                }

        //                Console.WriteLine("Enter Employee Joining Date (Format YYYY-MM-DD): ");
        //                DateTime JoiningDate = Convert.ToDateTime(Console.ReadLine());


        //                Console.WriteLine("Enter Employee Resign Date (If Any) (Format YYYY-MM-DD): ");
        //                DateTime ResignDate = Convert.ToDateTime(Console.ReadLine());

        //                CrudOpration insert = new CrudOpration();
        //                insert.Add(FirstName, MiddleName, LastName, EmpCode, gender, DOB, salary, JoiningDate, ResignDate);
        //}
    }
}
