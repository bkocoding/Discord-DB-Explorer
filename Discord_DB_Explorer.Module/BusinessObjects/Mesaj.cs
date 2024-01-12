using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;

namespace Discord_DB_Explorer.Module.BusinessObjects
{
    [NavigationItem("Mesajlar")]
    public class Mesaj : BaseObject
    {
        public virtual Kanal Kanal { get; set; }
        public virtual Kullanici Kullanici { get; set; }
        public virtual string Icerik { get; set; }
        public virtual DateTime DateTime { get; set; }

    }
}
