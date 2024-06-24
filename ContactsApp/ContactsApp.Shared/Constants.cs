using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Shared
{
    public static class Constants
    {
        public static readonly string UserNotFound = "User does not exist.\n";
        public const string InvalidPagination = "Invalid pagination parameters.\n";
        public const string InvalidId = "Invalid ID.\n";
        public const string InvalidCredentials = "Invalid Credentials.\n";
        public const string PasswordMismatch = "Passwords don't match.\n";
        public const string UserAlreadyExists = "User already exists.\n";
    }
}
