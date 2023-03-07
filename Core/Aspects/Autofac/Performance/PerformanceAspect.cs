using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;

namespace Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interwal;
        private Stopwatch _stopwatch;

        public PerformanceAspect(int interwal)
        {
            _interwal = interwal;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalMinutes > _interwal)
            {
                Debug.WriteLine($"Perfomance:{invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}--->{_stopwatch.Elapsed.TotalSeconds}");
            }
            _stopwatch.Reset();
        }


    }
}
