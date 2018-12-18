using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Scheduler.Lib.Scheduler
{
    public class HourlyTask : ScheduledProcessor
    {

        public HourlyTask(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        protected override string Schedule => "* */1 * * *";

        public override Task ProcessInScope(IServiceProvider serviceProvider)
        {
            return Task.CompletedTask;
        }
    }
}
