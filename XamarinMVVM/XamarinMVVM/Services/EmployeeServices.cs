using System.Collections.Generic;
using XamarinMVVM.Models;

namespace XamarinMVVM.Services
{
    public class EmployeeServices
    {
        public List<Employeee> GetEmployeees()
        {
            var list = new List<Employeee>()
            {
                new Employeee()
                {
                    Name = "Abebe",
                    Department = "Marketing",
                },
                new Employeee()
                {
                    Name = "Kebede",
                    Department = "Sales"
                },
                new Employeee()
                {
                    Name = "Dellia",
                    Department = "HR"
                },
                new Employeee()
                {
                    Name = "Fedu",
                    Department = "Sales"
                },
                new Employeee()
                {
                    Name = "Sara",
                    Department = "Marketing"
                },
                new Employeee()
                {
                    Name = "Houssen",
                    Department = "IT"
                },
                new Employeee()
                {
                    Name = "Zebene",
                    Department = "Sales"
                },
                new Employeee()
                {
                    Name = "Deribba",
                    Department = "IT"
                },
                new Employeee()
                {
                    Name = "Chaltu",
                    Department = "Marketing"
                }

            };

            return list;
        }
    }
}
