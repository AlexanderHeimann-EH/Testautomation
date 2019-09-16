﻿/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. 
 *
 * This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the Apache License, Version 2.0, please send an email to 
 * vspython@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Apache License, Version 2.0.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * ***************************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Microsoft.PythonTools.Analysis {
    /// <summary>
    /// Represents an unordered collection of <see cref="AnalysisValue" /> objects;
    /// in effect, a set of Python types. There are multiple implementing
    /// classes, including <see cref="AnalysisValue" /> itself, to improve memory
    /// usage for small sets.
    /// 
    /// <see cref="AnalysisSet" /> does not implement this interface, but
    /// provides factory and extension methods.
    /// </summary>
    public interface IAnalysisSet : IEnumerable<AnalysisValue> {
        IAnalysisSet Add(AnalysisValue item, bool canMutate = true);
        IAnalysisSet Add(AnalysisValue item, out bool wasChanged, bool canMutate = true);
        IAnalysisSet Union(IEnumerable<AnalysisValue> items, bool canMutate = true);
        IAnalysisSet Union(IEnumerable<AnalysisValue> items, out bool wasChanged, bool canMutate = true);
        IAnalysisSet Clone();

        bool Contains(AnalysisValue item);
        bool SetEquals(IAnalysisSet other);

        int Count { get; }
        IEqualityComparer<AnalysisValue> Comparer { get; }
    }

    /// <summary>
    /// Provides factory and extension methods for objects implementing
    /// <see cref="IAnalysisSet" />.
    /// </summary>
    public static class AnalysisSet {
        /// <summary>
        /// An empty set that does not combine types. This object is immutable
        /// and can be used without cloning.
        /// </summary>
        public static readonly IAnalysisSet Empty = Create();
        /// <summary>
        /// An empty set that combines types with a strength of zero. This
        /// object is immutable and can be used without cloning.
        /// </summary>
        public static readonly IAnalysisSet EmptyUnion = CreateUnion(UnionComparer.Instances[0]);

        #region Constructors

        /// <summary>
        /// Returns an empty set that does not combine types. This is exactly
        /// equivalent to accessing <see cref="Empty" />.
        /// </summary>
        public static IAnalysisSet Create() {
            return AnalysisSetDetails.AnalysisSetEmptyObject.Instance;
        }

        /// <summary>
        /// Returns a set containing only <paramref name="ns" />. This is
        /// exactly equivalent to casting <paramref name="ns" /> to <see
        /// cref="IAnalysisSet" />.
        /// </summary>
        /// <param name="ns">The namespace to contain in the set.</param>
        public static IAnalysisSet Create(AnalysisValue ns) {
            return ns;
        }

        /// <summary>
        /// Returns a set containing all the types in <paramref name="ns" />.
        /// This is the usual way of creating a new set from any sequence.
        /// </summary>
        /// <param name="ns">The namespaces to contain in the set.</param>
        public static IAnalysisSet Create(IEnumerable<AnalysisValue> ns) {
            // TODO: Replace Trim() call with more efficient enumeration.
            return new AnalysisSetDetails.AnalysisSetManyObject(ns).Trim();
        }

        /// <summary>
        /// Returns a set containing all the types in <paramref name="ns" />
        /// with the specified comparer. This function uses the type of
        /// <paramref name="comparer" /> to determine which factory method
        /// should be used.
        /// 
        /// If <paramref name="ns" /> is a set with the same comparer as
        /// <paramref name="comparer"/>, it may be returned without
        /// modification.
        /// </summary>
        /// <param name="ns">The namespaces to contain in the set.</param>
        /// <param name="comparer">The comparer to use for the set.</param>
        /// <exception name="InvalidOperationException"><paramref
        /// name="comparer" /> is not an instance of <see cref="ObjectComparer"
        /// /> or <see cref="UnionComparer" />.</exception>
        public static IAnalysisSet Create(IEnumerable<AnalysisValue> ns, IEqualityComparer<AnalysisValue> comparer) {
            var set = ns as IAnalysisSet;
            if (set == null) {
                UnionComparer uc;
                if (comparer is ObjectComparer) {
                    return ns == null ? Create() : Create(ns);
                } else if ((uc = comparer as UnionComparer) != null) {
                    return ns == null ? CreateUnion(uc) : CreateUnion(ns, uc);
                }
            } else if (comparer == set.Comparer) {
                return set;
            } else if (comparer != null && comparer.GetType() == set.Comparer.GetType()) {
                return set;
            } else if (comparer is ObjectComparer) {
                return Create(set);
            } else if (comparer is UnionComparer) {
                bool dummy;
                return set.AsUnion((UnionComparer)comparer, out dummy);
            }

            throw new InvalidOperationException(string.Format("cannot use {0} as a comparer", comparer));
        }

        /// <summary>
        /// Returns an empty set that uses a <see cref="UnionComparer" /> with
        /// the specified strength.
        /// </summary>
        /// <param name="strength">The strength to use for the comparer.
        /// </param>
        public static IAnalysisSet CreateUnion(int strength) {
            if (strength < 0) {
                strength = 0;
            } else if (strength > UnionComparer.MAX_STRENGTH) {
                strength = UnionComparer.MAX_STRENGTH;
            }
            return AnalysisSetDetails.AnalysisSetEmptyUnion.Instances[strength];
        }

        /// <summary>
        /// Returns an empty set that uses the specified <see
        /// cref="UnionComparer" />.
        /// </summary>
        /// <param name="comparer">The comparer to use for the set.</param>
        internal static IAnalysisSet CreateUnion(UnionComparer comparer) {
            return AnalysisSetDetails.AnalysisSetEmptyUnion.Instances[comparer.Strength];
        }

        /// <summary>
        /// Returns a set containing only <paramref name="ns" /> that uses the
        /// specified <see cref="UnionComparer" />.
        /// 
        /// This is different to casting from <see cref="AnalysisValue" /> to <see
        /// cref="IAnalysisSet" />, because the implementation in <see
        /// cref="AnalysisValue" /> always uses <see cref="ObjectComparer" />.
        /// </summary>
        /// <param name="ns">The namespace to contain in the set.</param>
        /// <param name="comparer">The comparer to use for the set.</param>
        internal static IAnalysisSet CreateUnion(AnalysisValue ns, UnionComparer comparer) {
            return new AnalysisSetDetails.AnalysisSetOneUnion(ns, comparer);
        }

        /// <summary>
        /// Returns a set containing all the types in <paramref name="ns" />
        /// after merging using the specified <see cref="UnionComparer" />. For
        /// large sets, this operation may require significant time and memory.
        /// The returned set is always a copy of the original.
        /// </summary>
        /// <param name="ns">The namespaces to contain in the set.</param>
        /// <param name="comparer">The comparer to use for the set.</param>
        internal static IAnalysisSet CreateUnion(IEnumerable<AnalysisValue> ns, UnionComparer comparer) {
            bool dummy;
            // TODO: Replace Trim() call with more intelligent enumeration.
            return new AnalysisSetDetails.AnalysisSetManyUnion(ns.UnionIter(comparer, out dummy), comparer).Trim();
        }

        /// <summary>
        /// Returns a set containing all types in all the sets in <paramref
        /// name="sets" />.
        /// </summary>
        /// <param name="sets">The sets to contain in the set.</param>
        /// <param name="canMutate">True if sets in <paramref name="sets"/> may
        /// be modified.</param>
        public static IAnalysisSet UnionAll(IEnumerable<IAnalysisSet> sets, bool canMutate = true) {
            return Empty.UnionAll(sets, canMutate);
        }

        /// <summary>
        /// Returns a set containing all types in all the sets in <paramref
        /// name="sets" />.
        /// </summary>
        /// <param name="sets">The sets to contain in the set.</param>
        /// <param name="wasChanged">Returns True if the result is not an empty
        /// set.</param>
        /// <param name="canMutate">True if sets in <paramref name="sets"/> may
        /// be modified.</param>
        public static IAnalysisSet UnionAll(IEnumerable<IAnalysisSet> sets, out bool wasChanged, bool canMutate = true) {
            return Empty.UnionAll(sets, out wasChanged, canMutate);
        }

        #endregion

        #region Extension Methods

        /// <summary>
        /// Returns <paramref name="set"/> with a comparer with increased
        /// strength. If the strength cannot be increased, <paramref
        /// name="set"/> is returned unmodified.
        /// </summary>
        /// <param name="set">The set to increase the strength of.</param>
        public static IAnalysisSet AsStrongerUnion(this IAnalysisSet set) {
            var comparer = set.Comparer as UnionComparer;
            if (comparer != null) {
                return set.AsUnion(comparer.Strength + 1);
            } else {
                return set.AsUnion(0);
            }
        }

        /// <summary>
        /// Returns <paramref name="set"/> with a comparer with the specified
        /// strength. If the strength does not need to be changed, <paramref
        /// name="set"/> is returned unmodified.
        /// </summary>
        /// <param name="set">The set to convert to a union.</param>
        /// <param name="strength">The strength of the union.</param>
        public static IAnalysisSet AsUnion(this IAnalysisSet set, int strength) {
            bool dummy;
            return set.AsUnion(strength, out dummy);
        }

        /// <summary>
        /// Returns <paramref name="set"/> with a comparer with the specified
        /// strength. If the strength does not need to be changed, <paramref
        /// name="set"/> is returned unmodified.
        /// </summary>
        /// <param name="set">The set to convert to a union.</param>
        /// <param name="strength">The strength of the union.</param>
        /// <param name="wasChanged">Returns True if the contents of the
        /// returned set are different to <paramref name="set"/>.</param>
        public static IAnalysisSet AsUnion(this IAnalysisSet set, int strength, out bool wasChanged) {
            if (strength > UnionComparer.MAX_STRENGTH) {
                strength = UnionComparer.MAX_STRENGTH;
            } else if (strength < 0) {
                strength = 0;
            }
            var comparer = UnionComparer.Instances[strength];
            return AsUnion(set, comparer, out wasChanged);
        }

        /// <summary>
        /// Returns <paramref name="set"/> with the specified comparer. If the
        /// comparer does not need to be changed, <paramref name="set"/> is
        /// returned unmodified.
        /// </summary>
        /// <param name="set">The set to convert to a union.</param>
        /// <param name="comparer">The comparer to use for the set.</param>
        /// <param name="wasChanged">Returns True if the contents of the
        /// returned set are different to <paramref name="set"/>.</param>
        internal static IAnalysisSet AsUnion(this IAnalysisSet set, UnionComparer comparer, out bool wasChanged) {
            if ((set is AnalysisSetDetails.AnalysisSetOneUnion ||
                set is AnalysisSetDetails.AnalysisSetTwoUnion ||
                set is AnalysisSetDetails.AnalysisSetEmptyUnion ||
                set is AnalysisSetDetails.AnalysisSetManyUnion) &&
                set.Comparer == comparer) {
                wasChanged = false;
                return set;
            }

            wasChanged = true;

            var ns = set as AnalysisValue;
            if (ns != null) {
                return CreateUnion(ns, comparer);
            }
            var ns1 = set as AnalysisSetDetails.AnalysisSetOneObject;
            if (ns1 != null) {
                return CreateUnion(ns1.Value, comparer);
            }
            var ns2 = set as AnalysisSetDetails.AnalysisSetTwoObject;
            if (ns2 != null) {
                if (comparer.Equals(ns2.Value1, ns2.Value2)) {
                    bool dummy;
                    return new AnalysisSetDetails.AnalysisSetOneUnion(comparer.MergeTypes(ns2.Value1, ns2.Value2, out dummy), comparer);
                } else {
                    return new AnalysisSetDetails.AnalysisSetTwoUnion(ns2.Value1, ns2.Value2, comparer);
                }
            }

            return new AnalysisSetDetails.AnalysisSetManyUnion(set, comparer);
        }

        /// <summary>
        /// Merges the provided sequence using the specified <see
        /// cref="UnionComparer"/>.
        /// </summary>
#if FULL_VALIDATION
        internal static IEnumerable<AnalysisValue> UnionIter(this IEnumerable<AnalysisValue> items, UnionComparer comparer, out bool wasChanged) {
            var originalItems = items.ToList();
            var newItems = UnionIterInternal(items, comparer, out wasChanged).ToList();

            Validation.Assert(newItems.Count <= originalItems.Count);
            if (wasChanged) {
                Validation.Assert(newItems.Count < originalItems.Count);
                foreach (var x in newItems) {
                    foreach (var y in newItems) {
                        if (object.ReferenceEquals(x, y)) continue;

                        Validation.Assert(!comparer.Equals(x, y));
                        Validation.Assert(!comparer.Equals(y, x));
                    }
                }
            }

            return newItems;
        }

        private static IEnumerable<AnalysisValue> UnionIterInternal(IEnumerable<AnalysisValue> items, UnionComparer comparer, out bool wasChanged) {
#else
        internal static IEnumerable<AnalysisValue> UnionIter(this IEnumerable<AnalysisValue> items, UnionComparer comparer, out bool wasChanged) {
#endif
            wasChanged = false;

            var asSet = items as IAnalysisSet;
            if (asSet != null && asSet.Comparer == comparer) {
                return items;
            }

            var newItems = new List<AnalysisValue>();
            var anyMerged = true;

            while (anyMerged) {
                anyMerged = false;
                var matches = new Dictionary<AnalysisValue, List<AnalysisValue>>(comparer);

                foreach (var ns in items) {
                    List<AnalysisValue> list;
                    if (matches.TryGetValue(ns, out list)) {
                        if (list == null) {
                            matches[ns] = list = new List<AnalysisValue>();
                        }
                        list.Add(ns);
                    } else {
                        matches[ns] = null;
                    }
                }

                newItems.Clear();

                foreach (var keyValue in matches) {
                    var item = keyValue.Key;
                    if (keyValue.Value != null) {
                        foreach (var other in keyValue.Value) {
                            bool merged;
#if FULL_VALIDATION
                            Validation.Assert(comparer.Equals(item, other));
#endif
                            item = comparer.MergeTypes(item, other, out merged);
                            if (merged) {
                                anyMerged = true;
                                wasChanged = true;
                            }
                        }
                    }
                    newItems.Add(item);
                }
                items = newItems;
            }

            return items;
        }

        /// <summary>
        /// Removes excess capacity from <paramref name="set"/>.
        /// </summary>
        public static IAnalysisSet Trim(this IAnalysisSet set) {
            if (set is AnalysisSetDetails.AnalysisSetManyObject) {
                switch (set.Count) {
                    case 0:
                        return Empty;
                    case 1:
                        return set.First();
                    case 2:
                        return new AnalysisSetDetails.AnalysisSetTwoObject(set);
                    default:
                        return set;
                }
            } else if (set is AnalysisSetDetails.AnalysisSetManyUnion) {
                switch (set.Count) {
                    case 0:
                        return AnalysisSetDetails.AnalysisSetEmptyUnion.Instances[((UnionComparer)set.Comparer).Strength];
                    case 1:
                        return new AnalysisSetDetails.AnalysisSetOneUnion(set.First(), (UnionComparer)set.Comparer);
                    case 2: {
                            var tup = AnalysisSetDetails.AnalysisSetTwoUnion.FromEnumerable(set, (UnionComparer)set.Comparer);
                            if (tup == null) {
                                return set;
                            } else if (tup.Item1 == null && tup.Item2 == null) {
                                return AnalysisSetDetails.AnalysisSetEmptyUnion.Instances[((UnionComparer)set.Comparer).Strength];
                            } else if (tup.Item2 == null) {
                                return new AnalysisSetDetails.AnalysisSetOneUnion(tup.Item1, (UnionComparer)set.Comparer);
                            } else {
                                return new AnalysisSetDetails.AnalysisSetTwoUnion(tup.Item1, tup.Item2, (UnionComparer)set.Comparer);
                            }
                        }
                    default:
                        return set;
                }
            } else {
                return set;
            }
        }

        /// <summary>
        /// Merges all the types in <paramref name="sets" /> into this set.
        /// </summary>
        /// <param name="sets">The sets to merge into this set.</param>
        /// <param name="canMutate">True if this set may be modified.</param>
        public static IAnalysisSet UnionAll(this IAnalysisSet set, IEnumerable<IAnalysisSet> sets, bool canMutate = true) {
            bool dummy;
            return set.UnionAll(sets, out dummy, canMutate);
        }

        /// <summary>
        /// Merges all the types in <paramref name="sets" /> into this set.
        /// </summary>
        /// <param name="sets">The sets to merge into this set.</param>
        /// <param name="wasChanged">Returns True if the contents of the
        /// returned set are different to the original set.</param>
        /// <param name="canMutate">True if this set may be modified.</param>
        public static IAnalysisSet UnionAll(this IAnalysisSet set, IEnumerable<IAnalysisSet> sets, out bool wasChanged, bool canMutate = true) {
            bool changed;
            wasChanged = false;
            foreach (var s in sets) {
                var newSet = set.Union(s, out changed, canMutate);
                if (changed) {
                    wasChanged = true;
                }
                set = newSet;
            }
            return set;
        }

        #endregion
    }

    sealed class ObjectComparer : IEqualityComparer<AnalysisValue>, IEqualityComparer<IAnalysisSet> {
        public static readonly ObjectComparer Instance = new ObjectComparer();

        public bool Equals(AnalysisValue x, AnalysisValue y) {
#if FULL_VALIDATION
            if (x != null && y != null) {
                Validation.Assert(x.Equals(y) == y.Equals(x));
                if (x.Equals(y)) {
                    Validation.Assert(x.GetHashCode() == y.GetHashCode());
                }
            }
#endif
            return (x == null) ? (y == null) : x.Equals(y);
        }

        public int GetHashCode(AnalysisValue obj) {
            return (obj == null) ? 0 : obj.GetHashCode();
        }

        public bool Equals(IAnalysisSet set1, IAnalysisSet set2) {
            if (set1.Comparer == this) {
                return set1.SetEquals(set2);
            } else if (set2.Comparer == this) {
                return set2.SetEquals(set1);
            } else {
                return set1.All(ns => set2.Contains(ns, this)) &&
                       set2.All(ns => set1.Contains(ns, this));
            }
        }

        public int GetHashCode(IAnalysisSet obj) {
            return obj.Aggregate(GetHashCode(), (hash, ns) => hash ^ GetHashCode(ns));
        }
    }

    sealed class UnionComparer : IEqualityComparer<AnalysisValue>, IEqualityComparer<IAnalysisSet> {
        public const int MAX_STRENGTH = 3;
        public static readonly UnionComparer[] Instances = Enumerable.Range(0, MAX_STRENGTH + 1).Select(i => new UnionComparer(i)).ToArray();


        public readonly int Strength;

        public UnionComparer(int strength = 0) {
            Strength = strength;
        }

        public bool Equals(AnalysisValue x, AnalysisValue y) {
#if FULL_VALIDATION
            if (x != null && y != null) {
                Validation.Assert(x.UnionEquals(y, Strength) == y.UnionEquals(x, Strength), string.Format("{0}\n{1}\n{2}", Strength, x, y));
                if (x.UnionEquals(y, Strength)) {
                    Validation.Assert(x.UnionHashCode(Strength) == y.UnionHashCode(Strength), string.Format("Strength:{0}\n{1} - {2}\n{3} - {4}", Strength, x, x.UnionHashCode(Strength), y, y.UnionHashCode(Strength)));
                }
            }
#endif
            if (Object.ReferenceEquals(x, y)) {
                return true;
            }
            return (x == null) ? (y == null) : x.UnionEquals(y, Strength);
        }

        public int GetHashCode(AnalysisValue obj) {
            return (obj == null) ? 0 : obj.UnionHashCode(Strength);
        }

        public AnalysisValue MergeTypes(AnalysisValue x, AnalysisValue y, out bool wasChanged) {
            if (Object.ReferenceEquals(x, y)) {
                wasChanged = false;
                return x;
            }
            var z = x.UnionMergeTypes(y, Strength);
            wasChanged = !Object.ReferenceEquals(x, z);
#if FULL_VALIDATION
            var z2 = y.UnionMergeTypes(x, Strength);
            if (!object.ReferenceEquals(z, z2)) {
                Validation.Assert(z.UnionEquals(z2, Strength), string.Format("{0}\n{1} + {2} => {3}\n{2} + {1} => {4}", Strength, x, y, z, z2));
                Validation.Assert(z2.UnionEquals(z, Strength), string.Format("{0}\n{1} + {2} => {3}\n{2} + {1} => {4}", Strength, y, x, z2, z));
            }
#endif
            return z;
        }

        public bool Equals(IAnalysisSet set1, IAnalysisSet set2) {
            if (set1.Comparer == this) {
                return set1.SetEquals(set2);
            } else if (set2.Comparer == this) {
                return set2.SetEquals(set1);
            } else {
                return set1.All(ns => set2.Contains(ns, this)) &&
                    (set2.Comparer == set1.Comparer || set2.All(ns => set1.Contains(ns, this)));
            }
        }

        public int GetHashCode(IAnalysisSet obj) {
            return obj.Aggregate(GetHashCode(), (hash, ns) => hash ^ GetHashCode(ns));
        }
    }



    namespace AnalysisSetDetails {
        sealed class DebugViewProxy {
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            public const string DisplayString = "{this}, {Comparer.GetType().Name,nq}";

            public DebugViewProxy(IAnalysisSet source) {
                Data = source.ToArray();
                Comparer = source.Comparer;
            }

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public AnalysisValue[] Data;

            public override string ToString() {
                return ToString(Data);
            }

            public static string ToString(IAnalysisSet source) {
                return ToString(source.ToArray());
            }

            public static string ToString(AnalysisValue[] source) {
                var data = source.ToArray();
                if (data.Length == 0) {
                    return "{}";
                } else if (data.Length < 5) {
                    return "{" + string.Join(", ", data.AsEnumerable()) + "}";
                } else {
                    return string.Format("{{Size = {0}}}", data.Length);
                }
            }

            public IEqualityComparer<AnalysisValue> Comparer {
                get;
                private set;
            }

            public int Size {
                get { return Data.Length; }
            }
        }

        [DebuggerDisplay(DebugViewProxy.DisplayString), DebuggerTypeProxy(typeof(DebugViewProxy))]
        sealed class AnalysisSetManyObject : IAnalysisSet {
            public readonly HashSet<AnalysisValue> Set;

            public AnalysisSetManyObject(IEnumerable<AnalysisValue> items) {
                Set = new HashSet<AnalysisValue>(items ?? Enumerable.Empty<AnalysisValue>(), ObjectComparer.Instance);
            }

            internal AnalysisSetManyObject(AnalysisSetTwoObject firstTwo, AnalysisValue third) {
                Set = new HashSet<AnalysisValue>(ObjectComparer.Instance);
                Set.Add(firstTwo.Value1);
                Set.Add(firstTwo.Value2);
                Set.Add(third);
            }

            public IAnalysisSet Add(AnalysisValue item, bool canMutate = true) {
                if (canMutate) {
                    Set.Add(item);
                    return this;
                }
                if (Set.Contains(item)) {
                    return this;
                }
                var set = new AnalysisSetManyObject(this.Set);
                set.Set.Add(item);
                return set;
            }

            public IAnalysisSet Add(AnalysisValue item, out bool wasChanged, bool canMutate = true) {
                if (canMutate) {
                    wasChanged = Set.Add(item);
                    return this;
                }
                if (Set.Contains(item)) {
                    wasChanged = false;
                    return this;
                }
                var set = new AnalysisSetManyObject(this.Set);
                wasChanged = set.Set.Add(item);
                return set;
            }

            public IAnalysisSet Union(IEnumerable<AnalysisValue> items, bool canMutate = true) {
                if (items == null) {
                    return this;
                }
                if (canMutate) {
                    Set.UnionWith(items);
                    return this;
                }
                if (Set.IsSupersetOf(items)) {
                    return this;
                }
                var set = new AnalysisSetManyObject(this.Set);
                set.Set.UnionWith(items);
                return set;
            }

            public IAnalysisSet Union(IEnumerable<AnalysisValue> items, out bool wasChanged, bool canMutate = true) {
                if (items == null) {
                    wasChanged = false;
                    return this;
                }
                if (canMutate) {
                    var prevCount = Count;
                    Set.UnionWith(items);
                    wasChanged = prevCount != Count;
                    return this;
                }
                if (Set.IsSupersetOf(items)) {
                    wasChanged = false;
                    return this;
                }
                var set = new AnalysisSetManyObject(this.Set);
                wasChanged = true;
                set.Set.UnionWith(items);
                return set;
            }

            public IAnalysisSet Clone() {
                switch (Set.Count) {
                    case 0:
                        return new AnalysisSetEmptyObject();
                    case 1:
                        return new AnalysisSetOneObject(Set.First());
                    case 2:
                        return new AnalysisSetTwoObject(Set);
                    default:
                        return new AnalysisSetManyObject(Set);
                }
            }

            public bool Contains(AnalysisValue item) {
                return Set.Contains(item);
            }

            public bool SetEquals(IAnalysisSet other) {
                if (other == null) {
                    return false;
                }
                foreach (var ns in Set) {
                    if (!other.Contains(ns, Comparer)) {
                        return false;
                    }
                }
                if (other.Comparer != Comparer) {
                    foreach (var ns in Set) {
                        if (!other.Contains(ns, Comparer)) {
                            return false;
                        }
                    }
                }
                return true;
            }

            public int Count {
                get { return Set.Count; }
            }

            public IEnumerator<AnalysisValue> GetEnumerator() {
                return Set.GetEnumerator();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
                return Set.GetEnumerator();
            }

            public IEqualityComparer<AnalysisValue> Comparer {
                get { return ObjectComparer.Instance; }
            }

            public override string ToString() {
                return DebugViewProxy.ToString(this);
            }
        }

        [DebuggerDisplay(DebugViewProxy.DisplayString), DebuggerTypeProxy(typeof(DebugViewProxy))]
        sealed class AnalysisSetEmptyObject : IAnalysisSet {
            public static readonly IAnalysisSet Instance = new AnalysisSetEmptyObject();

            public IAnalysisSet Add(AnalysisValue item, bool canMutate = true) {
                return item;
            }

            public IAnalysisSet Add(AnalysisValue item, out bool wasChanged, bool canMutate = true) {
                wasChanged = true;
                return item;
            }

            public IAnalysisSet Union(IEnumerable<AnalysisValue> items, bool canMutate = true) {
                if (items == null || items is AnalysisSetEmptyObject || items is AnalysisSetEmptyUnion) {
                    return this;
                }
                if (items is AnalysisValue || items is AnalysisSetOneObject || items is AnalysisSetTwoObject) {
                    return (IAnalysisSet)items;
                }
                return items.Any() ? AnalysisSet.Create(items) : this;
            }

            public IAnalysisSet Union(IEnumerable<AnalysisValue> items, out bool wasChanged, bool canMutate = true) {
                if (items == null || items is AnalysisSetEmptyObject || items is AnalysisSetEmptyUnion) {
                    wasChanged = false;
                    return this;
                }
                if (items is AnalysisValue || items is AnalysisSetOneObject || items is AnalysisSetTwoObject) {
                    wasChanged = true;
                    return (IAnalysisSet)items;
                }
                wasChanged = items.Any();
                return wasChanged ? AnalysisSet.Create(items) : this;
            }

            public IAnalysisSet Clone() {
                return this;
            }

            public bool Contains(AnalysisValue item) {
                return false;
            }

            public bool SetEquals(IAnalysisSet other) {
                return other != null && other.Count == 0;
            }

            public int Count {
                get { return 0; }
            }

            public IEnumerator<AnalysisValue> GetEnumerator() {
                yield break;
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
                return GetEnumerator();
            }

            public IEqualityComparer<AnalysisValue> Comparer {
                get { return ObjectComparer.Instance; }
            }

            public override string ToString() {
                return DebugViewProxy.ToString(this);
            }
        }

        [DebuggerDisplay(DebugViewProxy.DisplayString), DebuggerTypeProxy(typeof(DebugViewProxy))]
        sealed class AnalysisSetOneObject : IAnalysisSet {
            public readonly AnalysisValue Value;

            public AnalysisSetOneObject(AnalysisValue value) {
                Value = value;
            }

            public IAnalysisSet Add(AnalysisValue item, bool canMutate = true) {
                if (ObjectComparer.Instance.Equals(Value, item)) {
                    return this;
                } else {
                    return new AnalysisSetTwoObject(Value, item);
                }
            }

            public IAnalysisSet Add(AnalysisValue item, out bool wasChanged, bool canMutate = true) {
                if (ObjectComparer.Instance.Equals(Value, item)) {
                    wasChanged = false;
                    return this;
                } else {
                    wasChanged = true;
                    return new AnalysisSetTwoObject(Value, item);
                }
            }

            public IAnalysisSet Union(IEnumerable<AnalysisValue> items, bool canMutate = true) {
                AnalysisSetOneObject ns1;
                AnalysisSetTwoObject ns2;
                if (items == null) {
                    return this;
                } else if ((ns1 = items as AnalysisSetOneObject) != null) {
                    return Add(ns1.Value, canMutate);
                } else if ((ns2 = items as AnalysisSetTwoObject) != null) {
                    if (ns2.Contains(Value)) {
                        return ns2;
                    }
                    return new AnalysisSetManyObject(ns2, Value);
                } else {
                    return new AnalysisSetManyObject(items).Add(Value);
                }
            }

            public IAnalysisSet Union(IEnumerable<AnalysisValue> items, out bool wasChanged, bool canMutate = true) {
                AnalysisSetOneObject ns1;
                AnalysisSetTwoObject ns2;
                if (items == null) {
                    wasChanged = false;
                    return this;
                } else if ((ns1 = items as AnalysisSetOneObject) != null) {
                    return Add(ns1.Value, out wasChanged, canMutate);
                } else if ((ns2 = items as AnalysisSetTwoObject) != null) {
                    wasChanged = true;
                    if (ns2.Contains(Value)) {
                        return ns2;
                    }
                    return new AnalysisSetManyObject(ns2, Value);
                } else {
                    return new AnalysisSetManyObject(items).Add(Value, out wasChanged);
                }
            }

            public IAnalysisSet Clone() {
                return this;
            }

            public bool Contains(AnalysisValue item) {
                return ObjectComparer.Instance.Equals(Value, item);
            }

            public bool SetEquals(IAnalysisSet other) {
                AnalysisValue ns;
                AnalysisSetOneObject ns1o;
                AnalysisSetOneUnion ns1u;
                if ((ns = other as AnalysisValue) != null) {
                    return ObjectComparer.Instance.Equals(Value, ns);
                } else if ((ns1o = other as AnalysisSetOneObject) != null) {
                    return ObjectComparer.Instance.Equals(Value, ns1o.Value);
                } else if ((ns1u = other as AnalysisSetOneUnion) != null) {
                    return ObjectComparer.Instance.Equals(Value, ns1u.Value);
                } else if (other != null && other.Count == 1) {
                    return ObjectComparer.Instance.Equals(Value, other.First());
                } else {
                    return false;
                }
            }

            public int Count {
                get { return 1; }
            }

            public IEnumerator<AnalysisValue> GetEnumerator() {
                return new SetOfOneEnumerator<AnalysisValue>(Value);
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
                return GetEnumerator();
            }

            public IEqualityComparer<AnalysisValue> Comparer {
                get { return ObjectComparer.Instance; }
            }

            public override string ToString() {
                return DebugViewProxy.ToString(this);
            }
        }

        [DebuggerDisplay(DebugViewProxy.DisplayString), DebuggerTypeProxy(typeof(DebugViewProxy))]
        sealed class AnalysisSetTwoObject : IAnalysisSet {
            public readonly AnalysisValue Value1, Value2;

            public AnalysisSetTwoObject(AnalysisValue value1, AnalysisValue value2) {
                Value1 = value1;
                Value2 = value2;
            }

            public AnalysisSetTwoObject(IEnumerable<AnalysisValue> set) {
                using (var e = set.GetEnumerator()) {
                    if (!e.MoveNext()) {
                        throw new InvalidOperationException("Sequence requires exactly two values");
                    }
                    Value1 = e.Current;
                    if (!e.MoveNext() && !ObjectComparer.Instance.Equals(e.Current, Value1)) {
                        throw new InvalidOperationException("Sequence requires exactly two values");
                    }
                    Value2 = e.Current;
                    if (e.MoveNext()) {
                        throw new InvalidOperationException("Sequence requires exactly two values");
                    }
                }
            }

            public IAnalysisSet Add(AnalysisValue item, bool canMutate = true) {
                if (ObjectComparer.Instance.Equals(Value1, item) || ObjectComparer.Instance.Equals(Value2, item)) {
                    return this;
                }
                return new AnalysisSetManyObject(this, item);
            }

            public IAnalysisSet Add(AnalysisValue item, out bool wasChanged, bool canMutate = true) {
                if (ObjectComparer.Instance.Equals(Value1, item) || ObjectComparer.Instance.Equals(Value2, item)) {
                    wasChanged = false;
                    return this;
                }
                wasChanged = true;
                return new AnalysisSetManyObject(this, item);
            }

            public IAnalysisSet Union(IEnumerable<AnalysisValue> items, bool canMutate = true) {
                AnalysisValue ns;
                AnalysisSetOneObject ns1;
                if (items == null) {
                    return this;
                } else if ((ns = items as AnalysisValue) != null) {
                    return Add(ns, canMutate);
                } else if ((ns1 = items as AnalysisSetOneObject) != null) {
                    return Add(ns1.Value, canMutate);
                } else {
                    return new AnalysisSetManyObject(items).Add(Value1).Add(Value2);
                }
            }

            public IAnalysisSet Union(IEnumerable<AnalysisValue> items, out bool wasChanged, bool canMutate = true) {
                AnalysisValue ns;
                AnalysisSetOneObject ns1;
                if (items == null) {
                    wasChanged = false;
                    return this;
                } else if ((ns = items as AnalysisValue) != null) {
                    return Add(ns, out wasChanged, canMutate);
                } else if ((ns1 = items as AnalysisSetOneObject) != null) {
                    return Add(ns1.Value, out wasChanged, canMutate);
                } else {
                    bool wasChanged1, wasChanged2;
                    var set = new AnalysisSetManyObject(items).Add(Value1, out wasChanged1).Add(Value2, out wasChanged2);
                    wasChanged = wasChanged1 || wasChanged2;
                    return set;
                }
            }

            public IAnalysisSet Clone() {
                return this;
            }

            public bool Contains(AnalysisValue item) {
                return ObjectComparer.Instance.Equals(Value1, item) || ObjectComparer.Instance.Equals(Value2, item);
            }

            public bool SetEquals(IAnalysisSet other) {
                var ns2 = other as AnalysisSetTwoObject;
                if (ns2 != null) {
                    return ObjectComparer.Instance.Equals(Value1, ns2.Value1) && ObjectComparer.Instance.Equals(Value2, ns2.Value2) ||
                        ObjectComparer.Instance.Equals(Value1, ns2.Value2) && ObjectComparer.Instance.Equals(Value2, ns2.Value1);
                } else if (other != null && other.Count == 2) {
                    foreach (var ns in other) {
                        if (!ObjectComparer.Instance.Equals(Value1, ns) && !ObjectComparer.Instance.Equals(Value2, ns)) {
                            return false;
                        }
                    }
                    return true;
                } else {
                    return false;
                }
            }

            public int Count {
                get { return 2; }
            }

            public IEnumerator<AnalysisValue> GetEnumerator() {
                yield return Value1;
                yield return Value2;
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
                return GetEnumerator();
            }

            public IEqualityComparer<AnalysisValue> Comparer {
                get { return ObjectComparer.Instance; }
            }

            public override string ToString() {
                return DebugViewProxy.ToString(this);
            }
        }




        [DebuggerDisplay(DebugViewProxy.DisplayString), DebuggerTypeProxy(typeof(DebugViewProxy))]
        sealed class AnalysisSetManyUnion : IAnalysisSet {
            public readonly HashSet<AnalysisValue> Set;

            public AnalysisSetManyUnion(IEnumerable<AnalysisValue> items, UnionComparer comparer) {
                Set = new HashSet<AnalysisValue>(items ?? Enumerable.Empty<AnalysisValue>(), comparer);
            }

            internal AnalysisSetManyUnion(AnalysisSetTwoUnion firstTwo, AnalysisValue third, UnionComparer comparer, out bool wasChanged) {
                Set = new HashSet<AnalysisValue>(comparer);
                Set.Add(firstTwo.Value1);
                wasChanged = true;
                if (!Set.Add(firstTwo.Value2) || !Set.Add(third)) {
                    Set.Clear();
                    Set.UnionWith(firstTwo.Concat(third).UnionIter(comparer, out wasChanged));
                }
            }

            private AnalysisSetManyUnion(HashSet<AnalysisValue> set) {
                Set = set;
            }

            public IAnalysisSet Add(AnalysisValue item, bool canMutate = true) {
                bool dummy;
                return Add(item, out dummy, canMutate);
            }

            public IAnalysisSet Add(AnalysisValue item, out bool wasChanged, bool canMutate = true) {
                var set = Set;
                if (canMutate) {
                    if (set.Add(item)) {
                        wasChanged = true;
                        return this;
                    }
                } else if (!set.Contains(item)) {
                    set = new HashSet<AnalysisValue>(set, set.Comparer);
                    wasChanged = set.Add(item);
                    return wasChanged ? new AnalysisSetManyUnion(set) : this;
                } else {
                    set = new HashSet<AnalysisValue>(set, set.Comparer);
                }

                var cmp = Comparer;
                var newItem = item;
                bool newItemAlreadyInSet = false;
                foreach (var ns in Set) {
                    if (cmp.Equals(ns, newItem)) {
                        bool changed = false;
                        newItem = cmp.MergeTypes(ns, newItem, out changed);
                        newItemAlreadyInSet = !changed;
                    }
                }
                if (!newItemAlreadyInSet) {
                    wasChanged = (set.RemoveWhere(ns => cmp.Equals(ns, newItem)) > 0);
                    wasChanged |= set.Add(newItem);
                } else {
                    wasChanged = (set.RemoveWhere(ns => !Object.ReferenceEquals(ns, newItem) && cmp.Equals(ns, newItem)) > 0);
                }

                return (canMutate | !wasChanged) ? this : new AnalysisSetManyUnion(set);
            }

            public IAnalysisSet Union(IEnumerable<AnalysisValue> items, bool canMutate = true) {
                if (items == null) {
                    return this;
                }
                bool anyAdded = false;
                var cmp = Comparer;
                var set = canMutate ? Set : new HashSet<AnalysisValue>(Set, Set.Comparer);
                foreach (var item in items) {
                    if (set.Add(item)) {
                        anyAdded = true;
                    } else {
                        bool dummy;
                        var newItem = item;
                        foreach (var ns in set) {
                            if (Object.ReferenceEquals(ns, newItem)) {
                                return this;
                            }
                            if (cmp.Equals(ns, newItem)) {
                                newItem = cmp.MergeTypes(ns, newItem, out dummy);
                            }
                        }
                        set.RemoveWhere(ns => cmp.Equals(ns, newItem));
                        set.Add(newItem);
                    }
                }
                return (canMutate | !anyAdded) ? this : new AnalysisSetManyUnion(set);
            }

            public IAnalysisSet Union(IEnumerable<AnalysisValue> items, out bool wasChanged, bool canMutate = true) {
                if (items == null) {
                    wasChanged = false;
                    return this;
                } 
                bool anyAdded = false;
                var cmp = Comparer;
                var set = canMutate ? Set : new HashSet<AnalysisValue>(Set, Set.Comparer);
                wasChanged = false;
                foreach (var item in items) {
                    if (set.Add(item)) {
                        anyAdded = true;
                    } else {
                        bool changed = false;
                        var newItem = item;
                        foreach (var ns in set) {
                            if (Object.ReferenceEquals(ns, newItem)) {
                                return this;
                            }
                            if (cmp.Equals(ns, newItem)) {
                                newItem = cmp.MergeTypes(ns, newItem, out changed);
                            }
                        }
                        int removed = set.RemoveWhere(ns => cmp.Equals(ns, newItem));
                        set.Add(newItem);
                        anyAdded |= (removed > 1) | changed;
                    }
                }
                wasChanged = anyAdded;
                return (canMutate | !anyAdded) ? this : new AnalysisSetManyUnion(set);
            }

            public IAnalysisSet Clone() {
                switch (Set.Count) {
                    case 0:
                        return AnalysisSetEmptyUnion.Instances[Comparer.Strength];
                    case 1:
                        return new AnalysisSetOneUnion(Set.First(), Comparer);
                    case 2: {
                            var tup = AnalysisSetTwoUnion.FromEnumerable(Set, Comparer);
                            if (tup == null) {
                                return new AnalysisSetManyUnion(Set, Comparer);
                            } else if (tup.Item1 == null && tup.Item2 == null) {
                                return AnalysisSetEmptyUnion.Instances[Comparer.Strength];
                            } else if (tup.Item2 == null) {
                                return new AnalysisSetOneUnion(tup.Item1, Comparer);
                            } else {
                                return new AnalysisSetTwoUnion(tup.Item1, tup.Item2, Comparer);
                            }
                        }
                    default:
                        return new AnalysisSetManyUnion(Set, Comparer);
                }
            }

            public bool Contains(AnalysisValue item) {
                return Set.Contains(item);
            }

            public bool SetEquals(IAnalysisSet other) {
                if (other == null) {
                    return false;
                }
                foreach (var ns in Set) {
                    if (!other.Contains(ns, Comparer)) {
                        return false;
                    }
                }
                if (other.Comparer != Comparer) {
                    foreach (var ns in Set) {
                        if (!other.Contains(ns, Comparer)) {
                            return false;
                        }
                    }
                }
                return true;
            }

            public int Count {
                get { return Set.Count; }
            }

            public IEnumerator<AnalysisValue> GetEnumerator() {
                return Set.GetEnumerator();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
                return Set.GetEnumerator();
            }

            internal UnionComparer Comparer {
                get { return (UnionComparer)Set.Comparer; }
            }

            IEqualityComparer<AnalysisValue> IAnalysisSet.Comparer {
                get { return Set.Comparer; }
            }

            public override string ToString() {
                return DebugViewProxy.ToString(this);
            }
        }

        [DebuggerDisplay(DebugViewProxy.DisplayString), DebuggerTypeProxy(typeof(DebugViewProxy))]
        sealed class AnalysisSetEmptyUnion : IAnalysisSet {
            public static readonly IAnalysisSet[] Instances = UnionComparer.Instances.Select(cmp => new AnalysisSetEmptyUnion(cmp)).ToArray();

            private readonly UnionComparer _comparer;

            public AnalysisSetEmptyUnion(UnionComparer comparer) {
                _comparer = comparer;
            }

            public IAnalysisSet Add(AnalysisValue item, bool canMutate = true) {
                return new AnalysisSetOneUnion(item, Comparer);
            }

            public IAnalysisSet Add(AnalysisValue item, out bool wasChanged, bool canMutate = true) {
                wasChanged = true;
                return new AnalysisSetOneUnion(item, Comparer);
            }

            public IAnalysisSet Union(IEnumerable<AnalysisValue> items, bool canMutate = true) {
                if (items == null) {
                    return this;
                } else if (items is AnalysisSetOneUnion || items is AnalysisSetTwoUnion || items is AnalysisSetEmptyUnion) {
                    return (IAnalysisSet)items;
                }
                return items.Any() ? AnalysisSet.CreateUnion(items, Comparer) : this;
            }

            public IAnalysisSet Union(IEnumerable<AnalysisValue> items, out bool wasChanged, bool canMutate = true) {
                if (items == null || items is AnalysisSetEmptyObject || items is AnalysisSetEmptyUnion) {
                    wasChanged = false;
                    return this;
                }
                if (items is AnalysisSetOneUnion || items is AnalysisSetTwoUnion) {
                    wasChanged = true;
                    return (IAnalysisSet)items;
                }
                wasChanged = items.Any();
                return wasChanged ? AnalysisSet.CreateUnion(items, Comparer) : this;
            }

            public IAnalysisSet Clone() {
                return this;
            }

            public bool Contains(AnalysisValue item) {
                return false;
            }

            public bool SetEquals(IAnalysisSet other) {
                return other != null && other.Count == 0;
            }

            public int Count {
                get { return 0; }
            }

            public IEnumerator<AnalysisValue> GetEnumerator() {
                yield break;
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
                return GetEnumerator();
            }

            internal UnionComparer Comparer {
                get { return _comparer; }
            }

            IEqualityComparer<AnalysisValue> IAnalysisSet.Comparer {
                get { return ((AnalysisSetEmptyUnion)this).Comparer; }
            }

            public override string ToString() {
                return DebugViewProxy.ToString(this);
            }
        }

        [DebuggerDisplay(DebugViewProxy.DisplayString), DebuggerTypeProxy(typeof(DebugViewProxy))]
        sealed class AnalysisSetOneUnion : IAnalysisSet {
            public readonly AnalysisValue Value;
            private readonly UnionComparer _comparer;

            public AnalysisSetOneUnion(AnalysisValue value, UnionComparer comparer) {
                Value = value;
                _comparer = comparer;
            }

            public IAnalysisSet Add(AnalysisValue item, bool canMutate = true) {
                if (Object.ReferenceEquals(Value, item)) {
                    return this;
                } else if (Comparer.Equals(Value, item)) {
                    bool wasChanged;
                    var newItem = Comparer.MergeTypes(Value, item, out wasChanged);
                    return wasChanged ? new AnalysisSetOneUnion(newItem, Comparer) : this;
                } else {
                    return new AnalysisSetTwoUnion(Value, item, Comparer);
                }
            }

            public IAnalysisSet Add(AnalysisValue item, out bool wasChanged, bool canMutate = true) {
                if (Object.ReferenceEquals(Value, item)) {
                    wasChanged = false;
                    return this;
                } else if (Comparer.Equals(Value, item)) {
                    var newItem = Comparer.MergeTypes(Value, item, out wasChanged);
                    return wasChanged ? new AnalysisSetOneUnion(newItem, Comparer) : this;
                } else {
                    wasChanged = true;
                    return new AnalysisSetTwoUnion(Value, item, Comparer);
                }
            }

            public IAnalysisSet Union(IEnumerable<AnalysisValue> items, bool canMutate = true) {
                AnalysisValue ns;
                AnalysisSetOneUnion ns1;
                AnalysisSetOneObject nsO1;
                AnalysisSetTwoUnion ns2;
                if (items == null) {
                    return this;
                } else if ((ns = items as AnalysisValue) != null) {
                    return Add(ns, canMutate);
                } else if ((ns1 = items as AnalysisSetOneUnion) != null) {
                    return Add(ns1.Value, canMutate);
                } else if ((nsO1 = items as AnalysisSetOneObject) != null) {
                    return Add(nsO1.Value, canMutate);
                } else if ((ns2 = items as AnalysisSetTwoUnion) != null && ns2.Comparer == Comparer) {
                    return ns2.Add(Value, false);
                } else {
                    return new AnalysisSetManyUnion(items, Comparer).Add(Value).Trim();
                }
            }

            public IAnalysisSet Union(IEnumerable<AnalysisValue> items, out bool wasChanged, bool canMutate = true) {
                AnalysisValue ns;
                AnalysisSetOneUnion ns1;
                AnalysisSetOneObject nsO1;
                AnalysisSetTwoUnion ns2;
                if (items == null) {
                    wasChanged = false;
                    return this;
                } else if ((ns = items as AnalysisValue) != null) {
                    return Add(ns, out wasChanged, canMutate);
                } else if ((ns1 = items as AnalysisSetOneUnion) != null) {
                    return Add(ns1.Value, out wasChanged, canMutate);
                } else if ((nsO1 = items as AnalysisSetOneObject) != null) {
                    return Add(nsO1.Value, out wasChanged, canMutate);
                } else if ((ns2 = items as AnalysisSetTwoUnion) != null && ns2.Comparer == Comparer) {
                    return ns2.Add(Value, out wasChanged, false);
                } else {
                    return new AnalysisSetManyUnion(Value, Comparer).Union(items, out wasChanged).Trim();
                }
            }

            public IAnalysisSet Clone() {
                return this;
            }

            public bool Contains(AnalysisValue item) {
                return Comparer.Equals(Value, item);
            }

            public bool SetEquals(IAnalysisSet other) {
                var ns1 = other as AnalysisSetOneUnion;
                if (ns1 != null) {
                    return Comparer.Equals(Value, ns1.Value);
                } else if (other == null) {
                    return false;
                } else if (other.Count == 1) {
                    return Comparer.Equals(Value, other.First());
                } else {
                    return other.All(ns => Comparer.Equals(ns, Value));
                }
            }

            public int Count {
                get { return 1; }
            }

            public IEnumerator<AnalysisValue> GetEnumerator() {
                return new SetOfOneEnumerator<AnalysisValue>(Value);
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
                return GetEnumerator();
            }

            internal UnionComparer Comparer {
                get { return _comparer; }
            }

            IEqualityComparer<AnalysisValue> IAnalysisSet.Comparer {
                get { return ((AnalysisSetOneUnion)this).Comparer; }
            }

            public override string ToString() {
                return DebugViewProxy.ToString(this);
            }
        }

        [DebuggerDisplay(DebugViewProxy.DisplayString), DebuggerTypeProxy(typeof(DebugViewProxy))]
        sealed class AnalysisSetTwoUnion : IAnalysisSet {
            public readonly AnalysisValue Value1, Value2;
            private readonly UnionComparer _comparer;

            public AnalysisSetTwoUnion(AnalysisValue value1, AnalysisValue value2, UnionComparer comparer) {
                Debug.Assert(!comparer.Equals(value1, value2));
                Value1 = value1;
                Value2 = value2;
                _comparer = comparer;
            }

            internal static Tuple<AnalysisValue, AnalysisValue> FromEnumerable(IEnumerable<AnalysisValue> set, UnionComparer comparer) {
                using (var e = set.GetEnumerator()) {
                    if (!e.MoveNext()) {
                        return new Tuple<AnalysisValue, AnalysisValue>(null, null);
                    }
                    var value1 = e.Current;
                    if (!e.MoveNext()) {
                        return new Tuple<AnalysisValue, AnalysisValue>(value1, null);
                    }
                    var value2 = e.Current;
                    if (comparer.Equals(e.Current, value1)) {
                        bool dummy;
                        return new Tuple<AnalysisValue, AnalysisValue>(comparer.MergeTypes(value1, value2, out dummy), null);
                    }
                    if (e.MoveNext()) {
                        return null;
                    }
                    return new Tuple<AnalysisValue, AnalysisValue>(value1, value2);
                }
            }

            public AnalysisSetTwoUnion(IEnumerable<AnalysisValue> set, UnionComparer comparer) {
                _comparer = comparer;
                var tup = FromEnumerable(set, comparer);
                if (tup == null || tup.Item2 == null) {
                    throw new InvalidOperationException("Sequence requires exactly two values");
                }
                Value1 = tup.Item1;
                Value2 = tup.Item2;
            }

            public IAnalysisSet Add(AnalysisValue item, bool canMutate = true) {
                bool dummy;
                return Add(item, out dummy, canMutate);
            }

            public IAnalysisSet Add(AnalysisValue item, out bool wasChanged, bool canMutate = true) {
                bool dummy;
                if (Object.ReferenceEquals(Value1, item) || Object.ReferenceEquals(Value2, item)) {
                    wasChanged = false;
                    return this;
                } else if (Comparer.Equals(Value1, item)) {
                    var newValue = Comparer.MergeTypes(Value1, item, out wasChanged);
                    if (!wasChanged) {
                        return this;
                    }
                    if (Comparer.Equals(Value2, newValue)) {
                        return new AnalysisSetOneUnion(Comparer.MergeTypes(Value2, newValue, out dummy), Comparer);
                    } else {
                        return new AnalysisSetTwoUnion(newValue, Value2, Comparer);
                    }
                } else if (Comparer.Equals(Value2, item)) {
                    var newValue = Comparer.MergeTypes(Value2, item, out wasChanged);
                    if (!wasChanged) {
                        return this;
                    }
                    if (Comparer.Equals(Value1, newValue)) {
                        return new AnalysisSetOneUnion(Comparer.MergeTypes(Value1, newValue, out dummy), Comparer);
                    } else {
                        return new AnalysisSetTwoUnion(Value1, newValue, Comparer);
                    }
                }
                wasChanged = true;
                return new AnalysisSetManyUnion(this, item, Comparer, out dummy);
            }

            public IAnalysisSet Union(IEnumerable<AnalysisValue> items, bool canMutate = true) {
                AnalysisValue ns;
                AnalysisSetOneObject ns1o;
                AnalysisSetOneUnion ns1u;
                if (items == null) {
                    return this;
                } else if ((ns = items as AnalysisValue) != null) {
                    return Add(ns, canMutate);
                } else if ((ns1o = items as AnalysisSetOneObject) != null) {
                    return Add(ns1o.Value, canMutate);
                } else if ((ns1u = items as AnalysisSetOneUnion) != null) {
                    return Add(ns1u.Value, canMutate);
                } else {
                    return new AnalysisSetManyUnion(this, Comparer).Union(items);
                }
            }

            public IAnalysisSet Union(IEnumerable<AnalysisValue> items, out bool wasChanged, bool canMutate = true) {
                AnalysisValue ns;
                AnalysisSetOneObject ns1o;
                AnalysisSetOneUnion ns1u;
                if (items == null) {
                    wasChanged = false;
                    return this;
                } else if ((ns = items as AnalysisValue) != null) {
                    return Add(ns, out wasChanged, canMutate);
                } else if ((ns1o = items as AnalysisSetOneObject) != null) {
                    return Add(ns1o.Value, out wasChanged, canMutate);
                } else if ((ns1u = items as AnalysisSetOneUnion) != null) {
                    return Add(ns1u.Value, out wasChanged, canMutate);
                } else {
                    return new AnalysisSetManyUnion(this, Comparer).Union(items, out wasChanged);
                }
            }

            public IAnalysisSet Clone() {
                return this;
            }

            public bool Contains(AnalysisValue item) {
                return Comparer.Equals(Value1, item) || Comparer.Equals(Value2, item);
            }

            public bool SetEquals(IAnalysisSet other) {
                var ns2 = other as AnalysisSetTwoUnion;
                if (ns2 != null) {
                    return Comparer.Equals(Value1, ns2.Value1) && Comparer.Equals(Value2, ns2.Value2) ||
                        Comparer.Equals(Value1, ns2.Value2) && Comparer.Equals(Value2, ns2.Value1);
                } else if (other != null) {
                    return other.All(ns => Comparer.Equals(Value1) || Comparer.Equals(Value2));
                } else {
                    return false;
                }
            }

            public int Count {
                get { return 2; }
            }

            public IEnumerator<AnalysisValue> GetEnumerator() {
                yield return Value1;
                yield return Value2;
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
                return GetEnumerator();
            }

            internal UnionComparer Comparer {
                get { return _comparer; }
            }

            IEqualityComparer<AnalysisValue> IAnalysisSet.Comparer {
                get { return ((AnalysisSetTwoUnion)this).Comparer; }
            }

            public override string ToString() {
                return DebugViewProxy.ToString(this);
            }
        }

    }

}
