using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    public partial class AddVacationPage : Page
    {
        private Vacation _currentVacation;
        private List<Vacation> _vacationList;
        public AddVacationPage(User selectedUser, List<Vacation> vacationList)
        {
            InitializeComponent();

            _vacationList = vacationList;

            _currentVacation = new Vacation(selectedUser);
            _currentVacation.Id = _vacationList.Count + 1;
            _currentVacation.StartDate = DateTime.Now;
            QuantityTextBox.Text = "7";
            DataContext = _currentVacation;
        }
        private void EndDateVacationUpdate()
        {
            if (QuantityTextBox.Text == null || QuantityTextBox.Text == "" || Convert.ToInt32(QuantityTextBox.Text) < 1)
            {
                QuantityTextBox.Text = "1";
            }

            if (StartDateDatePicker.SelectedDate != null)
            {
                EndDateDatePicker.SelectedDate = StartDateDatePicker.SelectedDate.Value.AddDays(Convert.ToInt32(QuantityTextBox.Text));
            }
            else
            {
                StartDateDatePicker.SelectedDate = DateTime.Now;
                EndDateDatePicker.Text = "не определено";
            }
        }
        private void QuantityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EndDateVacationUpdate();
        }
        private void StartDateDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            EndDateVacationUpdate();
        }
        private void QuantityTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9
                || e.Key == Key.Back || e.Key == Key.Right || e.Key == Key.Left)
            {
                e.Handled = false;
            }
            else if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.Key == Key.V)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void AddVacatoinButton_Click(object sender, RoutedEventArgs e)
        {
            _vacationList.Add(_currentVacation);
            MessageBox.Show("Отпуск успешно добавлен");
            NavigationService.GoBack();
        }
    }
}
