using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    public partial class VacationPage : Page
    {
        private List<Vacation> _filterVacationList;
        private List<Vacation> _vacationList;
        public VacationPage(List<Vacation> vacationList, List<Role> roleList)
        {
            InitializeComponent();

            var itemsRoleList = roleList;
            itemsRoleList.Insert(0, new Role(0, "Все должности"));
            RoleComboBox.ItemsSource = itemsRoleList.ToList();
            RoleComboBox.DisplayMemberPath = "Name";

            _vacationList = vacationList;

            RoleComboBox.SelectionChanged += ComboBox_SelectionChanged;
            GenderComboBox.SelectionChanged += ComboBox_SelectionChanged;
            AgeComboBox.SelectionChanged += ComboBox_SelectionChanged;
            IntersectionComboBox.SelectionChanged += ComboBox_SelectionChanged;

        }

        private void FilterVacationList()
        {
            _filterVacationList = new List<Vacation>(_vacationList);

            if (GenderComboBox.SelectedIndex > 0)
            {
                if (GenderComboBox.SelectedIndex == 1)
                {
                    _filterVacationList = _filterVacationList.Where(x => x.User.Gender == false).ToList();
                }
                else
                {
                    _filterVacationList = _filterVacationList.Where(x => x.User.Gender == true).ToList();
                }
            }
            if (RoleComboBox.SelectedIndex > 0)
            {
                _filterVacationList = _filterVacationList.Where(x => x.User.Role.Equals(RoleComboBox.SelectedItem)).ToList();
            }
            if (AgeComboBox.SelectedIndex > 0)
            {
                if (AgeComboBox.SelectedIndex == 1)
                {
                    _filterVacationList = _filterVacationList.Where(x => x.User.DateOfBirth.Year + 30 > DateTime.Now.Year).ToList();
                }
                else if (AgeComboBox.SelectedIndex == 2)
                {
                    _filterVacationList = _filterVacationList.Where(x => x.User.DateOfBirth.Year + 30 < DateTime.Now.Year
                                                                 && x.User.DateOfBirth.Year + 50 > DateTime.Now.Year).ToList();
                }
                else if (AgeComboBox.SelectedIndex == 3)
                {
                    _filterVacationList = _filterVacationList.Where(x => x.User.DateOfBirth.Year + 50 < DateTime.Now.Year).ToList();
                }
            }

            if (IntersectionComboBox.SelectedIndex > 0)
            {
                List<(DateTime startDate, DateTime endDate)> intersectionList = new List<(DateTime, DateTime)>();
                List<Vacation> vacationList = new List<Vacation>();

                foreach (Vacation vacation in _filterVacationList)
                {
                    bool isIntersection = false;
                    foreach (var intersection in intersectionList)
                    {
                        if (vacation.StartDate >= intersection.startDate & vacation.StartDate <= intersection.endDate
                            || vacation.EndDate >= intersection.startDate & vacation.EndDate <= intersection.endDate
                            || vacation.StartDate <= intersection.startDate & vacation.EndDate >= intersection.endDate)
                        {
                            isIntersection = true;
                            break;
                        }
                    }
                    intersectionList.Add((vacation.StartDate, vacation.EndDate));
                    if (isIntersection == false)
                    {
                        vacationList.Add(vacation);
                    }
                }
                _filterVacationList = vacationList;
            }
            VacationDataGrid.ItemsSource = _filterVacationList.ToList();
        }

        private void AddVacationButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterVacationList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            FilterVacationList();
        }
    }
}
