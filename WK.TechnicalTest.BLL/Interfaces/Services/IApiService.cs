using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WK.TechnicalTest.BLL.Interfaces.Services
{
    public interface IApiService
    {
        Task<string> GetAll(string controller);
        Task<object> GetById(string controller, Type returnType, long id);
        Task<IEnumerable<string>> Add(string controller, string objectJson);
        Task<IEnumerable<string>> Update(string controller, long id, string objectJson);
        Task<bool> Delete(string controller, long id);
    }
}
