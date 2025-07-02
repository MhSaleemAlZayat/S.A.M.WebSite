using S.A.M.Models.Category;

namespace S.A.M.Areas.ControlPanel.Models.Category;

public class CategoryIndexViewModel
{
    public byte DefaultLanguageId { get; set; }
    public List<CategoryModel> Categories { get; set; }

}

