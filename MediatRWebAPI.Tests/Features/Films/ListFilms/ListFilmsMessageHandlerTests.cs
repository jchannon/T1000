namespace MediatRWebAPI.Tests.Features.Films.ListFilms
{
    using System.Linq;
    using MediatRWebAPI.Features.Films.ListFilms;
    using Xunit;

    public class ListFilmsMessageHandlerTests
    {
        //This class can be unit test and/or integration test as our handler class is responsible for doing whatever it takes
        
        [Fact]
        public void Should_return_list_of_films() 
        {
            //Given
            var handler = new ListFilmsMessageHandler();
            
            //When
            var films = handler.Handle(new ListFilmsMessage());
            
            //Then
            Assert.True(films.Any());
        }
    }
}
