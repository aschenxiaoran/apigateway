using System;
using System.Collections.Generic;
using System.Linq;

namespace Hxf.Infrastructure.Extensions {
    public class LambdaCompare<T> : IComparer<T> {
        private readonly Func<T, T, int> _comparer;

        public LambdaCompare(Func<T, T, int> comparer) {
            _comparer = comparer;
        }

        public int Compare(T x, T y) {
            return _comparer(x, y);
        }
    }

    public class KeyEqualityComparer<T> : IEqualityComparer<T> {
        private readonly Func<T, T, bool> _comparer;
        private readonly Func<T, object> _keyExtractor;

        public KeyEqualityComparer(Func<T, object> keyExtractor) : this(keyExtractor, null) {

        }

        public KeyEqualityComparer(Func<T, T, bool> comparer) : this(null, comparer) {

        }

        public KeyEqualityComparer(Func<T, object> keyExtractor, Func<T, T, bool> comparer) {
            _keyExtractor = keyExtractor;
            _comparer = comparer;
        }

        public bool Equals(T x, T y) {
            if (_comparer != null) {
                return _comparer(x, y);
            }

            var valX = _keyExtractor(x);
            var objects = valX as IEnumerable<object>;
            if (objects != null) {
                return (objects).SequenceEqual((IEnumerable<object>)_keyExtractor(y));
            }

            return valX.Equals(_keyExtractor(y));
        }

        public int GetHashCode(T obj) {
            if (_keyExtractor == null) {
                return obj.ToString().ToLower().GetHashCode();
            }

            var val = _keyExtractor(obj);
            var objects = val as IEnumerable<object>;
            if (objects != null) {
                return (int)(objects).Aggregate((x, y) => x.GetHashCode() ^ y.GetHashCode());
            }

            return val.GetHashCode();
        }
    }
}
