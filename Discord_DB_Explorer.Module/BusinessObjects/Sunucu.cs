using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System.Collections.ObjectModel;

namespace Discord_DB_Explorer.Module.BusinessObjects
{
    [NavigationItem("Sunucular")]
    public class Sunucu : BaseObject
    {
        public virtual string ServerName { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual IList<Kanal> Kanallar { get; set; } = new ObservableCollection<Kanal>();
        public virtual IList<SunucuUye> SunucuUyeleri { get; set; } = new ObservableCollection<SunucuUye>();
        public virtual IList<Emoji> Emoji { get; set; } = new ObservableCollection<Emoji>();
                    
    }
}
