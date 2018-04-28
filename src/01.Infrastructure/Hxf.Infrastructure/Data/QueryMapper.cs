using System;
using System.Collections.Generic;

namespace Hxf.Infrastructure.Data {
    public class QueryMapper<TParent, TChild> where TParent : class where TChild : class {
        private readonly IDictionary<object, TParent> _parents = new Dictionary<object, TParent>();

        public Func<TParent, TChild, TParent> Map(Func<TParent, object> keyFn, Func<TParent, ICollection<TChild>> childrenFn) {
            return Map(keyFn, (p, c) => childrenFn(p).Add(c));
        }

        public Func<TParent, TChild, TParent> Map(Func<TParent, object> keyFn, Action<TParent, TChild> setChildFn, Action<TChild, TParent> setParentFn = null) {
            return Map(_parents, keyFn, setChildFn, setParentFn);
        }

        public static Func<TParent, TChild, TParent> Map(IDictionary<object, TParent> parentsCache, Func<TParent, object> keyFn, Action<TParent, TChild> setChildFn = null, Action<TChild, TParent> setParentFn = null) {
            Func<TParent, TChild, TParent> mapFn = (p, c) => {
                if (p == null) {
                    return null;
                }

                if (c == null) {
                    return null;
                }

                var key = keyFn(p);
                TParent parent;

                if (!parentsCache.TryGetValue(key, out parent)) {
                    parentsCache.Add(key, p);
                }

                parent = parent ?? p;
                if (setChildFn != null) {
                    setChildFn(parent, c);
                }

                if (setParentFn != null) {
                    setParentFn(c, parent);
                }

                return parent;
            };

            return mapFn;
        }

        public ICollection<TParent> Results { get { return _parents.Values; } } 
    }
}