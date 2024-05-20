﻿using Hangfire;

namespace Mehedi.Hangfire.Extensions;

public static class HangfireUtils
{
    /// <summary>
    /// Gets the status of a Hangfire background job by its job id.
    /// </summary>
    /// <param name="jobId">The identifier of the background job.</param>
    /// <returns>The current state of the background job.</returns>
    public static string? GetJobStatus(string jobId)
    {
        var monitor = JobStorage.Current.GetMonitoringApi();

        var jobData = monitor.JobDetails(jobId);
        if (jobData == null)
        {
            return "Job not found";
        }

        return jobData.History.FirstOrDefault()?.StateName;
    }
}
