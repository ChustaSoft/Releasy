using Microsoft.Extensions.DependencyInjection;

namespace ChustaSoft.Releasy.Configuration
{
    public static class MvcBuilderExtensions
    {

        public static IMvcBuilder AddReleaseController(this IMvcBuilder mvcBuilder)
        {
            var assembly = typeof(MvcBuilderExtensions).Assembly;

            mvcBuilder.AddApplicationPart(assembly).AddControllersAsServices();

            return mvcBuilder;
        }

    }
}
