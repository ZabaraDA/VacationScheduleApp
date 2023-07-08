using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using VacationScheduleApp.Models;
using VacationScheduleApp.Pages;

namespace VacationScheduleApp.Windows
{
    /// <summary>
    /// Главное меню
    /// </summary>
    /// <remarks>
    /// Осуществляет навигацию по модулям системы
    /// </remarks>
    public partial class MenuWindow : Window
    {
        private List<Role> _roleList = new List<Role>()
        {
            new Role(1, "Системный администратор"),
            new Role(2, "Администратор"),
            new Role(3, "Менеджер"),
            new Role(4, "Инженер"),
            new Role(5, "Кладовщик"),
            new Role(6, "Диспетчер"),
            new Role(7, "Разработчик"),
            new Role(8, "Технолог"),
            new Role(9, "Конструктор"),
            new Role(10, "Бухгалтер")
        };
        List<User> _userList;

        public MenuWindow()
        {
            InitializeComponent();
            _userList = GenerateUser();
            MenuFrame.Navigate(new UserPage(_userList));
        }

        private List<User> GenerateUser()
        {
            int id = 100000;

            string[] maleForenames = { "Артём", "Никита", "Фёдор", "Богдан", "Тимофей" };
            string[] femaleForenames = { "Ярослава", "Дарья", "Арина", "Елизавета", "Анна" };

            string[] surnames = { "Петров", "Сидоров", "Иванов", "Никитин", "Фёдоров" };
            string[] patronymic = { "Алексеев", "Тимофеев", "Матвеев", "Константинов", "Робертов" };

            List<User> userList = new List<User>();
            Random random = new Random();

            bool gender = true;

            for (int i = 0; i < 1000; i++)
            {
                User currentUser = new User();

                currentUser.Id = ++id;

                if (gender)
                {
                    currentUser.Forename = femaleForenames[random.Next(femaleForenames.Length - 1)];
                    currentUser.Surname = surnames[random.Next(femaleForenames.Length - 1)] + "а";
                    currentUser.Patronymic = patronymic[random.Next(femaleForenames.Length - 1)] + "на";
                }
                else
                {
                    currentUser.Forename = maleForenames[random.Next(maleForenames.Length - 1)];
                    currentUser.Surname = surnames[random.Next(femaleForenames.Length - 1)];
                    currentUser.Patronymic = patronymic[random.Next(femaleForenames.Length - 1)] + "ич";
                }

                currentUser.Role = _roleList[random.Next(_roleList.Count - 1)];

                currentUser.DateOfBirth = new DateTime(random.Next(DateTime.Now.Year - 59, DateTime.Now.Year - 18), random.Next(1, 12), random.Next(1, 28));

                currentUser.Gender = gender;
                gender = !gender;

                currentUser.Vacation = GenerateVacation();

                userList.Add(currentUser);

            }


            return userList;
        }

        private List<Vacation> GenerateVacation()
        {
            List<Vacation> vacationList = new List<Vacation>();



            return vacationList;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new UserPage(_userList));
        }

        private void VacationButton_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new VacationPage());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void HiddenButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void StateButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                StateButton.ToolTip = "Оконный режим";
                WindowState = WindowState.Maximized;
            }
            else
            {
                StateButton.ToolTip = "Полноэкранный режим";
                WindowState = WindowState.Normal;
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow window = new OpenWindow();
            window.Show();
            Close();
        }

        private void RoleButton_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new RolePage());
        }
    }
}
