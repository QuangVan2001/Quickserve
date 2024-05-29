using System.ComponentModel;

namespace QuickServe.Utils.Enums
{
    public enum AccountRole
    {
        [Description("Admin")]
        Admin,
        [Description("Customer")]
        Customer,
        [Description("Staff")]
        Staff,
        [Description("Store Manager")]
        Store_Manager,
        [Description("Brand Manager")]
        Brand_Manager
    }
}
