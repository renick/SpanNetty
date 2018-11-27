﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DotNetty.Common.Concurrency
{
    using System;
    using System.Threading;

    sealed class ActionScheduledAsyncTask : ScheduledAsyncTask
    {
        readonly Action action;

        public ActionScheduledAsyncTask(AbstractScheduledEventExecutor executor, Action action, in PreciseTimeSpan deadline, CancellationToken cancellationToken)
            : base(executor, deadline, executor.NewPromise(), cancellationToken)
        {
            this.action = action;
        }

        protected override void Execute() => this.action();
    }
}