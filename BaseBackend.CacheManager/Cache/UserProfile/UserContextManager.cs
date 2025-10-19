using BaseBackend.CacheManager;
using System.Collections.Concurrent;

namespace BaseBackend.Application.Cache
{
    public static class UserContextManager
    {
        private static readonly ConcurrentDictionary<int, (UserProfile User, DateTime LastAccessed)> _userCache = new();
        private static readonly TimeSpan _cacheExpiration = TimeSpan.FromHours(2);
        private static Timer _cleanupTimer;

        static UserContextManager()
        {
            // Dọn dẹp cache mỗi giờ
            _cleanupTimer = new Timer(_ => CleanupExpiredItems(), null,
                TimeSpan.FromHours(1), TimeSpan.FromHours(1));
        }

        public static UserProfile? GetUserContext(int? id)
        {
            if (id == null) return null;

            if (_userCache.TryGetValue(id.Value, out var entry))
            {
                // Cập nhật thời gian truy cập
                _userCache[id.Value] = (entry.User, DateTime.UtcNow);
                return entry.User;
            }
            return null; // Rõ ràng trả về null thay vì dùng !
        }

        public static void AddOrUpdateUser(UserProfile user)
        {
            if (user?.UserId == null) return;

            _userCache.AddOrUpdate(
                user.UserId.Value,
                (user, DateTime.UtcNow),
                (_, existing) => (user, DateTime.UtcNow));
        }

        public static void RemoveUser(int userId)
        {
            _userCache.TryRemove(userId, out _);
        }

        private static void CleanupExpiredItems()
        {
            var cutoff = DateTime.UtcNow - _cacheExpiration;
            foreach (var entry in _userCache)
            {
                if (entry.Value.LastAccessed < cutoff)
                {
                    _userCache.TryRemove(entry.Key, out _);
                }
            }
        }

        // Hủy timer khi ứng dụng shutdown
        public static void Shutdown()
        {
            _cleanupTimer?.Dispose();
        }
    }
}
