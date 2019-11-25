using Api.Data.Context;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;
        private DbSet<T> _dataset;
        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = context.Set<T>(); // Atalaho para não precisar ficar escrevendo context. sempre
        }
        public async Task<bool> DeleteAsync(Guid Id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(Id));

                if (result == null)
                    return false;

                _context.Remove(result);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> InsertAsync(T Item)
        {
            //Todos os métodos devem ter comando try 
            try
            {
                if(Item.Id == Guid.Empty)
                {
                    Item.Id = Guid.NewGuid();
                }
                Item.CreateAt = DateTime.UtcNow;

                //Pfreecher o dataset
                _dataset.Add(Item);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex )
            {

                throw ex;
            }

            return Item;
        }

        public async Task<T> SelectAsync(Guid Id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(Id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> UpdateAsync(T Item)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(Item.Id));

                if(result == null)                
                    return null;

                Item.UpdateAt = DateTime.UtcNow;
                Item.CreateAt = result.CreateAt; //Passo a data novamente para garantir que não foi alterada

                //Atualizar no banco 
                _context.Entry(result).CurrentValues.SetValues(Item);
                await _context.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Item;
        }

        public async Task<bool> ExistAsync(Guid Id)
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(Id));
        }
    }
}
