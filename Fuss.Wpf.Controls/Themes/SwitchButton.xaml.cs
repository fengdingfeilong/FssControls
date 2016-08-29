using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fuss.Wpf.Controls
{
    public partial class SwitchButton : UserControl
    {
        public SwitchButton()
        {
            InitializeComponent();
        }

        public bool IsOff
        {
            get { return (bool)GetValue(IsOffProperty); }
            set { SetValue(IsOffProperty, value); }
        }
        public static readonly DependencyProperty IsOffProperty =
            DependencyProperty.Register("IsOff", typeof(bool), typeof(SwitchButton), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(IsOffPropertyChangedCallback)));

        public event EventHandler<bool> IsOffChanged;

        private static void IsOffPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var switchbutton = (SwitchButton)d;
            if (switchbutton.IsOff)
                Grid.SetColumn(switchbutton.Border_Selected, 0);
            else
                Grid.SetColumn(switchbutton.Border_Selected, 1);
            if (switchbutton.IsOffChanged != null)
                switchbutton.IsOffChanged(null, switchbutton.IsOff);
        }

        public FrameworkElement LeftSide
        {
            get { return (FrameworkElement)GetValue(LeftSideProperty); }
            set { SetValue(LeftSideProperty, value); }
        }
        public static readonly DependencyProperty LeftSideProperty =
            DependencyProperty.Register("LeftSide", typeof(FrameworkElement), typeof(SwitchButton), new FrameworkPropertyMetadata(null, LeftSidePropertyChangedCallback));
        private static void LeftSidePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var switchbutton = (SwitchButton)d;
            switchbutton.Border_Left.Child = switchbutton.LeftSide;
        }

        public FrameworkElement RightSide
        {
            get { return (FrameworkElement)GetValue(RightSideProperty); }
            set { SetValue(RightSideProperty, value); }
        }
        public static readonly DependencyProperty RightSideProperty =
            DependencyProperty.Register("RightSide", typeof(FrameworkElement), typeof(SwitchButton), new FrameworkPropertyMetadata(null, RightSidePropertyChangedCallback));
        private static void RightSidePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var switchbutton = (SwitchButton)d;
            switchbutton.Border_Right.Child = switchbutton.RightSide;
        }
        private void Border_Left_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsOff)
                IsOff = true;
        }

        private void Border_Right_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (IsOff) IsOff = false;
        }
    }
}
