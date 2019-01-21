// Copyright (c) Peter Vrenken. All rights reserved. See License.txt in the project root for license information.

namespace EtAlii.Ubigia.Provisioning.Google
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class AsyncProcess
    {
        private Task _task;
        private readonly AutoResetEvent _stopEvent = new AutoResetEvent(false);
        private readonly WaitHandle[] _events;

        protected TimeSpan Interval { get; set; } = TimeSpan.FromMinutes(1);

        public event Action<Exception> Error { add => _error += value; remove => _error -= value; }
        private Action<Exception> _error;

        protected AsyncProcess()
        {
            _events = new WaitHandle[]
            {
                _stopEvent
            };
        }

        public void Start()
        {
            if (_task != null)
            {
                throw new NotSupportedException($"The {GetType().Name} has already been started.");
            }
            _task = Task.Factory.StartNew(RunInternal);
        }

        public void Stop()
        {
            if (_task == null)
            {
                throw new NotSupportedException($"The {GetType().Name} has not yet been started.");
            }
            _stopEvent.Set();
            _task.Wait();
            _task = null;
        }

        private async Task RunInternal()
        {
            while (true)
            {
                try
                {
                    await Run();
                }
                catch (Exception e)
                {
                    _error?.Invoke(e);
                }

                // See if we need to iterate once more.
                var eventId = WaitHandle.WaitAny(_events, Interval);
                var evt = eventId < _events.Length && eventId >= 0 ? _events[eventId] : null;
                if (evt == _stopEvent)
                {
                    break;
                }
            }
        }

        protected abstract Task Run();
    }
}