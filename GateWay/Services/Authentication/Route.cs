namespace AI.Client.GateWay.Services.Authentication
{
    public static class Route
    {
        public static string Register = "api/account/register";
        public static string Login = "api/account/login";
        public static string Logout = "api/account/logOut";
        public static string ForgotPassword = "api/account/forgot-password";
        public static string ResetPassword = "api/account/reset-password";
        public static string ConfirmEmail = "api/account/confirm-email";
        public static string User = "api/account/currentuserinfo";
        
    }
}
