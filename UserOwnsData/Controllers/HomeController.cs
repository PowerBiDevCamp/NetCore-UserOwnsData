using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.PowerBI.Api.Models;
using UserOwnsData.Models;
using UserOwnsData.Services;

namespace UserOwnsData.Controllers {

  [Authorize]  
  public class HomeController : Controller {

    private PowerBiServiceApi powerBiServiceApi;
    private IWebHostEnvironment hostEnvironment;

    public HomeController(PowerBiServiceApi powerBiServiceApi, IWebHostEnvironment hostEnvironment) {
      this.powerBiServiceApi = powerBiServiceApi;
      this.hostEnvironment = hostEnvironment;
    }

    [AllowAnonymous]
    public IActionResult Index() {
      return View();
    }

    public async Task<IActionResult> Embed(string workspaceId) {
      var viewModel = await powerBiServiceApi.GetEmbeddedViewModel(workspaceId);
      // cast string value to object type in order to pass string value as  MVC view model 
      return View(viewModel as object);
    }

    public async Task<IActionResult> Workspaces() {
      IList<Group> viewModel = await powerBiServiceApi.GetWorkspaces();
      return View(viewModel);
    }

    public async Task<IActionResult> Workspace(string workspaceId) {
      WorkspaceViewModel viewModel = await powerBiServiceApi.GetWorkspaceDetails(workspaceId);
      return View(viewModel);
    }

    public IActionResult CreateWorkspace() {
      return View();
    }

    [HttpPost]
    public IActionResult CreateWorkspace(string WorkspaceName, string AddContent) {
      string appWorkspaceId = powerBiServiceApi.CreateAppWorkspace(WorkspaceName);
      if (AddContent.ToLower().Equals("true")) {
        // upload sample PBIX file #1
        string pbixPath = this.hostEnvironment.WebRootPath + @"/PBIX/COVID-19 US.pbix";
        string importName = "COVID-19 US";
        powerBiServiceApi.PublishPBIX(appWorkspaceId, pbixPath, importName);
      }
      return RedirectToAction("Workspaces", "Home");
    }

    public IActionResult DeleteWorkspace(string WorkspaceId) {
      powerBiServiceApi.DeleteAppWorkspace(WorkspaceId);
      return RedirectToAction("Workspaces", "Home");
    }

    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
