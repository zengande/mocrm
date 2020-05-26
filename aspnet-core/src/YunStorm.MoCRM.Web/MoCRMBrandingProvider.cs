using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace YunStorm.MoCRM.Web
{
    [Dependency(ReplaceServices = true)]
    public class MoCRMBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "MoCRM";
    }
}
