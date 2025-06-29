using System.ComponentModel;

namespace S.A.M.Data.Entities;

public class ArticleStatus
{
    public enum ArticleStatusEnum : byte
    {
        [Description("مسودة: غير جاهز للنشر.")]
        Draft = 1,
        [Description("بانتظار المراجعة: في انتظار المراجعة قبل النشر.")]
        Pending = 2,
        [Description("منشور: تم نشره ويمكن الوصول إليه من قبل الجميع.")]
        Published = 3,
        [Description("خاص: مرئية فقط لمسؤولي الموقع والمحررين.")]
        Private,
        [Description("مجدول: مخطط للنشر في وقت لاحق.")]
        Scheduled = 5,
    }

    public ArticleStatusEnum Id { get; set; }
    public ArticleStatusEnum Name { get; set; }
    public string? Description { get; set; }
    public ICollection<ArticleStatusTransaction> ArticleStatusTransactions { get; set; }
}
