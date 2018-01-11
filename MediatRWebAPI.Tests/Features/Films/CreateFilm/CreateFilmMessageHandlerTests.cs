namespace MediatRWebAPI.Tests.Features.Films.CreateFilm
{
    using System;
    using FakeItEasy;
    using MediatRWebAPI.Features.Films.CreateFilm;
    using MediatRWebAPI.Features.Permissions;
    using Models;
    using Xunit;

    public class CreateFilmMessageHandlerTests
    {
        //This class can be unit test and/or integration test as our handler class is responsible for doing whatever it takes

        [Fact]
        public void Should_throw_exception_if_user_invalid()
        {
            //Given
            var fakeValidUserQuery = A.Fake<IValidUserQuery>();
            A.CallTo(() => fakeValidUserQuery.Execute()).Returns(false);
            var handler = new CreateFilmMessageHandler(fakeValidUserQuery);

            //When & Then
            Assert.Throws<InvalidOperationException>(() => handler.Handle(new CreateFilmMessage(new Film())));
        }
        
        //Could write an integration test to see if the database has a new film in it or use the API tests to POST then GET the film it created 
    }
}
