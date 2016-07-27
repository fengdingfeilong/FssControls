using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Controls.Demo
{
    public class ModuleInfo
    {
        public ModuleInfo()
        {
        }

        public string MenuName
        {
            get;
            set;
        }

        public string AssemblyFile
        {
            get;
            set;
        }

        public string ClassName
        {
            get;
            set;
        }

        public string StartMethod
        {
            get;
            set;
        }

        private List<ModuleInfo> _moduleChildren;
        public List<ModuleInfo> ModuleChildren
        {
            get
            {
                return _moduleChildren ?? (_moduleChildren = new List<ModuleInfo>());
            }
            set
            {
                _moduleChildren = value;
            }
        }

        private DelegateCommand _loadModuleCommand;
        public DelegateCommand LoadModuleCommand
        {
            get { return _loadModuleCommand ?? (_loadModuleCommand = new DelegateCommand(LoadModule, CanLoadModule)); }
        }

        private void LoadModule(Object parameter)
        {
            if (string.IsNullOrEmpty(AssemblyFile) && string.IsNullOrEmpty(ClassName)) return;
            try
            {
                var assembly = Assembly.Load(AssemblyFile);
                var moduleClass = assembly.CreateInstance(ClassName);
                moduleClass.GetType().InvokeMember(StartMethod, BindingFlags.Default | BindingFlags.InvokeMethod, null, moduleClass, null);
            }
            catch
            {
                throw new Exception("调用组件失败，请检查配置文件中程序集名称及类型、方法是否匹配");
            }
        }

        private bool CanLoadModule(Object parameter)
        {
            return true;
        }

    }
}
