using System.Dynamic;

namespace csharp_singleton;

// https://www.c-sharpcorner.com/UploadFile/8911c4/singleton-design-pattern-in-C-Sharp/
public sealed class CacheExample
{
    private CacheExample()
    {
    }
    private static readonly object ClassLocker = new object();
    private static CacheExample? _instance = null;
    private CachedData _cachedData;

    public static CacheExample Instance
    {
        get
        {
            lock (ClassLocker)
            {
                if (_instance == null)
                {
                    _instance = new CacheExample();
                }
            }

            return _instance;
        }
    }

    public CachedData Data => _cachedData;

    public static CacheExample CreateInstance (CachedData data)
    {
        var cache = CacheExample.Instance;
        cache._cachedData = data;
        return cache;
    }
}