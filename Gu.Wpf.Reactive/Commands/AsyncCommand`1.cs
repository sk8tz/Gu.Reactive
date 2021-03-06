namespace Gu.Wpf.Reactive
{
    using System;
    using System.Reactive.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Gu.Reactive;

    /// <summary>
    /// http://msdn.microsoft.com/en-us/magazine/dn630647.aspx
    /// An async command that uses command parameter
    /// Returns a Task
    /// </summary>
    public class AsyncCommand<TParameter> : ConditionRelayCommand<TParameter>
    {
        private readonly ITaskRunner<TParameter> runner;

        public AsyncCommand(Func<TParameter, Task> action, params ICondition[] conditions)
            : this(new TaskRunner<TParameter>(action), conditions)
        {
        }

        public AsyncCommand(Func<TParameter, Task> action)
            : this(new TaskRunner<TParameter>(action))
        {
        }

        public AsyncCommand(Func<TParameter, CancellationToken, Task> action, params ICondition[] conditions)
            : this(new TaskRunnerCancelable<TParameter>(action), conditions)
        {
        }

        public AsyncCommand(Func<TParameter, CancellationToken, Task> action)
            : this(new TaskRunnerCancelable<TParameter>(action))
        {
        }

        private AsyncCommand(ITaskRunner<TParameter> runner, ICondition[] conditions)
            : this(runner, new AndCondition(runner.CanRunCondition, conditions))
        {
        }

        private AsyncCommand(ITaskRunner<TParameter> runner)
            : this(runner, runner.CanRunCondition)
        {
        }

        private AsyncCommand(ITaskRunner<TParameter> runner, ICondition condition)
            : base(runner.Run, condition)
        {
            this.runner = runner;
            runner.ObservePropertyChangedSlim(nameof(runner.TaskCompletion))
                   .Subscribe(_ => this.OnPropertyChanged(nameof(this.Execution)));
            this.CancelCommand = new ConditionRelayCommand(runner.Cancel, runner.CanCancelCondition);
        }

        public ConditionRelayCommand CancelCommand { get; }

        public NotifyTaskCompletion Execution => this.runner.TaskCompletion;

        protected override async void InternalExecute(TParameter parameter)
        {
            this.IsExecuting = true;
            try
            {
                this.Action(parameter);
                await this.Execution.ObservePropertyChangedSlim(nameof(this.Execution.IsCompleted))
                               .FirstAsync(_ => this.Execution?.IsCompleted == true);
            }
            finally
            {
                this.IsExecuting = false;
            }
        }
    }
}
