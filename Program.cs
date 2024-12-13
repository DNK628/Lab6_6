using System;
using System.Collections;
using System.Collections.Generic;


public class Employee : IComparable<Employee>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Experience { get; set; }

    
    public Employee(string name, int age, int experience)
    {
        Name = name;
        Age = age;
        Experience = experience;
    }

    public int CompareTo(Employee other)
    {
        if (other == null) return 1;
        return Age.CompareTo(other.Age);
    }

    
    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Experience: {Experience} years";
    }
}

public class EmployeeExperienceComparer : IComparer<Employee>
{
    public int Compare(Employee x, Employee y)
    {
        if (x == null || y == null) throw new ArgumentException("One or both objects are null");
        return x.Experience.CompareTo(y.Experience);
    }
}

public class EmployeeCollection : IEnumerable<Employee>
{
    private List<Employee> employees = new List<Employee>();

    public void Add(Employee employee)
    {
        employees.Add(employee);
    }

    public IEnumerator<Employee> GetEnumerator()
    {
        return employees.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main(string[] args)
    {
      
        var employees = new EmployeeCollection
        {
            new Employee("Олексій", 30, 5),
            new Employee("Андрій", 45, 10),
            new Employee("Марина", 25, 2),
            new Employee("Діана", 40, 8)
        };

        Console.WriteLine("Employees:");
        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }

        var employeeList = new List<Employee>(employees);
        employeeList.Sort();
        Console.WriteLine("\nEmployees sorted by Age:");
        foreach (var employee in employeeList)
        {
            Console.WriteLine(employee);
        }

        employeeList.Sort(new EmployeeExperienceComparer());
        Console.WriteLine("\nEmployees sorted by Experience:");
        foreach (var employee in employeeList)
        {
            Console.WriteLine(employee);
        }
    }
}

