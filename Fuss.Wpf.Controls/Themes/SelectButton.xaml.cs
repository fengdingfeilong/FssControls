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
    public partial class SelectButton : UserControl
    {
        public SelectButton()
        {
            InitializeComponent();
            this.Loaded += SelectButton_Loaded;
        }

        public Object SelectedItem
        {
            get
            {
                return (Object)GetValue(SelectedItemProperty);
            }
            set
            {
                SetValue(SelectedItemProperty, value);
                if (value != null)
                {
                    var pro = value.GetType().GetProperty(DisplayProperty);
                    if (pro != null && pro.GetValue(value) != null)
                        selector_TextBox.Text = pro.GetValue(value).ToString();
                    else
                        selector_TextBox.Text = "";
                }
            }
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(Object), typeof(SelectButton),
            new FrameworkPropertyMetadata(String.Empty, new PropertyChangedCallback(OnSelectedItemChanged))
            {
                BindsTwoWayByDefault = true
            });

        private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selectButton = d as SelectButton;
            selectButton.SelectedItem = e.NewValue;
        }

        public String DisplayProperty
        {
            get
            {
                return (String)GetValue(DisplayPropertyProperty);
            }
            set
            {
                SetValue(DisplayPropertyProperty, value);
            }
        }
        public static readonly DependencyProperty DisplayPropertyProperty =
            DependencyProperty.Register("DisplayProperty", typeof(String), typeof(SelectButton), new PropertyMetadata(""));

        public event EventHandler Click;

        void SelectButton_Loaded(object sender, RoutedEventArgs e)
        {
            selector_Button.Click += selector_Button_Click;
        }

        void selector_Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.Click != null)
                Click(this, EventArgs.Empty);
        }

    }
}
