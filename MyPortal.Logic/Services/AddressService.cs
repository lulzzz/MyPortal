﻿using System;
using System.Collections.Generic;
using System.Text;
using MyPortal.Logic.Interfaces;
using MyPortal.Logic.Interfaces.Services;

namespace MyPortal.Logic.Services
{
    public class AddressService : BaseService, IAddressService
    {
        public AddressService()
        {
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
