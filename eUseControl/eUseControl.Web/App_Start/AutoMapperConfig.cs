using AutoMapper;
using eUseControl.Domain.Entities.User;

public static class AutoMapperConfig
{
     public static void Initialize()
     {
          Mapper.Initialize(cfg =>
          {
               cfg.CreateMap<UDbTable, UserMinimal>();
          });
     }
}