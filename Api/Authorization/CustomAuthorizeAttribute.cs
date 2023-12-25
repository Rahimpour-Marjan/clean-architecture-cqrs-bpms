using Api.Enum;

namespace Api.Authorization
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class CustomAuthorizeAttribute : Attribute
    {
        public IList<SiteAction> _requiredActions { get; }

        public CustomAuthorizeAttribute(params SiteAction[] actions)
        {
            _requiredActions = actions ?? new SiteAction[] { };
        }
    }
}
