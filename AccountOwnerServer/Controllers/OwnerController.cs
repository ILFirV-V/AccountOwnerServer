using Contracts.Services;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AccountOwnerServer.Controllers
{
    [Route("api/owner")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOwners()
        {
            var owners = await ownerService.GetAllOwners();
            return Ok(owners);
        }

        [HttpGet("{id}", Name = "OwnerById")]
        public async Task<IActionResult> GetOwnerById(Guid id)
        {
            var owner = await ownerService.GetOwnerById(id);
            return Ok(owner);
        }

        [HttpGet("{id}/account")]
        public async Task<IActionResult> GetOwnerWithDetails(Guid id)
        {
            var owner = await ownerService.GetOwnerWithDetails(id);
            return Ok(owner);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner([FromBody] OwnerForCreationDto owner)
        {
            await ownerService.CreateOwner(owner);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(Guid id, [FromBody] OwnerForUpdateDto owner)
        {
            await ownerService.UpdateOwner(id, owner);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(Guid id)
        {
            await ownerService.DeleteOwner(id);
            return NoContent();
        }
    }
}