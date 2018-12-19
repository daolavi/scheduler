using Microsoft.Extensions.DependencyInjection;
using Scheduler.Lib.Scheduler;
using System;
using System.Threading.Tasks;

namespace Scheduler.API.SchedulerTask
{
    public class LogTask : ScheduledProcessor
    {
        public LogTask(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        protected override string Schedule => "*/5 * * * *";

        public override Task ProcessInScope(IServiceProvider serviceProvider)
        {
            Console.WriteLine($"Logging Time {DateTime.Now}");
            return Task.CompletedTask;
        }
    }
}
