using Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccountOwnerServer.Controllers
{
	[Route("api/owners/{ownerId}/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet]
        public IActionResult GetAccountsForOwner(Guid ownerId)
        {
            var accounts = accountService.GetAccountsByOwnerId(ownerId);
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public IActionResult GetAccountForOwner(Guid ownerId, Guid id)
        {
            var account = accountService.GetAccountForOwner(ownerId, id);
            return Ok(account);
        }
    }
}