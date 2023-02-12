using Artisanale.Web.Models;

namespace Artisanale.Web.Services.IServices
{
    public interface IBaseServices:IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
