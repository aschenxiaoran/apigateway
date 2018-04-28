using System;
using System.Collections.Generic;

namespace Hxf.Infrastructure.Cache {
    /// <summary>
    /// 缓存容器约束接口
    /// </summary>
    public interface ICacheProvider : IDisposable {
        /// <summary>
        /// 获取缓存器所有缓存元素的键
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        ICollection<string> GetKeys();

        /// <summary>
        ///  如果该键不存在，则将键/值对添加到缓存器中；如果该键已经存在，则通过使用指定的函数更新缓存器 中的键/值对。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">要添加的元素的键</param>
        /// <param name="value">缓存泛型对象</param>
        /// <param name="slidingExpiration">相对过期时间(可选)</param>
        /// <returns></returns>
        T AddOrUpdate<T>(string key, T value, TimeSpan? slidingExpiration = null);

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">要获取的元素的键</param>
        /// <param name="value"> 当此方法返回时，将包含具有指定键的对象；如果操作失败，则包含类型的默认值</param>
        /// <returns></returns>
        bool TryGetValue<T>(string key, out T value);

        /// <summary>
        /// 如果该键尚不存在，则使用指定函数将键/值对添加到缓存容器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">要添加的键或获取值的键</param>
        /// <param name="valueFactory">用于基于键的现有值为现有键生成新值的函数</param>
        /// <param name="slidingExpiration">相对过期时间间隔(可选)</param>
        /// <returns>如果键存在, 输出缓存键值, 如果不存在输出valueFactory生成值</returns>
        T GetOrAdd<T>(string key, Func<string, T> valueFactory, TimeSpan? slidingExpiration = null);

        /// <summary>
        /// 尝试将指定的键从缓存器中移除
        /// </summary>
        /// <param name="key">要移除的键</param>
        /// <param name="value"> 当此方法返回时，将包含移除的对象；如果 T不存在，则包含 key 类型的默认值。</param>
        /// <returns></returns>
        bool TryRemove<T>(string key, out T value);

        /// <summary>
        /// 尝试将指定的键和值添加到缓存器(如果已存在缓存项则返回False)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">要添加的键</param>
        /// <param name="value"> 要添加的元素的值。对于引用类型，该值可以为 null</param>
        /// <param name="slidingExpiration">相对过期时间间隔(可选)</param>
        /// <returns></returns>
        bool TryAdd<T>(string key, T value, TimeSpan? slidingExpiration = null);

        /// <summary>
        /// 移除缓存器所有存储的键值对
        /// </summary>
        void Clear();
    }
}