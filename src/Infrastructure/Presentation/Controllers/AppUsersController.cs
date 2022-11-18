using Contracts;
using DataTransfertObjects;
using Microsoft.AspNetCore.Mvc;
using Presentation.Helpers;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Presentation.Helpers.RazorViewHelper;

namespace Presentation.Controllers
{
    public class AppUsersController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public AppUsersController(IServiceManager serviceManager) => _serviceManager = serviceManager;


        private async Task<IEnumerable<AppUsersDto>> ListAppUser(CancellationToken cancellationToken)
        {
            return await _serviceManager.AppUserService.GetAllAsync(cancellationToken);
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            return View(await ListAppUser(cancellationToken));
        }

        public async Task<IActionResult> Details(string id, CancellationToken cancellationToken)
        {
            var appUserCategoryDto = await _serviceManager.AppUserService.GetDetailsByIdAsync(id, cancellationToken);
            return View(appUserCategoryDto);
        }


        [NoDirectAccess]
        public async Task<IActionResult> Form(string id, CancellationToken cancellationToken)
        {
            if (id is null)
            {
                return PartialView(new AppUserDto());
            }

            var appUserCategoryDto = await _serviceManager.AppUserService.GetByIdAsync(id, cancellationToken);
            return PartialView(appUserCategoryDto);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(string id, AppUserDto appUserCategoryRequest, CancellationToken cancellationToken)
        {
            //intervenor.AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!ModelState.IsValid) return Json(new { isValid = false, html = RazorViewHelper.RenderRazorViewToString(this, "Form", appUserCategoryRequest) });

            if (string.IsNullOrEmpty(id))
            {
                await _serviceManager.AppUserService.CreateAsync(appUserCategoryRequest, cancellationToken);
            }
            else
            {
                await _serviceManager.AppUserService.UpdateAsync(id, appUserCategoryRequest, cancellationToken);
            }

            return Json(new { isValid = true, html = RazorViewHelper.RenderRazorViewToString(this, "_ViewAll", await ListAppUser(cancellationToken)) });
        }


        public async Task<IActionResult> RequestDeleteConfirmation(string id, CancellationToken cancellationToken)
        {
            if (id is null) return BadRequest();
            var appUserCategoryDto = await _serviceManager.AppUserService.GetByIdAsync(id, cancellationToken);
            return PartialView(appUserCategoryDto);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            await _serviceManager.AppUserService.DeleteAsync(id, cancellationToken);
            return Json(new { isValid = true, html = RazorViewHelper.RenderRazorViewToString(this, "_ViewAll", await ListAppUser(cancellationToken)) });
        }
    }
}
