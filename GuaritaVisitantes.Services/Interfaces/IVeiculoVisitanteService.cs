using GuaritaVisitantes.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuaritaVisitantes.Services.Interfaces
{
    public interface IVeiculoVisitanteService : IService<VeiculoVisitanteDTO>
    {
        object[] GetVeiculosArray();

        VeiculoVisitanteDTO FindByPlaca(string placa);
    }
}
