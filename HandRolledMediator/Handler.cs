namespace HandRolledMediator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Handler
    {
        private readonly IEnumerable<ICommandHandler> handlers;

        public Handler(IEnumerable<ICommandHandler> handlers)
        {
            this.handlers = handlers;
        }

        public U Execute<T, U>(T command) where T : class
        {
            var handler = this.handlers.FirstOrDefault(x => x.GetType().BaseType.GenericTypeArguments.Any(y => y == typeof(T)));

            if (handler == null)
            {
                throw new Exception($"Unfound handler for {typeof(T).Name}");
            }

            return (U)handler.Execute(command);
        }

        public void Handle<T>(T command) where T : class
        {
            var handler = this.handlers.FirstOrDefault(x => x.GetType().BaseType.GenericTypeArguments.Any(y => y == typeof(T)));

            if (handler == null)
            {
                throw new Exception($"Unfound handler for {typeof(T).Name}");
            }

            handler.Handle(command);
        }
    }
}
