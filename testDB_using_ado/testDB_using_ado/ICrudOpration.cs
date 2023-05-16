using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static testDB_using_ado.Program;

namespace testDB_using_ado
{
    internal interface ICrudOpration
    {
        void Add();

       // void Add(string FirstName, string MiddleName, string LastName, int EmpCode, Gender gender, DateTime DOB, int salary, DateTime JoiningDate, DateTime ResignDate);

        void Update(int Id);
        void Delete(int Id);
        void Read();

    }
}
