using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using Kickstart;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[assembly: RegisterWebPageRoute(
    contentTypeName: LandingPage.CONTENT_TYPE_NAME,
    controllerType: typeof(Kickstart.Web.Features.LandingPages.LandingPageController))]

namespace Kickstart.Web.Features.LandingPages
{
    public class LandingPageController : Controller
    {
        private readonly IContentRetriever _contentRetriever;

        public LandingPageController(IContentRetriever contentRetriever)
        {
            _contentRetriever = contentRetriever;
        }

        public async Task<IActionResult> Index()
        {
            var parameters = new RetrieveCurrentPageParameters
            {
                LinkedItemsMaxLevel = 1
            };
            var page = await _contentRetriever.RetrieveCurrentPage<LandingPage>(parameters);
            var model = LandingPageViewModel.GetViewModel(page);
            return new TemplateResult(model);
        }
    }
}
