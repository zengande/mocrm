using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace YunStorm.MoCRM.Pages
{
    public class Index_Tests : MoCRMWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
