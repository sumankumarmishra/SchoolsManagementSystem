﻿namespace SMS.Infrastructure.Mapping;

public partial class UserClassProfile
{
    public void GetUserClassByIdMapping()
    {
        CreateMap<UserClass, GetUserClassDto>();
    }
}
