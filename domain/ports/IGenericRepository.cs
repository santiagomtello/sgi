using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiAppHexagonal.Domain.Ports
{
    public interface IGenericRepository<T>
    {
        List<T> ObtenerTodos();
        void Crear(T entity);
        void Actualizar(T entity);
        void Eliminar(int id);
    }
}