using Business.Interfaces;
using Business.Interfaces.Business.Interfaces;
using Entity;
using Entity.Dtos;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public abstract class ARepositoryBusiness<T, D> : IRepositoryBusiness<T, D> where T : BaseModel where D : BaseDto
    {
        /// <summary>
        /// Obtener 
        /// </summary>
        /// <returns></returns>
        public abstract Task<List<D>> GetAll();
        /// <summary>
        /// Obtener por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract Task<D> GetById(int id);
        /// <summary>
        /// Guardar
        /// </summary>
        /// <param name="entityDto"></param>
        /// <returns></returns>
        public abstract Task<D> Save(D entityDto);
        /// <summary>
        /// Actualizar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entityDto"></param>
        /// <returns></returns>
        public abstract Task Update(D entityDto);
        /// <summary>
        /// Eliminar Logico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract Task<int> Delete(int id);
        /// <summary>
        /// Eliminar Consistente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract Task<bool> PermanentDelete(int id);

    }
}