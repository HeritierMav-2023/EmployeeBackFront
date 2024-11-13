using EmployeDesktop.Models;


namespace EmployeDesktop.Services
{
    public interface IEmployeeService
    {
        bool DeleteTask(EmployeeModel employeeModel);
        List<EmployeeModel> GetEmployee();
        bool SaveTask(EmployeeModel employeeModel);
        bool UpdateTask(EmployeeModel employeeModel);
    }
}
