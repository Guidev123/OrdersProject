﻿namespace ProjectE.UserAPI.Endpoints
{
    public interface IEndpoint
    {
        static abstract void Map(IEndpointRouteBuilder app);
    }
}
