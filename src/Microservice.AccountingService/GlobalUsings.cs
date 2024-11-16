﻿global using Microservice.Infrastructure.Databases;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using System.Text;
global using Microservice.AccountingService.Infrastructure.Extensions;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using Microservice.AccountingService.Controllers.Base;
global using Microservice.Application.Common.DTOs.Role;
global using Microservice.Application.Common.Responses;
global using Microservice.Application.Features.UserFeatures.Commands;
global using Microservice.Application.Features.UserFeatures.Queries;
global using Microservice.Application.Common;
global using Microservice.Application.Common.Behaviors;
global using Microservice.Application.Common.Interfaces;
global using Microservice.Infrastructure;
global using Microservice.Infrastructure.Repositories;
global using Microsoft.AspNetCore.Mvc.Versioning;