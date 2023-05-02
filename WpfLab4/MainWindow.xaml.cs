using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfLab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Department> Departments { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Departments = new ObservableCollection<Department>()
            {
                new Department()
                {
                    Name = "Бухгалтерия",
                    Employees = new ObservableCollection<Employee>()
                    {
                        new Employee()
                        {
                            Name = "Иван Иванович",
                            Surname = "Иванов",
                            Age = 31
                        },
                        new Employee()
                        {
                            Name = "Антон Антонович",
                            Surname = "Антонов",
                            Age = 32
                        },
                        new Employee()
                        {
                            Name = "Елизавета Сергеевна",
                            Surname = "Филина",
                            Age = 33
                        }
                    }
                },
                new Department()
                {
                    Name = "It-отдел",
                    Employees = new ObservableCollection<Employee>()
                    {
                        new Employee()
                        {
                            Name = "Робин Анатольевич",
                            Surname = "Вундервафлин",
                            Age = 21
                        },
                        new Employee()
                        {
                            Name = "Максим Юрьевич",
                            Surname = "Шлакоблокунь",
                            Age = 22
                        },
                        new Employee()
                        {
                            Name = "Герман Петрович",
                            Surname = "Винный",
                            Age = 23
                        }
                    }
                },
                new Department()
                {
                    Name = "Отдел логистики",
                    Employees = new ObservableCollection<Employee>()
                    {
                        new Employee()
                        {
                            Name = "Михаил Александрович",
                            Surname = "Посылкин",
                            Age = 41
                        },
                        new Employee()
                        {
                            Name = "Даниил Вольфович",
                            Surname = "Лампочкин",
                            Age = 42                        },
                        new Employee()
                        {
                            Name = "Юрий Алексеевич",
                            Surname = "Быстров",
                            Age = 43
                        }
                    }
                }
            };
            lbDepartments.ItemsSource = Departments;
        }

    }

}
