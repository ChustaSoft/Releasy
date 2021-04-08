using Microsoft.Extensions.DependencyInjection;

namespace ChustaSoft.Releasy.Configuration
{
    public static class MvcBuilderExtensions
    {

        /// <summary>
        /// Add Releasy controller to the existing MvcBuilder
        /// </summary>
        /// <param name="mvcBuilder">Project MvcBuilder</param>
        /// <returns>Same MvcBuilder</returns>
        public static IMvcBuilder AddReleaseController(this IMvcBuilder mvcBuilder)
        {
            var assembly = typeof(MvcBuilderExtensions).Assembly;

            mvcBuilder.AddApplicationPart(assembly).AddControllersAsServices();

            return mvcBuilder;
        }

    }
}
