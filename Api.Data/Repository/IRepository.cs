using Api.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Repository
{
    /// <summary>
    /// Classe genérica que pode receber uma entidade que seja apenas da BaseEntity possibilitar o uso dos métodos padrão
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T Item);
        Task<T> UpdateAsync(T Item);
        Task<bool> DeleteAsync(Guid Id);
        Task<T> SelectAsync(Guid Id);
        Task<IEnumerable<T>> SelectAsync();
        Task<bool> ExistAsync(Guid Id);
    }
}