﻿using System;
using System.Collections.Generic;
using System.Text;
using YunStorm.MoCRM.BuildingBlocks.Application.Interfaces;

namespace YunStorm.MoCRM.ContractOrdering.Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public string UserId => "0";
    }
}
