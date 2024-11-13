using EmployeDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeDesktop.Services
{
    public class EmployeeService : IEmployeeService
    {
        public bool DeleteTask(EmployeeModel employeeModel)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeModel> GetEmployee()
        {
            try
            {

                HttpClient client = new HttpClient();
                
                client.BaseAddress = new Uri("http://localhost:5101/api/");
                //client.DefaultRequestHeaders.Add("appkey", "myapp_key");
                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("employees").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<EmployeeModel>>().Result;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool SaveTask(EmployeeModel employeeModel)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTask(EmployeeModel employeeModel)
        {
            throw new NotImplementedException();
        }
    }
}
