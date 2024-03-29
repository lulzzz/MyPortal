﻿﻿using System;
using AutoMapper;
 using MyPortal.Logic.Exceptions;
 using MyPortal.Logic.Helpers;
using MyPortal.Logic.Interfaces;
 using MyPortal.Logic.Interfaces.Services;

 namespace MyPortal.Logic.Services
{
    public abstract class BaseService : IService
    {
        protected readonly IMapper BusinessMapper;
        protected Guid UserId;

        public BaseService()
        {
            BusinessMapper = MappingHelper.GetConfig();
        }

        public abstract void Dispose();

        protected Exception GetInnerException(Exception ex)
        {
            var exceptionMessage = ExceptionHelper.GetRootExceptionMessage(ex);

            var exception = new Exception(exceptionMessage ?? "An error occurred.");

            return exception;
        }
    }
}
