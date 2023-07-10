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
using System.Windows.Navigation;
using System.Windows.Shapes;
using VacationScheduleApp.Models;

namespace VacationScheduleApp.Pages
{
    public partial class UserPage : Page
    {
        private List<Vacation> _vacationList;
        public UserPage(List<User> userList, List<Vacation> vacationList)
        {
            InitializeComponent();
            _vacationList = vacationList;
            UserDataGrid.ItemsSource = userList;
        }

        private void AddVacationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            User user = (User)button.DataContext;
            NavigationService.Navigate(new AddVacationPage(user, _vacationList));
        }
    }
}
