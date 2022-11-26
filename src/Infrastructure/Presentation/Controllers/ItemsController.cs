using DataTransfertObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class ItemsController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ItemsController(IServiceManager serviceManager) => _serviceManager = serviceManager;


        private async Task<IEnumerable<ItemsDto>> ListItem(CancellationToken cancellationToken)
        {
            return await _serviceManager.ItemService.GetAllAsync(cancellationToken);
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            return View(await ListItem(cancellationToken));
        }

        public async Task<IActionResult> Details(Guid id, CancellationToken cancellationToken)
        {
            var itemCategoryDto = await _serviceManager.ItemService.GetDetailsByIdAsync(id, cancellationToken);
            return View(itemCategoryDto);
        }


        [NoDirectAccess]
        public async Task<IActionResult> Form(Guid? id, CancellationToken cancellationToken)
        {
            if (id is null)
            {
                ViewData["ItemCategoryId"] = new SelectList(await _serviceManager.ItemCategoryService.GetAllAsync(), "Id", "Name");
                return PartialView(new ItemDto());
            }

            var itemCategoryDto = await _serviceManager.ItemService.GetByIdAsync(id.Value, cancellationToken);

            ViewData["ItemCategoryId"] = new SelectList(await _serviceManager.ItemCategoryService.GetAllAsync(), "Id", "Name", itemCategoryDto.ItemCategoryId);

            return PartialView(itemCategoryDto);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(Guid? id, ItemDto itemCategoryRequest, CancellationToken cancellationToken)
        {
            //intervenor.AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!ModelState.IsValid) return Json(new { isValid = false, html = RazorViewHelper.RenderRazorViewToString(this, "Form", itemCategoryRequest) });

            if (id is null || id == new Guid())
            {
                await _serviceManager.ItemService.CreateAsync(itemCategoryRequest, cancellationToken);
            }
            else
            {
                await _serviceManager.ItemService.UpdateAsync(id.Value, itemCategoryRequest, cancellationToken);
            }

            return Json(new { isValid = true, html = RazorViewHelper.RenderRazorViewToString(this, "_ViewAll", await ListItem(cancellationToken)) });
        }


        public async Task<IActionResult> RequestDeleteConfirmation(Guid? id, CancellationToken cancellationToken)
        {
            if (id is null) return BadRequest();
            var itemCategoryDto = await _serviceManager.ItemService.GetByIdAsync(id.Value, cancellationToken);
            return PartialView(itemCategoryDto);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id, CancellationToken cancellationToken)
        {
            await _serviceManager.ItemService.DeleteAsync(id.Value, cancellationToken);
            return Json(new { isValid = true, html = RazorViewHelper.RenderRazorViewToString(this, "_ViewAll", await ListItem(cancellationToken)) });
        }
    }
}
