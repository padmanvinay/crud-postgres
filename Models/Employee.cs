using System;
namespace EmployeeAPI.Models
{
    public class Employee
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }

    }
}