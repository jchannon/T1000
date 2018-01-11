namespace MediatRWebAPI.Tests.Features.Films.ListFilmById
{
    using FakeItEasy;
    using MediatRWebAPI.Features.CastMembers.GetCastByFilmIdQuery;
    using MediatRWebAPI.Features.Directors.GetDirectorByIdQuery;
    using MediatRWebAPI.Features.Films.ListFilmById;
    using MediatRWebAPI.Features.Films.ListFilmByIdQuery;
    using Xunit;

    public class ListFilmsByIdMessageHandlerTests
    {
        //This class can be unit test and/or integration test as our handler class is responsible for doing whatever it takes

        [Fact]
        public void Should_return_film() 
        {
            //Given
            var fakeListFilmByIdQuery = A.Fake<IListFilmByIdQuery>();
            var fakeGetDirectorByIdQuery = A.Fake<IGetDirectorByIdQuery>();
            var fakeGetCastByIdDirectory = A.Fake<IGetCastByFilmIdQuery>();
            var handler = new ListFilmsByIdMessageHandler(fakeListFilmByIdQuery, fakeGetDirectorByIdQuery, fakeGetCastByIdDirectory);
            
            //When
            var film = handler.Handle(new ListFilmsByIdMessage(1));
            
            //Then
            Assert.NotNull(film);
            
            //The issue here, like the service tests are that we are testing the fakes are called which doesn't offer much value
            
            //If there is a bit more logic in the function then a unit test can be valuable, we can see that in the Create/Update/Delete handlers that do a valid user check
            
            //You are better off having an integration test at this point possibly with an in-memory sql database or Before/After xUnit attribute to setup db state
        }
    }
}
