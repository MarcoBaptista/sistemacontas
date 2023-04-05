using AutoMapper;
using SistemaContas.Data.Entities;
using SistemaContas.Presentation.Models.Authentication;

namespace SistemaContas.Presentation.Mappings
{
    /// <summary>
    /// Classe de mapeamento do AutMapper para
    /// trasnferencia de dados de uma Entity apra Models
    /// </summary>

    public class EntityToModelMap : Profile 
    {
        public EntityToModelMap()
        {
            CreateMap<Usuario, AuthenticationModel>()
                .AfterMap((entity, model) =>
                {
                    model.DataHoraAcesso = DateTime.Now;    
                });
        }
    }
}
