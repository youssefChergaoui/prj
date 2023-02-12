using static Artisanale.Web.SD;

namespace Artisanale.Web.Models
{
    public class ApiRequest
    {
        public ApiType apitype { get; set; }
        public string url   { get; set; }

        public object Data { get; set; }

        public string AccessToken { get; set; } = "";
    }
}
