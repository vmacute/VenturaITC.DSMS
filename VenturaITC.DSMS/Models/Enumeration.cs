using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VenturaITC.DSMS.Models
{
    public class Enumeration
    {

        /// <summary>
        /// Alert warnig types
        /// </summary>
        public enum Category
        {
            HEAVY_VEHICLE,
            LIGHT_VEHICLE,
            MECHANICS,
            MOTORCYCLE
        }

        /// <summary>
        /// Driving license statuses
        /// </summary>
        public enum LicenseStatus
        {
            Theory = 1,
            Practisis = 2,
            TheoricExam = 3,
            PractisisExam = 4,
            Finished = 5
        }

        /// <summary>
        /// Document types
        /// </summary>
        public enum DocumentType
        {
            Picture = 1,
            IDCopy = 2,
            MedicalCertificate = 3,
            CriminalRecordCertificate = 4,
            MilitaryServiceStatement = 5
        }

        /// <summary>
        /// Database data statuses
        /// </summary>
        public enum DatabaseDataStatus
        {
            Active = 1,
            Deleted = 2
        }

        /// <summary>
        /// user roles
        /// </summary>
        public enum UserRole
        {
            ADMINISTRATOR,
            NORMAL,
            STUDENT
        }


        /// <summary>
        /// student types.
        /// </summary>
        public enum StudentType
        {
            INTERNAL,
            EXTERNAL
        }

        /// <summary>
        /// Payment type
        /// </summary>
        public enum PaymentType
        {
            TOTAL,
            PARTIAL
        }

        /// <summary>
        /// Payment ststuses
        /// </summary>
        public enum PaymentStatus
        {
            ALL,
            FINISHED,
            NON_FINISHED
        }
    }
}