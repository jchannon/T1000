namespace MediatRWebAPI.Features.Permissions
{
    using System;

    public class ValidUserQuery : IValidUserQuery
    {
        public bool Execute()
        {
            return new Random().Next() % 2 == 0;
        }
    }
}
