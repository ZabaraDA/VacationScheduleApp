using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationScheduleApp.Model
{
    public class Vacation
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public User User { get; set; }
        public Vacation(int id, DateTime startDate, DateTime endDate,User user)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            User = user;
        }
    }
}
