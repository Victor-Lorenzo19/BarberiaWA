using BarberiaWA.BD.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarberiaWA.Repositorio.Repositorios
{
    public class Repositorio<E> : IRepositorio<E> where E :  EntityBase
    {
        private readonly AppDbcontext _context;

        public Repositorio(AppDbcontext context)
        {
            _context = context;
        }

        // existe
        public async Task<bool> Existe(E entidad)
        {
            try
            {
                return await _context.Set<E>()
                    .AnyAsync(e => e.Id == entidad.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // select
        public async Task<List<E>> Select()
        {
            return await _context.Set<E>().ToListAsync();
        }

        // select by id
        public async Task<E?> SelectById(int id)
        {
            return await _context.Set<E>().FindAsync(id);
        }

        // insert
        public async Task<E> Insert(E entidad)
        {
            try
            {
                await _context.Set<E>().AddAsync(entidad);

                await _context.SaveChangesAsync();

                return entidad;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // update
        public async Task<bool> Update(E entidad)
        {
            try
            {
                var existente = await _context.Set<E>()
                    .FindAsync(entidad.Id);

                if (existente == null)
                {
                    return false;
                }
                else
                {
                    _context.Entry(existente).CurrentValues.SetValues(entidad);

                    await _context.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // delete
        public async Task<bool> Delete(int id)
        {
            var entidad = await _context.Set<E>().FindAsync(id);

            if (entidad == null)
            {
                return false;
            }

            _context.Set<E>().Remove(entidad);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}