using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KraceGennedy.Static
{
    public class ApplicationVariables
    {
        /// <summary>
        /// TODO The roles.
        /// </summary>
        public static class Roles
        {
            /// <summary>
            /// TODO The ITAdmin.
            /// </summary>
            public const string ITAdmin = "ITAdmin";

            /// <summary>
            /// TODO The Manager.
            /// </summary>
            public const string Manager = "Manager";

            /// <summary>
            /// TODO The Employee.
            /// </summary>
            public const string Employee = "Employee";

            public const string CEO = "CEO";
        }

        public static class SessionVariables
        {
            public const string Roles = "Roles";
            public const string UserEmail = "UserEmail";
            public const string AddUserSuccess = "AddUserSuccess";

        }
    }
}
