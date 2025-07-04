using S.A.M.Models.Category;
using S.A.M.Models.Language;

namespace S.A.M.Areas.ControlPanel.Models.Category;

public class AddCategoryViewModel
{
    public List<LanguageModel> Languages { get; set; }
    public List<CategoryModel> Categories { get; set; }
}
