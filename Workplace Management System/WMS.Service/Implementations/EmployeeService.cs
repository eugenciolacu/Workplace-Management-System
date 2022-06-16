using WMS.Data.Entities.Core;
using WMS.Repository.Repositories.Interfaces;
using WMS.Service.Interfaces;

namespace WMS.Service.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeRepository.GetAll();
        }

        public Employee GetEmployee(Guid id)
        {
            return _employeeRepository.Get(id);
        }

        public void InsertEmployee(Employee employee)
        {
            _employeeRepository.Insert(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.Update(employee);
        }

        public void DeleteEmployee(Guid id)
        {
            Employee employee = _employeeRepository.Get(id);
            _employeeRepository.Remove(employee);
            _employeeRepository.SaveChanges();
        }
    }
}
