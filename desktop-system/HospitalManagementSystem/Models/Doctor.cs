using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    public class Doctor
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Spec { get; set; }
        public int DocFees { get; set; }
    }
}
