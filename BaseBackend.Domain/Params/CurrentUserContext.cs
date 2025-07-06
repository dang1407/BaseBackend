namespace BaseBackend.Domain
{
    public static class CurrentUserContext
    {
        private static readonly AsyncLocal<adm_user> _currentUser = new AsyncLocal<adm_user>();

        public static adm_user CurrentUser
        {
            get => _currentUser.Value ?? new adm_user();
            set => _currentUser.Value = value;
        }
    }

}
