using Hangfire;
using MediatR;

namespace Mehedi.Hangfire.Extensions;

/// <summary>
/// Provides extension methods for enqueuing MediatR commands as Hangfire jobs.
/// Source: https://gist.github.com/dcomartin/cc95718ca86bb41dec2ec3efe09d9a9d#file-mediatorextensions-cs
/// </summary>
public static class MediatrExtensions
{
    /// <summary>
    /// Enqueues a background job to execute the specified request through MediatR.
    /// </summary>
    /// <param name="mediator">The mediator instance to use for sending the request.</param>
    /// <param name="jobName">The name of the job being enqueued.</param>
    /// <param name="request">The request to be sent through MediatR.</param>
    /// <remarks>
    /// This method enqueues a background job to handle the specified request through MediatR. It utilizes Hangfire for background job processing.
    /// </remarks>
    public static void Enqueue(this IMediator mediator, string jobName, IRequest request)
    {
        var client = new BackgroundJobClient();
        client.Enqueue<MediatrHangfireBridge>(bridge => bridge.SendAsync(jobName, request));
    }

    /// <summary>
    /// Enqueues a background job to execute the specified request through MediatR.
    /// </summary>
    /// <typeparam name="T">The type of response expected from the request.</typeparam>
    /// <param name="mediator">The mediator instance to use for sending the request.</param>
    /// <param name="jobName">The name of the job being enqueued.</param>
    /// <param name="request">The request to be sent through MediatR.</param>
    /// <remarks>
    /// This method enqueues a background job to handle the specified request through MediatR. It utilizes Hangfire for background job processing.
    /// </remarks>
    public static void Enqueue<T>(this IMediator mediator, string jobName, IRequest<T> request)
    {
        var client = new BackgroundJobClient();
        client.Enqueue<MediatrHangfireBridge>(bridge => bridge.SendAsync(jobName, request));
    }

    /// <summary>
    /// Enqueues a MediatR command as a Hangfire job.
    /// </summary>
    /// <param name="mediator">The <see cref="IMediator"/> instance to use for sending the command.</param>
    /// <param name="request">The MediatR command to be enqueued.</param>
    public static void Enqueue(this IMediator mediator, IRequest request)
    {
        var client = new BackgroundJobClient();
        client.Enqueue<MediatrHangfireBridge>(bridge => bridge.SendAsync(request));
    }

    /// <summary>
    /// Enqueues a background job to execute the specified request through MediatR.
    /// </summary>
    /// <typeparam name="T">The type of response expected from the request.</typeparam>
    /// <param name="mediator">The mediator instance to use for sending the request.</param>
    /// <param name="request">The request to be sent through MediatR.</param>
    /// <remarks>
    /// This method enqueues a background job to handle the specified request through MediatR. It utilizes Hangfire for background job processing.
    /// </remarks>
    public static void Enqueue<T>(this IMediator mediator, IRequest<T> request)
    {
        var client = new BackgroundJobClient();
        client.Enqueue<MediatrHangfireBridge>(bridge => bridge.SendAsync(request));
    }
}
