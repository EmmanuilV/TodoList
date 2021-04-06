using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace EmployeeBirthdays
{
    class BirthdayPlaner
    {
        Dictionary<int, List<Employee>> employeeBirthMonth = new Dictionary<int, List<Employee>>();

        public void AddToList(Employee employee)
        {
            employeeBirthMonth[employee.Birthday.Month].Add(employee);
        }
        public void EmployesBirthdayDict()
        {
            for (int i = 1; i <= 12; i++)
            {
                employeeBirthMonth.Add(i, new List<Employee>());
            }
        }

        public string ChooseNumMonth(int inputNumber)
        {
            string resultAllInfo = "";
            for (int i = 0; i <= inputNumber; i++)
            {
                resultAllInfo += $"{PrintMonthYear(i)}{PrintInfo(i)}";
            }
            return resultAllInfo;
        }

        private int GetMonth(int inputNumber)
        {
            return DateTime.Today.Month + inputNumber;
        }
        private string PrintMonthYear(int inputNumber)
        {
            string thisYear = DateTime.Today.ToString("yyyy");
            return $"{CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat.GetMonthName(GetMonth(inputNumber))} {thisYear}\n";
        }

        private string PrintInfo(int inputNumber)
        {
            List<Employee> value;
            string resultInfo = "";
            for(int i = 0; i < employeeBirthMonth[GetMonth(inputNumber)].Count; i++)
            {
                if (employeeBirthMonth.TryGetValue(GetMonth(inputNumber), out value))
                {
                    resultInfo += $"({value.ElementAt(i).Birthday.Day}) - {value.ElementAt(i).Name} ({GetAge(value.ElementAt(i))})\n" ;
                }
                else
                {
                    resultInfo = "Employee is not found!";
                }
            }
            return resultInfo;
        }

        private string MakePluarization(int age)
        {
            string stringAge = "";
            if(age >= 11 && age <= 19 || age % 10 == 0 || age % 10 >= 5 && age % 10 <= 9)
            {
                stringAge += "лет"; 
            }
            else
            {
                stringAge += "года";
            }
            return stringAge;
        }
        private string GetAge(Employee employee)
        {
            int result = int.Parse(DateTime.Today.ToString("yyyy")) - int.Parse(employee.Birthday.ToString("yyyy"));//int.Parse(DateTime.Today.ToString("yyyy")) - 

            return $"{result} {MakePluarization(result)}"; 
        }
    }
}
