namespace WMS.Service.Exceptions
{
    public static class ExceptionsConst
    {
        public const string UserAlreadyExists = "User already exists.";
        public const string UserCreationFailed = "User creation failed. Please check user details and try again.";
        public const string RoleDoNotExists = "Assignment of role to user failed. Role do not exist";
        public const string AssignRoleToUserFailed = "Assignment of role to user failed.";
    }
}
