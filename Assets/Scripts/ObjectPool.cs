using System.Collections.Generic;

// public class ObjectPool<T>
// {
//     private const int MAX_OBJECTS = 16;

//     private Queue<T> _pool = new Queue<T>();
//     private System.Func<T> _initAction;

//     public ObjectPool(System.Func<T> action)
//     {
//         _initAction = action;

//     }

//     public T Get() {
//         T obj;

//         if (_pool.Count < 1)
//             obj = _initAction();
//         else
//             obj = _pool.Dequeue();

//         return obj;
//     }
// }

// From: https://www.genericgamedev.com/general/reusing-objects-with-generic-object-pooling/
static class StaticObjectPool
{
    private static class Pool<T>
    {
        private static readonly Stack<T> pool = new();

        public static void Push(T obj)
        {
            lock (pool)
            {
                pool.Push(obj);
            }
        }

        public static bool TryPop(out T obj)
        {
            lock (pool)
            {
                if (pool.Count > 0)
                {
                    obj = pool.Pop();
                    return true;
                }
            }
            obj = default;
            return false;
        }
    }

    public static void Push<T>(T obj)
    {
        Pool<T>.Push(obj);
    }

    public static bool TryPop<T>(out T obj)
    {
        return Pool<T>.TryPop(out obj);
    }

    public static T PopOrDefault<T>()
    {
        TryPop(out T ret);
        return ret;
    }

    public static T PopOrNew<T>()
        where T : new()
    {
        return TryPop(out T ret) ? ret : new T();
    }
}