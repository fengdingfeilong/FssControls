using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Fuss.Wpf.Controls
{
    public partial class FadeInOutWindow : Window
    {
        private Storyboard fadein, fadeout;
        private DispatcherTimer timer;

        public FadeInOutWindow(Window owner, string message, double width = 240, double height = 160)
        {
            InitializeComponent();

            this.Owner = owner;
            this.Width = width;
            this.Height = height;
            Text_Message.Text = message;
            this.Loaded += PopupWindow_Loaded;
            Border_Win.MouseDown += Border_Win_MouseDown;
            Border_Win.MouseEnter += Border_Win_MouseEnter;
        }

        private void Border_Win_MouseEnter(object sender, MouseEventArgs e)
        {
            Border_Win.Opacity = 1;
            fadeout.Stop();
            timer.Start();
        }

        private void Border_Win_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void PopupWindow_Loaded(object sender, RoutedEventArgs e)
        {
            fadein = Border_Win.Resources["Storyboard_FadeIn"] as Storyboard;
            fadeout = Border_Win.Resources["Storyboard_FadeOut"] as Storyboard;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += Timer_Tick;

            fadein.Completed += (s0, e0) =>
            {
                timer.Start();
            };
            fadein.Begin();
            fadeout.Completed += (s1, e1) =>
            {
                this.Close();
            };
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.IsMouseOver) return;
            fadeout.Begin();
        }
    }
}
