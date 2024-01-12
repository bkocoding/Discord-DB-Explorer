using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;

namespace Discord_DB_Explorer.Module.BusinessObjects
{
    [NavigationItem("SunucuUyeleri")]
    public class SunucuUye : BaseObject
    {
        public virtual Sunucu Sunucu { get; set; }
        public virtual Kullanici Kullanici { get; set; }
        public virtual DateTime JoinedAt { get; set; }
        public virtual Rol Rol { get; set; }

    }
}
