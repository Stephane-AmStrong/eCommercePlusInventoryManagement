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
    public class InventoryLevelsController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public InventoryLevelsController(IServiceManager serviceManager) => _serviceManager = serviceManager;


        private async Task<IEnumerable<InventoryLevelsDto>> ListInventoryLevel(CancellationToken cancellationToken)
        {
            return await _serviceManager.InventoryLevelService.GetAllAsync(cancellationToken);
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            return View(await ListInventoryLevel(cancellationToken));
        }

        public async Task<IActionResult> Details(Guid id, CancellationToken cancellationToken)
        {
            var inventoryLevelDto = await _serviceManager.InventoryLevelService.GetDetailsByIdAsync(id, cancellationToken);
            return View(inventoryLevelDto);
        }


        [NoDirectAccess]
        public async Task<IActionResult> Form(Guid? id, CancellationToken cancellationToken)
        {
            if(id is null)
            {
                return PartialView(new InventoryLevelDto());
            }
            
            var inventoryLevelDto = await _serviceManager.InventoryLevelService.GetByIdAsync(id.Value, cancellationToken);
            return PartialView(inventoryLevelDto);
        }

        
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(Guid? id, InventoryLevelDto inventoryLevel, CancellationToken cancellationToken)
        {
            //intervenor.AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!ModelState.IsValid) return Json(new { isValid = false, html = RazorViewHelper.RenderRazorViewToString(this, "Form", inventoryLevel) });

            if (id is null || id == new Guid())
            {
                await _serviceManager.InventoryLevelService.CreateAsync(inventoryLevel, cancellationToken);
            }
            else
            {
                await _serviceManager.InventoryLevelService.UpdateAsync(id.Value, inventoryLevel, cancellationToken);
            }

            return Json(new { isValid = true, html = RazorViewHelper.RenderRazorViewToString(this, "_ViewAll", await ListInventoryLevel(cancellationToken)) });
        }


        public async Task<IActionResult> RequestDeleteConfirmation(Guid? id, CancellationToken cancellationToken)
        {
            if (id == null) return BadRequest();
            var inventoryLevelDto = await _serviceManager.InventoryLevelService.GetByIdAsync(id.Value, cancellationToken);
            return View(inventoryLevelDto);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(Guid? id, CancellationToken cancellationToken)
        {
            await _serviceManager.InventoryLevelService.DeleteAsync(id.Value, cancellationToken);
            return Json(new { isValid = true, html = RazorViewHelper.RenderRazorViewToString(this, "_ViewAll", await ListInventoryLevel(cancellationToken)) });
        }
    }
}
