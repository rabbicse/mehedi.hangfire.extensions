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
    /// Enqueues a mediator request to be processed by Hangfire with a specified job name.
    /// </summary>
    /// <param name="mediator">The instance of the mediator used to send the request.</param>
    /// <param name="jobName">The name assigned to the background job.</param>
    /// <param name="request">The mediator request to be enqueued.</param>
    /// <returns>The unique identifier of the enqueued background job.</returns>
    /// <remarks>
    /// This method uses Hangfire's <see cref="BackgroundJobClient"/> to enqueue a job that
    /// will send the given mediator request asynchronously through the <see cref="MediatrHangfireBridge"/>
    /// with the specified job name.
    /// </remarks>
    public static string Enqueue(this IMediator mediator, string jobName, IRequest request)
    {
        var client = new BackgroundJobClient();
        return client.Enqueue<MediatrHangfireBridge>(bridge => bridge.SendAsync(jobName, request));
    }

    /// <summary>
    /// Enqueues a mediator request to be processed by Hangfire with a specified job name.
    /// </summary>
    /// <typeparam name="T">The response type of the mediator request.</typeparam>
    /// <param name="mediator">The instance of the mediator used to send the request.</param>
    /// <param name="jobName">The name assigned to the background job.</param>
    /// <param name="request">The mediator request to be enqueued.</param>
    /// <returns>The unique identifier of the enqueued background job.</returns>
    /// <remarks>
    /// This method uses Hangfire's <see cref="BackgroundJobClient"/> to enqueue a job that
    /// will send the given mediator request asynchronously through the <see cref="MediatrHangfireBridge"/>
    /// with the specified job name.
    /// </remarks>
    public static string Enqueue<T>(this IMediator mediator, string jobName, IRequest<T> request)
    {
        var client = new BackgroundJobClient();
        return client.Enqueue<MediatrHangfireBridge>(bridge => bridge.SendAsync(jobName, request));
    }

    /// <summary>
    /// Enqueues a mediator request to be processed by Hangfire.
    /// </summary>
    /// <param name="mediator">The instance of the mediator used to send the request.</param>
    /// <param name="request">The mediator request to be enqueued.</param>
    /// <returns>The unique identifier of the enqueued background job.</returns>
    /// <remarks>
    /// This method uses Hangfire's <see cref="BackgroundJobClient"/> to enqueue a job that
    /// will send the given mediator request asynchronously through the <see cref="MediatrHangfireBridge"/>.
    /// </remarks>
    public static string Enqueue(this IMediator mediator, IRequest request)
    {
        var client = new BackgroundJobClient();
        return client.Enqueue<MediatrHangfireBridge>(bridge => bridge.SendAsync(request));
    }

    /// <summary>
    /// Enqueues a mediator request to be processed by Hangfire.
    /// </summary>
    /// <typeparam name="T">The response type of the mediator request.</typeparam>
    /// <param name="mediator">The instance of the mediator used to send the request.</param>
    /// <param name="request">The mediator request to be enqueued.</param>
    /// <returns>The unique identifier of the enqueued background job.</returns>
    /// <remarks>
    /// This method uses Hangfire's <see cref="BackgroundJobClient"/> to enqueue a job that
    /// will send the given mediator request asynchronously through the <see cref="MediatrHangfireBridge"/>.
    /// </remarks> 
    public static string Enqueue<T>(this IMediator mediator, IRequest<T> request)
    {
        var client = new BackgroundJobClient();
        return client.Enqueue<MediatrHangfireBridge>(bridge => bridge.SendAsync(request));
    }
}
