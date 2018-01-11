namespace MediatRWebAPI.Tests.Features.Films.UpdateFilm
{
    using System;
    using FakeItEasy;
    using MediatRWebAPI.Features.Films.ListFilmByIdQuery;
    using MediatRWebAPI.Features.Films.UpdateFilm;
    using MediatRWebAPI.Features.Permissions;
    using Models;
    using Xunit;

    public class UpdateFilmMessageHandlerTests
    {
        //This class can be unit test and/or integration test as our handler class is responsible for doing whatever it takes

        [Fact]
        public void Should_throw_exception_if_user_invalid()
        {
            //Given
            var fakeValidUserQuery = A.Fake<IValidUserQuery>();
            A.CallTo(() => fakeValidUserQuery.Execute()).Returns(false);
            var fakeListFilmByIdQuery = A.Fake<IListFilmByIdQuery>();

            var handler = new UpdateFilmMessageHandler(fakeListFilmByIdQuery, fakeValidUserQuery);

            //When & Then
            Assert.Throws<InvalidOperationException>(() => handler.Handle(new UpdateFilmMessage(1, new Film())));
        }

        //Could write an integration test to see if the database has a new film in it or use the API tests to POST then GET the film it created 
    }
}
