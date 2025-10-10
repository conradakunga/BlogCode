using System.Diagnostics;

const string applicationName = "My Awesome App";
const string logName = "Application";

// Check if source exists
if (!EventLog.Exists(applicationName))
{
    // Create source
    EventLog.CreateEventSource(applicationName, logName);
}

// Create a logger
using (var logger = new EventLog(logName))
{
    // Set the source
    logger.Source = applicationName;
    // Write the entry
    logger.WriteEntry("This is a test", EventLogEntryType.Information);
}