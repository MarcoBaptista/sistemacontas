using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SistemaContas.Data.Entities;
using SistemaContas.Data.Helpers;
using SistemaContas.Presentation.Models.Account;
using SistemaContas.Presentation.Models.Categorias;

namespace SistemaContas.Presentation.Mappings
{
    /// <summary>
    /// Classe de mapeamento do AutoMapper
    /// para transferencia de dados para Entities 
    /// Herdando a classe Profile do Automapper
    /// </summary>
    public class ModelToEntityMap : Profile
    {
        //precisa de um método contrutor com [ctor + 2x tab]

        public ModelToEntityMap()
        {
            CreateMap<RegisterViewModel, Usuario>()
                .AfterMap((model, entity) =>
                {
                    entity.IdUsuario = Guid.NewGuid();
                    entity.Senha = MD5Cryptography.Hash(model.Senha);
                    entity.DataCriacao = DateTime.Now;
                    entity.Ativo = 1;
                });


            CreateMap<CategoriaCadasroViewModel, Categoria>()
               .AfterMap((model, entity) =>
               {
                   entity.IdCategoria = Guid.NewGuid();
                   
               });

        }
    }
}
