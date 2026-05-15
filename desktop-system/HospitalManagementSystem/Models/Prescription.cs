using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    public class Prescription
    {
        public string Doctor { get; set; }
        public int Pid { get; set; }
        public int ID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Appdate { get; set; }
        public string Apptime { get; set; }
        public string Disease { get; set; }
        public string Allergy { get; set; }
        public string PrescriptionText { get; set; }

        public string FullName => $"{Fname} {Lname}";
    }
}
