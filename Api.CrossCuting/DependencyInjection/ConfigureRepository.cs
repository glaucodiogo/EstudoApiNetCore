using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.CrossCuting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static  void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            //Irá ser criado a instancia da classe, toda vez que houver uma chamada da interface IUserService, após o uso descarta
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            //Injetar contexto da conexao
            serviceCollection.AddDbContext<MyContext>(option => option.UseMySql("Server = localhost; Port = 3306; Database = estudo; Uid = root; Pwd = 1234;"));
                
            
        }
    }
}
