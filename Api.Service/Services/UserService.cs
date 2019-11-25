using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    //Aqui devo colocar regra de negócio
    public class UserService : IUserService
    {
        //Variável que irá receber o objeto pelo construtor
        private IRepository<UserEntity> _repository;    

        //Aqui acontece a injeção de dependência
        public UserService(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(Guid Id)
        {
            return await _repository.DeleteAsync(Id);
        }

        public async Task<UserEntity> Get(Guid Id)
        {
            return await _repository.SelectAsync(Id);
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<UserEntity> Post(UserEntity user)
        {
            return await _repository.InsertAsync(user);
        }

        public async Task<UserEntity> Put(UserEntity user)
        {
            return await _repository.UpdateAsync(user);
        }
    }
}
