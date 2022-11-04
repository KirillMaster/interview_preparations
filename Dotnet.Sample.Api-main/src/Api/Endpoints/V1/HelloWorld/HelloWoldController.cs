using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Dotnet.Sample.Shared;
using static Dotnet.Sample.Shared.CONSTANTS;

namespace Dotnet.Sample.Api.Endpoints.V1.Products
{
    public partial class HelloWorldController : BaseApiController
    {
        [ApiVersion(ApiVersionNumbers.V1)]
        [HttpGet("",Name = RouteNames.HelloWorld)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> HelloWorld(string culture = "en-US")
        {
            var response = "Hello, Man";
            return await Task.FromResult(Ok(response));
        }
    }
}