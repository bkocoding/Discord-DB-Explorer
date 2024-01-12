using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System.Collections.ObjectModel;
using System.Security.Policy;

namespace Discord_DB_Explorer.Module.BusinessObjects
{
    [NavigationItem("Emojiler")]
    public class Emoji : BaseObject
    {
        public virtual string EmojiName { get; set; }
        public virtual string EmojiUrl { get; set; }
        public virtual bool isGIF { get; set; }

        public virtual IList<Kullanici> Users { get; set; } = new ObservableCollection<Kullanici>();
    }
}
