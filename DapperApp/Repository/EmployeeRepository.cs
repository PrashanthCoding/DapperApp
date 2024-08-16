using Dapper;
using DapperApp.Models;
using DapperApp.Repository.Interface;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperApp.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnection _dbConnection;

        public EmployeeRepository(IConfiguration configuration)
        {
            _dbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public List<Employee> GetAll()
        {
            string sql = "SELECT * FROM Employees";
            List<Employee> employees = _dbConnection.Query<Employee>(sql).ToList();
            return employees;
        }

        public Employee GetById(int id)
        {
            string sql = "SELECT * FROM Employees WHERE @Id = Id";
            Employee employee = _dbConnection.Query<Employee>(sql, new { @Id = id }).SingleOrDefault();
            return employee;
        }

        public int Add(Employee employee)
        {
            string sql = "INSERT INTO Employees(Name, EmailAddress, PhoneNumber, Age, Salary) VALUES (@Name, @EmailAddress, @PhoneNumber, @Age, @Salary)" + "SELECT CAST(SCOPE_IDENTITY() AS INT)";
            int id = _dbConnection.Query<int>(sql, new
            {
                @Name = employee.Name,
                @EmailAddress = employee.EmailAddress,
                @PhoneNumber = employee.PhoneNumber,
                @Age = employee.Age,
                @Salary = employee.Salary
            }).Single();

            return id;
        }

        public void Update(Employee employee)
        {
            string sql = "UPDATE Employees SET @Name= Name, EmailAddress = @EmailAddress, PhoneNumber = @PhoneNumber, Age= @Age, Salary = @Salary";
            _dbConnection.Execute(sql, employee);
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM WHERE @Id = Id";
            _dbConnection.Execute(sql, new { @Id = id });
        }
    }
}
