using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationScheduleApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public bool Gender { get; set; }
        public Role Role { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<Vacation> Vacation { get; set; }
        public User(int id, string forename, string surname, string patronymic, bool gender, int roleId, Role role, DateTime dateOfBirth)
        {
            Id = id;
            Forename = forename;
            Surname = surname;
            Patronymic = patronymic;
            Gender = gender;
            Role = role;
            DateOfBirth = dateOfBirth;
            Vacation = new List<Vacation>();
        }
    }
}
