namespace test01
{
    public class Employee
    {
        public string Name { get; set; }
        public int EmployeeCount { get; set; }
        public Employee(string name, int employeeCount)
        {
            Name = name;
            EmployeeCount = employeeCount;
        }
    }
}