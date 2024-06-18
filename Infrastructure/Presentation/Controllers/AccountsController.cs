using Contracts.DataTransferObjects;
using Domain.Models;
using Domain.Models.Parameters;
using Microsoft.AspNetCore.Mvc;
using Presentation.FilterAttributes;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/owners/{ownerId:guid}/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet]
        [PageMetadataFilterAttribute<Account>]
        public IActionResult GetAccountsForOwner([FromQuery] AccountParameters accountParameters, Guid ownerId, CancellationToken cancellationToken)
        {
            var accounts = accountService.GetAccountsByOwnerId(ownerId, accountParameters, cancellationToken);
            return Ok(accounts);
        }

        [HttpGet("{accountId:guid}")]
        public IActionResult GetAccountForOwner(Guid ownerId, Guid accountId, CancellationToken cancellationToken)
        {
            var account = accountService.GetAccountForOwner(ownerId, accountId, cancellationToken);
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(Guid ownerId, [FromBody] AccountForCreationDto accountForCreationDto, CancellationToken cancellationToken)
        {
            var response = await accountService.CreateAsync(ownerId, accountForCreationDto, cancellationToken);
            return CreatedAtAction(nameof(GetAccountForOwner), new { accountId = response.Id }, response);
        }

        [HttpDelete("{accountId:guid}")]
        public async Task<IActionResult> DeleteAccount(Guid ownerId, Guid accountId, CancellationToken cancellationToken)
        {
            await accountService.DeleteAsync(ownerId, accountId, cancellationToken);
            return NoContent();
        }
    }
}