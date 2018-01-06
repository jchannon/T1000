namespace BotwinMediator
{
    public interface ICommandHandler
    {
        object Execute(object command);
        void Handle(object command);
    }
}
