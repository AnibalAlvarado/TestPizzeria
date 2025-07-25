﻿using AutoMapper;
using Data.Interfaces;
using Entity;
using Entity.Contexts;
using Entity.Dtos;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Data.Implementations
{
    public class RepositoryData<T> : ARepositoryData<T> where T : BaseModel
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IConfiguration _configuration;

        public RepositoryData(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        

        public override async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                var lstModel = await _context.Set<T>()
                    .Where(x => x.IsDeleted == false) //  Solo activos
                    .ToListAsync();

                return lstModel;
            }
            catch (DbException ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
                throw;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Database update (EF) failed: " + ex.InnerException?.Message);
                throw;
            }
        }


        public override async Task<T> GetById(int id)
        {

            try
            {
                var entity = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);

                // Auditar acción GetById, enviamos la entidad si la encontró
                //await AuditAsync("GetById", id);

                return entity;
            }
            catch (DbException ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
                throw;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Database update (EF) failed: " + ex.InnerException?.Message);
                throw;
            }


        }

        public override async Task<T> Save(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
                //await AuditAsync("Save", entity.Id);
                return entity;
            }
            catch (DbException ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
                throw;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Database update (EF) failed: " + ex.InnerException?.Message);
                throw;
            }


        }

        public override async Task Update(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                //await AuditAsync("Update", entity.Id);
                _context.Entry(entity).State = EntityState.Detached;
            }
            catch (DbException ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
                throw;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Database update (EF) failed: " + ex.InnerException?.Message);
                throw;
            }


        }

        public override async Task<bool> PermanentDelete(int id)
        {
            if (id <= 0)
                throw new DataException("El ID proporcionado no es válido. Debe ser mayor a cero.");

            var entity = await _context.Set<T>().FirstOrDefaultAsync(d => d.Id == id);

            if (entity == null)
                throw new DataException($"No se encontró un registro con el ID {id}.");

            try
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
                //await AuditAsync("Delete", id);
                return true;
            }
            catch (DbUpdateException ex)
            {
                throw new DataException("Ocurrió un error al intentar eliminar el registro.", ex);
            }
            catch (Exception ex)
            {
                throw new DataException("Error inesperado durante la eliminación.", ex);
            }
        }

        public override async Task<int> Delete(int id)
        {
            try
            {
                var entity = await _context.Set<T>().FirstOrDefaultAsync(d => d.Id == id);
                if (entity == null)
                    throw new DataException($"No se encontró un registro con el ID {id}.");

                // Marcar como inactivo (soft delete)
                entity.IsDeleted = true;

                _context.Entry(entity).State = EntityState.Modified;
                int result = await _context.SaveChangesAsync();

                //await AuditAsync("Logical Delete", id);

                return result;
            }
            catch (DbException ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
                throw;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Database update (EF) failed: " + ex.InnerException?.Message);
                throw;
            }
        }
    }
}