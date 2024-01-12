using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.XtraPrinting.Native;
using System.Collections.ObjectModel;

namespace Discord_DB_Explorer.Module.BusinessObjects
{
    [NavigationItem("Kanallar")]
    public class Kanal : BaseObject
    {
        public virtual Sunucu Sunucu { get; set; }
        public virtual string KanalAdi { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual IList<Mesaj> Mesajlar { get; set; } = new ObservableCollection<Mesaj>();


    }
}
