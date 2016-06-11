// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Web;
using AutoMapper;
using Core.Features.Codes;
using Core.Security;
using Data;
using MediatR;
using NPoco;
using NPoco.SqlAzure;
using StackExchange.Profiling;
using StackExchange.Profiling.Data;
using StructureMap;
using StructureMap.Pipeline;
using Web.Config;
using Web.Models;

namespace Web.DependencyResolution
{
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
	
    public class DefaultRegistry : Registry 
    {
        public DefaultRegistry() {
            Scan(
                scanner => {
                    scanner.TheCallingAssembly();
                    scanner.WithDefaultConventions();
					scanner.With(new ControllerConvention());
                    
                    scanner.Assembly("Core");
                    scanner.Assembly("Data");

                    scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<,>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncNotificationHandler<>));
                });

            For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
            For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));
            For<IMediator>().Use<Mediator>();

            For<IConnectionConfig>()
                .Use<WebConnectionConfig>()
                .Singleton();

            For<IDatabase>()
                .LifecycleIs<ThreadLocalStorageLifecycle>()
                .Use(ctx => new SqlAzureDatabase(ctx.GetInstance<IConnectionConfig>().ConnectionString));

            For<MapperConfiguration>()
                .Use(scope => new MapperConfiguration(AutoMapperConfig.RegisterMappings))
                .Singleton();

            For<AutoMapper.IMapper>().Use(scope => scope.GetInstance<MapperConfiguration>().CreateMapper());

            For<IUser>()
                .LifecycleIs<ThreadLocalStorageLifecycle>()
                .Use(ctx => new WebUser(HttpContext.Current.User.Identity as ClaimsIdentity));
        }
    }
}