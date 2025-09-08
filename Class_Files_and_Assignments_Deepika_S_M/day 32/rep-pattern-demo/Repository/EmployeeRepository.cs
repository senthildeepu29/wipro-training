using Microsoft.EntityFrameworkCore;
using rep_pattern_demo.Data;
using rep_pattern_demo.Models;

namespace RepositoryWithMVC.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(int studentId)
        {
            return _context.Employees.Find(studentId);
        }
        public int AddEmployee(Employee employeeEntity)
        {
            int result = -1;

            if (employeeEntity != null)
            {
                _context.Employees.Add(employeeEntity);
                _context.SaveChanges();
                result = employeeEntity.EmployeeId; // Assuming EmployeeId is auto-generated
            }
            return result;
        }
        public int UpdateEmployee(Employee employeeEntity)
        {
            int result = -1;

            if (employeeEntity != null)
            {
                _context.Entry(employeeEntity).State = EntityState.Modified;
                _context.SaveChanges();
                result = employeeEntity.EmployeeId;
            }

            return result;
        }
        public void DeleteEmployee(int employeeId)
        {
            var employee = _context.Employees.Find(employeeId);

            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }


        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}


        