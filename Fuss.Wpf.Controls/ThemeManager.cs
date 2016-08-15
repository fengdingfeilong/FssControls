using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fuss.Wpf.Controls
{
    public enum FussTheme
    {
        Blue
    }

    public class ThemeManager
    {
        public static void Load(FussTheme theme)
        {
            ResourceDictionary resource = new ResourceDictionary();
            resource.Source = new Uri("Fuss.Wpf.Controls;component/Themes/Generic.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Insert(0, resource);
        }
    }
}
