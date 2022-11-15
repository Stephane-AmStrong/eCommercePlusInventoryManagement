using Contracts;
using DataTransfertObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/appUsers")]
    public class AppUsersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AppUsersController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetAppUsers(CancellationToken cancellationToken)
        {
            var appUsers = await _serviceManager.AppUserService.GetAllAsync(cancellationToken);

            return Ok(appUsers);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAppUserById(string id, CancellationToken cancellationToken)
        {
            var appUserDto = await _serviceManager.AppUserService.GetByIdAsync(id, cancellationToken);

            return Ok(appUserDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppUser([FromBody] AppUserWriteDto appUserWriteDto)
        {
            var appUserDto = await _serviceManager.AppUserService.CreateAsync(appUserWriteDto);

            return CreatedAtAction(nameof(GetAppUserById), new { id = appUserDto.Id }, appUserDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAppUser(string id, [FromBody] AppUserWriteDto appUserWriteDto, CancellationToken cancellationToken)
        {
            await _serviceManager.AppUserService.UpdateAsync(id, appUserWriteDto, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAppUser(string id, CancellationToken cancellationToken)
        {
            await _serviceManager.AppUserService.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
