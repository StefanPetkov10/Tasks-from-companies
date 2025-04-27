namespace test01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("John", 3));
            employees.Add(new Employee("Peter", 2));
            employees.Add(new Employee("Mark", 0));
            employees.Add(new Employee("Elain", 0));
            employees.Add(new Employee("Maria", 1));
            employees.Add(new Employee("Larra", 1));
            employees.Add(new Employee("Ana", 0));
            employees.Add(new Employee("George", 0));

            /* 
             John
               Peter
                 Mark
                 Elain
               Maria
                 Larra
                   Ana
               George
             */
            Console.WriteLine(employees[0].Name);
            int indent = 1;
            int count = 0;

            for (int i = 1; i < employees.Count; i++)
            {
                if (employees[i].EmployeeCount > 0)
                {
                    Console.WriteLine(new string(' ', indent * 2) + employees[i].Name);
                    indent++;
                    count += employees[i].EmployeeCount;
                }

                else if (employees[i].EmployeeCount == 0)
                {
                    Console.WriteLine(new string(' ', indent * 2) + employees[i].Name);
                    count--;
                }

                if (count == 0)
                {
                    indent--;
                }

            }
        }
    }
}
