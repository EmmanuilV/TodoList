using System;
using System.Collections.Generic;
using Npgsql;

namespace EmployeeBirthdays
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            ReadTasks(employees);

            BirthdayPlaner birthdayPlaner = new BirthdayPlaner();

            birthdayPlaner.EmployesBirthdayDict();
            foreach (var employee in employees)
            {
                birthdayPlaner.AddToList(employee);

            }
            
            Console.WriteLine(birthdayPlaner.ChooseNumMonth(2));
        }
        static void ReadTasks(List<Employee> employees)//System.Threading.Tasks.Task ReadTasks()
        {

            var connString = "Host=127.0.0.1;Username=todolist;Password='qwerty';Database=birthday_employees";

            using var conn = new NpgsqlConnection(connString);
            conn.Open();

            using (var cmd = new NpgsqlCommand("SELECT name, birthday FROM employees_bd", conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //string name = 
                        //DateTime birthday 

                        Employee employee = new Employee();
                        employee.Name = reader.GetString(0);
                        employee.Birthday = reader.GetDateTime(1);

                        employees.Add(employee);
                    }
                }
            }
        }
    }
}
/* birth.AddEmployee("Ваня Иванов", new DateTime(1987,03,27));
 birth.AddEmployee("Петя Петров", new DateTime(1978, 05, 3));
 birth.AddEmployee("Коля Новогодний", new DateTime(1991, 04, 13));
 birth.AddEmployee("Стас Рождественский", new DateTime(1981, 04, 17));
 birth.AddEmployee("Саша Пономарев", new DateTime(1973, 05, 19));
 birth.AddEmployee("Олег Винник", new DateTime(1973, 03, 19));
*/