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
    public class ItemCategoriesController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ItemCategoriesController(IServiceManager serviceManager) => _serviceManager = serviceManager;


        private async Task<IEnumerable<ItemCategoriesDto>> ListItemCategory(CancellationToken cancellationToken)
        {
            return await _serviceManager.ItemCategoryService.GetAllAsync(cancellationToken);
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            return View(await ListItemCategory(cancellationToken));
        }

        public async Task<IActionResult> Details(Guid id, CancellationToken cancellationToken)
        {
            var itemCategoryDto = await _serviceManager.ItemCategoryService.GetDetailsByIdAsync(id, cancellationToken);
            return View(itemCategoryDto);
        }


        [NoDirectAccess]
        public async Task<IActionResult> Form(Guid? id, CancellationToken cancellationToken)
        {
            if (id is null)
            {
                return PartialView(new ItemCategoryDto());
            }

            var itemCategoryDto = await _serviceManager.ItemCategoryService.GetByIdAsync(id.Value, cancellationToken);
            return PartialView(itemCategoryDto);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(Guid? id, ItemCategoryDto itemCategoryRequest, CancellationToken cancellationToken)
        {
            //intervenor.AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!ModelState.IsValid) return Json(new { isValid = false, html = RazorViewHelper.RenderRazorViewToString(this, "Form", itemCategoryRequest) });

            if (id is null || id == new Guid())
            {
                await _serviceManager.ItemCategoryService.CreateAsync(itemCategoryRequest, cancellationToken);
            }
            else
            {
                await _serviceManager.ItemCategoryService.UpdateAsync(id.Value, itemCategoryRequest, cancellationToken);
            }

            return Json(new { isValid = true, html = RazorViewHelper.RenderRazorViewToString(this, "_ViewAll", await ListItemCategory(cancellationToken)) });
        }


        public async Task<IActionResult> RequestDeleteConfirmation(Guid? id, CancellationToken cancellationToken)
        {
            if (id is null) return BadRequest();
            var itemCategoryDto = await _serviceManager.ItemCategoryService.GetByIdAsync(id.Value, cancellationToken);
            return PartialView(itemCategoryDto);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id, CancellationToken cancellationToken)
        {
            await _serviceManager.ItemCategoryService.DeleteAsync(id.Value, cancellationToken);
            return Json(new { isValid = true, html = RazorViewHelper.RenderRazorViewToString(this, "_ViewAll", await ListItemCategory(cancellationToken)) });
        }
    }
}
