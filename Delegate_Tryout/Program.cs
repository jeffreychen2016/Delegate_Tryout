using System;
using System.Collections.Generic;

namespace Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            var Employees = new List<Employee>();
            Employees.Add(new Employee { FirstName = "Jeffrey", LastName = "Chen", Experience = 5 });
            Employees.Add(new Employee { FirstName = "Kevin", LastName = "Chen", Experience = 1 });
            Employees.Add(new Employee { FirstName = "John", LastName = "Chen", Experience = 2 });
            Employees.Add(new Employee { FirstName = "Terry", LastName = "Chen", Experience = 5 });
            Employees.Add(new Employee { FirstName = "Test", LastName = "Chen", Experience = 5 });

            //end user side
            //s1: create an instance of delegate, and pass the method that the delegate points to
            // not required if using lambda exprecess
            //IsPromotable isPromotable = new IsPromotable(Promote);

            //s3: pass in the delegate
            // not required if using lambda exprecess
            //Employee.PromoteEmployee(Employees, isPromotable);
            Employee.PromoteEmployee(Employees, emp => emp.Experience > 2);

            // Nathan's method
            // Employee.PromoteEmployee(Employees, EvaluateEmployee);

        }

        //s2: create the actual method
        // not required if using lambda exprecess
        //public static bool Promote(Employee emp)
        //{
        //    if (emp.Experience > 2)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        // Nathan's method
        // static bool EvaluateEmployee(Employee emp) => emp.Experience > 2;
    }



    // the purpose of this delegate is to remove the hardcore logic in the PromoteEmployee method
    // emp.Experience > 2 returns bool, so the return type of the delegate should also be bool
    delegate bool IsPromotable(Employee emp);

    class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Experience { get; set; }

        // use static here because there is no point to instantiate the employee obejct that takes in list of employee as parameter
        // everytime when you need to pass in a function, think of delegate
        public static void PromoteEmployee(List<Employee> emloyees, IsPromotable IsEligibleToPromote)
        {
            foreach (Employee emp in emloyees)
            {
                if (IsEligibleToPromote(emp))
                {
                    Console.WriteLine(emp.FirstName + ' ' + emp.LastName + " got promoted!");
                }
            }
        }

    }

}

