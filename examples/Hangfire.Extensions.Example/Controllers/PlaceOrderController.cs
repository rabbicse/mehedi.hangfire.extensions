using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mehedi.Hangfire.Extensions;

namespace Hangfire.Extensions.Example.Controllers;

public class PlaceOrder : IRequest
{
    public Guid OrderId { get; set; }
}

[ApiController]
[Route("[controller]")]
public class PlaceOrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public PlaceOrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("/sales/orders/{orderId:Guid}")]
    public IActionResult Action([FromRoute] Guid orderId)
    {
        _mediator.Enqueue("Place Order", new PlaceOrder
        {
            OrderId = orderId
        });

        return NoContent();
    }    
}

public class PlaceOrderHandler : IRequestHandler<PlaceOrder>
{
    public async Task Handle(PlaceOrder request, CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromSeconds(30));
    }
}
