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
            new Role(10, "Разнорабочий")
        };

        

        public MenuWindow()
        {
            InitializeComponent();
            MenuFrame.Navigate(new UserPage());
        }

        private List<User> GenerateUser()
        {
            string[] maleForenames = {"Артём", "Никита", "Фёдор", "Богдан", "Тимофей"};
            string[] femaleForenames = { "Ярослава", "Дарья", "Арина", "Елизавета", "Анна"};

            string[] maleSurnames = { "Ярослава", "Дарья", "Артём", "Никита", "Арина", "Фёдор", "Елизавета", "Богдан", "Тимофей", "Анна" };

            List<User> userList = new List<User>();


            return userList;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(new UserPage());
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
