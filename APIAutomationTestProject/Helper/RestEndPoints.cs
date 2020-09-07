namespace APIAutomationTestProject.Helper
{
    public static class RestEndPoints
    {
        public static string GetUsersByCity(string city) => $"/city/{city}/users";
        public static string GetInstructions() => $"/instructions";
        public static string GetUsersById(string id) => $"/user/{id}";
        public static string GetAllUsers() => $"/users";
    }
}
