namespace HandRolledMediator
{
    public abstract class CommandHandler<T> : ICommandHandler
    {
        protected virtual void Handle(T command)
        {
        }

        protected virtual object Execute(T command)
        {
            return default;
        }

        object ICommandHandler.Execute(object command)
        {
            return this.Execute((T)command);
        }

        void ICommandHandler.Handle(object command)
        {
            this.Handle((T)command);
        }
    }
}
