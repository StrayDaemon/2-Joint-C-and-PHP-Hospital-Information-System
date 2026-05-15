using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Helpers
{
    public static class SessionManager
    {
        public static string Role { get; set; }      // "admin", "doctor", "patient"
        public static string Username { get; set; }  // logged-in username or email
        public static int PatientId { get; set; }    // only for patient role
    }
}
