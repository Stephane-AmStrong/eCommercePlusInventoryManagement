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
    public class OrderItemsController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public OrderItemsController(IServiceManager serviceManager) => _serviceManager = serviceManager;


        private async Task<IEnumerable<OrderItemsDto>> ListOrderItem(CancellationToken cancellationToken)
        {
            return await _serviceManager.OrderItemService.GetAllAsync(cancellationToken);
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            return View(await ListOrderItem(cancellationToken));
        }

        public async Task<IActionResult> Details(Guid id, CancellationToken cancellationToken)
        {
            var orderItemCategoryDto = await _serviceManager.OrderItemService.GetDetailsByIdAsync(id, cancellationToken);
            return View(orderItemCategoryDto);
        }


        [NoDirectAccess]
        public async Task<IActionResult> Form(Guid? id, CancellationToken cancellationToken)
        {
            if (id is null)
            {
                return PartialView(new OrderItemDto());
            }

            var orderItemCategoryDto = await _serviceManager.OrderItemService.GetByIdAsync(id.Value, cancellationToken);
            return PartialView(orderItemCategoryDto);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(Guid? id, OrderItemDto orderItemCategoryRequest, CancellationToken cancellationToken)
        {
            //intervenor.AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!ModelState.IsValid) return Json(new { isValid = false, html = RazorViewHelper.RenderRazorViewToString(this, "Form", orderItemCategoryRequest) });

            if (id is null || id == new Guid())
            {
                await _serviceManager.OrderItemService.CreateAsync(orderItemCategoryRequest, cancellationToken);
            }
            else
            {
                await _serviceManager.OrderItemService.UpdateAsync(id.Value, orderItemCategoryRequest, cancellationToken);
            }

            return Json(new { isValid = true, html = RazorViewHelper.RenderRazorViewToString(this, "_ViewAll", await ListOrderItem(cancellationToken)) });
        }


        public async Task<IActionResult> RequestDeleteConfirmation(Guid? id, CancellationToken cancellationToken)
        {
            if (id is null) return BadRequest();
            var orderItemCategoryDto = await _serviceManager.OrderItemService.GetByIdAsync(id.Value, cancellationToken);
            return PartialView(orderItemCategoryDto);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id, CancellationToken cancellationToken)
        {
            await _serviceManager.OrderItemService.DeleteAsync(id.Value, cancellationToken);
            return Json(new { isValid = true, html = RazorViewHelper.RenderRazorViewToString(this, "_ViewAll", await ListOrderItem(cancellationToken)) });
        }
    }
}
