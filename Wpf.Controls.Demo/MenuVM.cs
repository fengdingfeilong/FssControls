using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Controls.Demo
{
    public class MenuVM
    {
        private List<ModuleInfo> _modules;
        public List<ModuleInfo> Modules
        {
            get { return _modules; }
            set { _modules = value; }
        }
        
        public MenuVM()
        {
            Modules = ModuleHelper.GetModuleInfo();
        }

    }
}
