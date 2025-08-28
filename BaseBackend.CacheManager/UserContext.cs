namespace BaseBackend.CacheManager
{
    public static class UserContext
    {
        private static readonly AsyncLocal<UserProfile> _currentUser = new AsyncLocal<UserProfile>();

        public static UserProfile CurrentUser
        {
            get => _currentUser.Value ?? throw new InvalidOperationException("User context not initialized");
            set => _currentUser.Value = value;
        }

        public static bool IsAuthenticated => _currentUser.Value != null;
    }
}
