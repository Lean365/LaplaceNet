using CSRedis;
using La.Infra;

namespace La.Common.Cache
{
    public class RedisServer
    {
        public static CSRedisClient Cache;
        public static CSRedisClient Session;

        public static void Initalize()
        {
            Cache = new CSRedisClient(AppSettings.GetConfig("RedisServer:Cache"));
            Session = new CSRedisClient(AppSettings.GetConfig("RedisServer:Session"));
        }
    }
}
