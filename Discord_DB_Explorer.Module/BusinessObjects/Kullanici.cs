using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Discord_DB_Explorer.Module.BusinessObjects
{
    [NavigationItem("Kullanıcılar")]
    public class Kullanici : BaseObject
    {
        
        public virtual string UserName { get; set; }

        [EmailAddress]
        public virtual string Email { get; set; }

        public virtual DateTime CreatedAt { get; set; }

        public virtual string Bio { get; set; }
        
        public virtual string AvatarUrl { get; set; }

        public virtual IList<Emoji> FavoruiteEmojis { get; set; } = new ObservableCollection<Emoji>();


    }
}
