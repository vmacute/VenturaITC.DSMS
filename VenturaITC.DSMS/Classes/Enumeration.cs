using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VenturaITC.DSMS.Classes
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
        /// Alert warnig types
        /// </summary>
        public enum WarningType
        {
            Success,
            Info,
            Warning,
            Danger
        }

        /// <summary>
        /// Document types
        /// </summary>
        public enum DocumentType
        {
            PICTURE,
            ID_COPY,
            CRIMINAL_RECORD,
            MEDICAL_CERTIFICATE,
            MILITAR_SERVICE_DECLARATION
        }

        /// <summary>
        /// Database data statuses
        /// </summary>
        public enum DatabaseDataStatus
        {
            ACTIVE,
            DELETED
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