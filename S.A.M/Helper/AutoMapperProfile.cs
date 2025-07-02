using AutoMapper;
using S.A.M.Models.Category;

namespace S.A.M.Helper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<S.A.M.Models.Language.LanguageModel, S.A.M.Data.Entities.Language>();
        CreateMap<S.A.M.Data.Entities.Language, S.A.M.Models.Language.LanguageModel>();


        CreateMap<S.A.M.Models.Common.TranslationModel, S.A.M.Data.Entities.CategoryTranslation>()
            .ForMember(x => x.CategoryId, opt => opt.MapFrom(source => source.MasterId));
        CreateMap<S.A.M.Data.Entities.CategoryTranslation, S.A.M.Models.Common.TranslationModel>()
            .ForMember(x => x.MasterId, opt => opt.MapFrom(source => source.CategoryId));

        CreateMap<CategoryModel, S.A.M.Data.Entities.Category>()
            .ForMember(x => x.Translations, opt => opt.MapFrom(source => source.Translations))
            .ForMember(x => x.Parent, opt => opt.MapFrom(source => source.ParentCategory));
        CreateMap<S.A.M.Data.Entities.Category, CategoryModel>()
            .ForMember(x => x.Translations, opt => opt.MapFrom(source => source.Translations))
            .ForMember(x => x.ParentCategory, opt => opt.MapFrom(source => source.Parent));


    }
}
