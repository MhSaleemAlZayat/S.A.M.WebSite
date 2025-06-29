using AutoMapper;

namespace S.A.M.Helper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<S.A.M.Models.Language.LanguageModel, S.A.M.Data.Entities.Language>();
        CreateMap<S.A.M.Data.Entities.Language, S.A.M.Models.Language.LanguageModel>();
    }
}
