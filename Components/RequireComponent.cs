using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSTEST.Components
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class RequireComponentAttribute : Attribute
    {
        public RequireComponentAttribute(Component c)
        {
            _Component = c;
        }
        public Component _Component { get; }
    }
}
