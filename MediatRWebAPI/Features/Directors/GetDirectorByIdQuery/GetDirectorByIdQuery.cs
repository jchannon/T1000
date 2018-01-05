namespace MediatRWebAPI.Features.Directors.GetDirectorByIdQuery
{
    using Models;

    public class GetDirectorByIdQuery : IGetDirectorByIdQuery
    {
        public Director Execute(int id)
        {
            //Do some SQL
            
            return new Director { Name = "Steven Spielberg" };
        }
    }
}