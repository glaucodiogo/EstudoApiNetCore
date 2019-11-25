using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.CrossCuting.DependencyInjection
{
    public class ConfigureService
    {
        public static  void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            //Irá ser criado a instancia da classe, toda vez que houver uma chamada da interface IUserService, após o uso descarta
            serviceCollection.AddTransient<IUserService, UserService>();
        }
    }
}
