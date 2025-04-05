using EmployeeAPI;

namespace SampleRestfulAPI
{
    public class EmployeeDB
    {
        public EmployeeDBContext _context;

        public EmployeeDBContext context { get; set; }

        public EmployeeDB()
        {
            _context = new EmployeeDBContext();
        }
        public bool AddEmployee(Employee employees)
        {
            try
            {
                _context.Employee.Add(employees);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public void DeleteEmployee(int employeeId)
        {
            // Find the employee by ID
            var employee = _context.Employee.Find(employeeId);
            if (employee != null)
            {
                _context.Employee.Remove(employee);
                _context.SaveChanges();
            }
            else
            {
                // Handle the case where the employee was not found
                throw new Exception("Employee not found");
            }
        }

        public List<Employee> GetEmployeesList()
        {
            return _context.Employee.ToList();
        }
        public Employee GetEmployee(int employeeId)
        {
            var employee = _context.Employee.Find(employeeId);
            if (employee == null)
            {
                throw new Exception("Employee not found");
            }
            return employee;
        }
    }
}