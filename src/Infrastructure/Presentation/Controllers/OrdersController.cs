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
    public class OrdersController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public OrdersController(IServiceManager serviceManager) => _serviceManager = serviceManager;


        private async Task<IEnumerable<OrdersDto>> ListOrder(CancellationToken cancellationToken)
        {
            return await _serviceManager.OrderService.GetAllAsync(cancellationToken);
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            return View(await ListOrder(cancellationToken));
        }

        public async Task<IActionResult> Details(Guid id, CancellationToken cancellationToken)
        {
            var orderCategoryDto = await _serviceManager.OrderService.GetDetailsByIdAsync(id, cancellationToken);
            return View(orderCategoryDto);
        }


        [NoDirectAccess]
        public async Task<IActionResult> Form(Guid? id, CancellationToken cancellationToken)
        {
            if (id is null)
            {
                return PartialView(new OrderDto());
            }

            var orderCategoryDto = await _serviceManager.OrderService.GetByIdAsync(id.Value, cancellationToken);
            return PartialView(orderCategoryDto);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(Guid? id, OrderDto orderCategoryRequest, CancellationToken cancellationToken)
        {
            //intervenor.AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!ModelState.IsValid) return Json(new { isValid = false, html = RazorViewHelper.RenderRazorViewToString(this, "Form", orderCategoryRequest) });

            if (id is null || id == new Guid())
            {
                await _serviceManager.OrderService.CreateAsync(orderCategoryRequest, cancellationToken);
            }
            else
            {
                await _serviceManager.OrderService.UpdateAsync(id.Value, orderCategoryRequest, cancellationToken);
            }

            return Json(new { isValid = true, html = RazorViewHelper.RenderRazorViewToString(this, "_ViewAll", await ListOrder(cancellationToken)) });
        }


        public async Task<IActionResult> RequestDeleteConfirmation(Guid? id, CancellationToken cancellationToken)
        {
            if (id is null) return BadRequest();
            var orderCategoryDto = await _serviceManager.OrderService.GetByIdAsync(id.Value, cancellationToken);
            return PartialView(orderCategoryDto);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id, CancellationToken cancellationToken)
        {
            await _serviceManager.OrderService.DeleteAsync(id.Value, cancellationToken);
            return Json(new { isValid = true, html = RazorViewHelper.RenderRazorViewToString(this, "_ViewAll", await ListOrder(cancellationToken)) });
        }
    }
}
