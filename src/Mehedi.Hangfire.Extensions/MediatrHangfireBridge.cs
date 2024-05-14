using MediatR;
using System.ComponentModel;

namespace Mehedi.Hangfire.Extensions;

/// <summary>
/// Initializes a new instance of the <see cref="MediatrHangfireBridge"/> class.
/// Source: https://gist.github.com/dcomartin/8ddbd86a7df893cfcef38b6fa06dd8ea#file-mediatorhangfirebridge-cs
/// </summary>
/// <param name="mediator">An instance of <see cref="IMediator"/> to send commands.</param>
public class MediatrHangfireBridge(IMediator mediator)
{
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Sends a MediatR command directly.
    /// </summary>
    /// <param name="command">An instance of a class implementing <see cref="IRequest"/> representing the command to be sent.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task SendAsync(IRequest command)
    {
        await _mediator.Send(command);
    }

    /// <summary>
    /// Sends a MediatR command as a Hangfire job, with a specified job name.
    /// </summary>
    /// <param name="jobName">A <see cref="string"/> representing the name of the job. This is useful for identifying and managing jobs within Hangfire.</param>
    /// <param name="command">An instance of a class implementing <see cref="IRequest"/> representing the command to be sent.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    [DisplayName("{0}")]
    public async Task SendAsync(string jobName, IRequest command)
    {
        await _mediator.Send(command);
    }
}
