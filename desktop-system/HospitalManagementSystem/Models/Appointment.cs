using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    public class Appointment
    {
        public int Pid { get; set; }
        public int ID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Doctor { get; set; }
        public int DocFees { get; set; }
        public string Appdate { get; set; }
        public string Apptime { get; set; }
        public int UserStatus { get; set; }
        public int DoctorStatus { get; set; }

        public string FullName => $"{Fname} {Lname}";
    }
}
