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
    /// Sends the specified command asynchronously through MediatR.
    /// </summary>
    /// <typeparam name="T">The type of response expected from the command.</typeparam>
    /// <param name="command">The command to be sent through MediatR.</param>
    /// <remarks>
    /// This method sends the specified command asynchronously through MediatR, allowing for decoupled and asynchronous execution of application logic.
    /// </remarks>
    public async Task SendAsync<T>(IRequest<T> command)
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

    /// <summary>
    /// Sends the specified command asynchronously through MediatR with a custom job name.
    /// </summary>
    /// <typeparam name="T">The type of response expected from the command.</typeparam>
    /// <param name="jobName">The name of the job being executed.</param>
    /// <param name="command">The command to be sent through MediatR.</param>
    /// <remarks>
    /// This method sends the specified command asynchronously through MediatR with a custom job name, allowing for decoupled and asynchronous execution of application logic.
    /// </remarks>
    [DisplayName("{0}")]
    public async Task SendAsync<T>(string jobName, IRequest<T> command)
    {
        await _mediator.Send(command);
    }
}
