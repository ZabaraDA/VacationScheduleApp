using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationScheduleApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Forename { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public bool Gender { get; set; }
        public Role Role { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<Vacation> Vacation { get; set; }
        public User(Role role) 
        {
            Role = role;
            Vacation = new List<Vacation>();
        }
    }
}
