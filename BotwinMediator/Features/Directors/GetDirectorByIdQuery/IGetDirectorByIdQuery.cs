namespace BotwinMediator.Features.Directors.GetDirectorByIdQuery
{
    using Models;

    public interface IGetDirectorByIdQuery
    {
        Director Execute(int id);
    }
}
