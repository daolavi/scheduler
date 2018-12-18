using Microsoft.Extensions.DependencyInjection;
using NCrontab;
using Scheduler.Lib.BackgroundService;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Scheduler.Lib.Scheduler
{
    public abstract class ScheduledProcessor : ScopedProcessor
    {
        private CrontabSchedule _schedule;

        private DateTime _nextRun;

        protected abstract string Schedule { get; }

        protected ScheduledProcessor(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
            _schedule = CrontabSchedule.Parse(Schedule);
            _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                var now = DateTime.Now;
                var nextrun = _schedule.GetNextOccurrence(now);
                if (now > _nextRun)
                {
                    await Process();
                    _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
                }
            }
            while (!stoppingToken.IsCancellationRequested);
        }
    }
}
