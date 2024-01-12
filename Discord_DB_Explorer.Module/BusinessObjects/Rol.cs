using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;

namespace Discord_DB_Explorer.Module.BusinessObjects
{
    [NavigationItem("Roller")]
    public class Rol : BaseObject
    {
        public virtual string RoleName { get; set;}
        public virtual string Permissions { get; set;}
    }
}
