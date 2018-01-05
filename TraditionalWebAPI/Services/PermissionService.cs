namespace TraditionalWebAPI.Services
{
    using System;

    public class PermissionService : IPermissionService
    {
        
        public bool ValidUser()
        {
            return new Random().Next() % 2 == 0;
        }
    }
}