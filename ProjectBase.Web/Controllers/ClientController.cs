using ProjectBase.Core.Entities;
using ProjectBase.CQRS.Commands.Client;
using ProjectBase.CQRS.Queries.Client;
using ProjectBase.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectBase.Web.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }
        private readonly IMediator _mediator;

        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new QueryAllClient());

            var viewModel = new List<ClientViewModel>();
            foreach (var item in result)
            {
                viewModel.Add(ConvertClientToViewModel(item));
            }

            return View(viewModel);
        }

        public async Task<IActionResult> ListAll()
        {
            var result = await _mediator.Send(new QueryAllClient());

            var viewModel = new List<ClientViewModel>();
            foreach (var item in result)
            {
                viewModel.Add(ConvertClientToViewModel(item));
            }

            return Ok(viewModel);
        }

        public IActionResult Create()
        {
            return View(new ClientViewModel { });
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(new CreateClientCommand(viewModel.BusinessName, viewModel.CnpjNumber, viewModel.Manager, viewModel.Email));
            if (result.HasError)
            {
                ModelState.AddModelError(result.Key, result.Content);
                return BadRequest(ModelState);
            }

            return Ok(result.Content);
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await _mediator.Send(new QueryClientById(id));
            var viewModel = ConvertClientToViewModel(result);

            return View(viewModel);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ClientViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(new UpdateClientCommand(viewModel.Id, viewModel.BusinessName, viewModel.CnpjNumber, viewModel.Manager, viewModel.Email));
            if (result.HasError)
            {
                ModelState.AddModelError(result.Key, result.Content);
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(new DeleteClientCommand(id));
            if (result.HasError)
            {
                ModelState.AddModelError(result.Key, result.Content);
                return BadRequest(ModelState);
            }

            return Ok();
        }

        private static ClientViewModel ConvertClientToViewModel(Client entity)
        {
            return new ClientViewModel
            {
                Id = entity.Id,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                BusinessName = entity.BusinessName,
                CnpjNumber = entity.CnpjNumber,
                Manager = entity.Manager,
                Email = entity.Email,
                WhatsApp = entity.WhatsApp,
            };
        }
    }
}
