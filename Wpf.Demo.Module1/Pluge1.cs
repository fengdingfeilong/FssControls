using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf.Demo.Module1
{
    public class Pluge1
    {
        public void SayHello()
        {
            MessageBox.Show("Hello","这是个插件");
        }

        public void SayHaha()
        {
            MessageBox.Show("哈哈", "这是个插件");
        }
    }
}
