using Contracts.DataTransferObjects;
using Domain.Models;
using Domain.Models.Parameters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Presentation.FilterAttributes;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/owners")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
        }

        [HttpGet]
        [PageMetadataFilterAttribute<Owner>]
        public async Task<IActionResult> GetAllOwners([FromQuery] OwnerQueryParameters ownerParameters, CancellationToken cancellationToken)
        {
            var owners = await ownerService.GetAllOwners(ownerParameters, cancellationToken);
            return Ok(owners);
        }

        [HttpGet("{ownerId:guid}", Name = "OwnerById")]
        public async Task<IActionResult> GetOwnerById(Guid ownerId, CancellationToken cancellationToken)
        {
            var owner = await ownerService.GetOwnerById(ownerId, cancellationToken);
            return Ok(owner);
        }

        [HttpGet("{ownerId:guid}/details")]
        public async Task<IActionResult> GetOwnerWithDetails(Guid ownerId, CancellationToken cancellationToken)
        {
            var owner = await ownerService.GetOwnerWithDetails(ownerId, cancellationToken);
            return Ok(owner);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner([FromBody] OwnerForCreationDto ownerForCreateDto, CancellationToken cancellationToken)
        {
            var ownerResult = await ownerService.CreateOwner(ownerForCreateDto, cancellationToken);
            return StatusCode(StatusCodes.Status201Created, ownerResult);
        }

        [HttpPut("{ownerId:guid}")]
        public async Task<IActionResult> UpdateOwner(Guid ownerId, [FromBody] OwnerForUpdateDto ownerForUpdateDto, CancellationToken cancellationToken)
        {
            await ownerService.UpdateOwner(ownerId, ownerForUpdateDto, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{ownerId:guid}")]
        public async Task<IActionResult> DeleteOwner(Guid ownerId, CancellationToken cancellationToken)
        {
            await ownerService.DeleteOwner(ownerId, cancellationToken);
            return NoContent();
        }
    }
}
