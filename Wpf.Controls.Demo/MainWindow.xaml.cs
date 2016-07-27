using Fuss.Wpf.Controls;
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

namespace Wpf.Controls.Demo
{
    public partial class MainWindow : FussWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ModuleMenu.DataContext = new MenuVM();

            var people = new List<Person>();
            people.Add(new Person(1, "Person1", 20, Sex.Male));
            people.Add(new Person(2, "Person2", 20, Sex.FeMale));
            people.Add(new Person(3, "Person3", 20, Sex.Male));
            people.Add(new Person(4, "Person4", 20, Sex.FeMale));
            dataGrid.ItemsSource = people;
            var people2 = new List<Person>();
            people2.Add(new Person(1, "Person1", 20, Sex.Male));
            people2.Add(new Person(2, "Person2", 20, Sex.Male));
            listbox.ItemsSource = people2;
        }
    }

    public class Sex
    {
        public static Sex Male = new Sex("男");
        public static Sex FeMale = new Sex("女");
        public string SexDescription
        {
            get;
            set;
        }
        private Sex(string sexDescriptioin)
        {
            SexDescription = sexDescriptioin;
        }
    }

    public class Person
    {
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
        public Sex Gender
        {
            get;
            set;
        }
        public BindingList<Sex> Genderlist
        {
            get;
            set;
        }
        public Person()
        {
            Genderlist = new BindingList<Sex>();
            Genderlist.Add(Sex.Male);
            Genderlist.Add(Sex.FeMale);
        }
        public Person(int id, string name, int age, Sex gender)
            : this()
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
    }
}
