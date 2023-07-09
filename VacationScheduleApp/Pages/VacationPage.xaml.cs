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
using VacationScheduleApp.Models;

namespace VacationScheduleApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для VacationPage.xaml
    /// </summary>
    public partial class VacationPage : Page
    {
        private ObservableCollection<Vacation> _filterVacationList;
        private List<Vacation> _vacationList;
        public VacationPage(List<Vacation> vacationList)
        {
            InitializeComponent();
            _vacationList = vacationList;
            _filterVacationList = new ObservableCollection<Vacation>(_vacationList);
            VacationDataGrid.ItemsSource = vacationList;
            
        }

        private void FilterVacationList()
        {
            _filterVacationList = new ObservableCollection<Vacation>(_vacationList);
            
        }

        private void FilterVacationButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddVacationButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void IntersectionVacationButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
