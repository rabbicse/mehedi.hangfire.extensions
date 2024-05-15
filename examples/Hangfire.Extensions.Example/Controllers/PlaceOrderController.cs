using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mehedi.Hangfire.Extensions;
using Mehedi.Application.SharedKernel.Responses;

namespace Hangfire.Extensions.Example.Controllers;

public class PlaceOrderResponse(Guid id) : IResponse
{
    public Guid Id { get; } = id;
}

public class PlaceOrder : IRequest
{
    public Guid OrderId { get; set; }
}

public class PlaceOrders : IRequest<Result<PlaceOrderResponse>>
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

    [HttpPost("/sales/neworders/{orderId:Guid}")]
    public IActionResult OrderAction([FromRoute] Guid orderId)
    {
        _mediator.Enqueue("Place Order", new PlaceOrders
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

public class PlaceOrdersHandler : IRequestHandler<PlaceOrders, Result<PlaceOrderResponse>>
{
    public async Task<Result<PlaceOrderResponse>> Handle(PlaceOrders request, CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromSeconds(30));
        // Returning the ID and success message.
        return Result<PlaceOrderResponse>.Success(
            new PlaceOrderResponse(request.OrderId), "Successfully ordered!");
    }
}