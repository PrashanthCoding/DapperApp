using DapperApp.Models;

namespace DapperApp.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Employee GetById(int id);
        List<Employee> GetAll();
        int Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}
