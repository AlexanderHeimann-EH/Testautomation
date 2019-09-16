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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.PythonTools.EnvironmentsList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestUtilities;

namespace PythonToolsTests {
    [TestClass]
    public class Pep440VersionTests {
        // All of these versions should be parseable and appear in the correct
        // order. They do not have to be normalized.
        private static readonly string[] ExampleVersions = @"
0.9
1.0a1
1.0a2.dev456
1.0a12.dev456
1.0a12
v1.0b1.dev456
1.0b2
1.0b2.post345.dev456
1.0b2.post345
1.0rc1.dev456
v1.0rc1
1.0.dev1
1.0.dev2
1.0.dev3
1.0.dev4
1.0.dev456
1.0
1.0+abc.5
1.0+abc.7
1.0+5
1.0.post1
1.0.post456.dev34
1.0.post456
1.1a1
1.1.dev1
2012.1
2012.2a3
2012.2
v2012.3
2012.15
2013.1
2013.2
1!0.0.1
".Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        // The first version on each line should be fully normalized. '==' is
        // used as a separator only - don't use other comparisons here.
        private static readonly string[] ExampleNormalizedVersions = @"
0.9 == v0.9 == 0!0.9 == 0.9dev0
1.0a1 == 1.0-a1 == 1.0_a1 == 1.0a_1
v1.0b1.dev456
1.0b2
1.0rc1.dev456 == 1.0c01.post0_dev_456
v1.0rc1 == 1.0rc1 == 1.0c1 == 1.0_pre1 == 1.0preview-1
1.0.dev1 == 1.0-dev-1 == 1.0dev_1
1.0 == 1.0post0 == 1.0dev0 == 0!1.0
1.0.0 == 01.00.0000
1.0+abc.5 == 1.0+abc.5 == 1.0+abc-5
1.0.post1 == 1.0-post01
1!1.0 == 01!1.0
".Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        [TestMethod]
        public void VersionParsing() {
            foreach (var s in ExampleVersions) {
                Pep440Version ver;
                Assert.IsTrue(Pep440Version.TryParse(s, out ver), s);
                Assert.AreEqual(s, ver.OriginalForm);
            }
        }

        [TestMethod]
        public void VersionOrdering() {
            var versions = ExampleVersions.Select(Pep440Version.Parse).ToList();
            var rnd = new Random();
            var shuffled = versions
                .Select(v => new { K = rnd.NextDouble(), V = v })
                .OrderBy(i => i.K)
                .Select(i => i.V)
                .ToList();
            var reversed = versions.AsEnumerable().Reverse().ToList();

            foreach (var src in new[] { shuffled, reversed }) {
                var sorted = src.OrderBy(v => v).ToList();

                foreach (var p in versions.Zip(sorted, Tuple.Create<Pep440Version, Pep440Version>)) {
                    Console.WriteLine("{0} {1} {2}", p.Item1, p.Item1.Equals(p.Item2) ? "==" : "!=", p.Item2);
                }
                AssertUtil.ArrayEquals(versions, sorted);
            }
        }

        [TestMethod]
        public void VersionNormalization() {
            foreach (var line in ExampleNormalizedVersions) {
                var versions = line.Split(new[] { "==" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(Pep440Version.Parse)
                    .ToList();

                Console.WriteLine(line);
                foreach (var v in versions.Skip(1)) {
                    Assert.AreEqual(versions[0].NormalizedForm, v.NormalizedForm, v.OriginalForm);
                }
            }
        }

        [TestMethod]
        public void LocalVersionEquality() {
            // Numeric sections of local versions are compared (but not
            // normalized!) as integers.
            AreVersionsEqual("1.0+1", "1.0+01");
            AreVersionsEqual("1.0+a.1", "1.0+a.01");
            AreVersionsEqual("1.0+a-1", "1.0+a_01");
            AreVersionsNotEqual("1.0+a1", "1.0+a01");
        }

        private static void AreVersionsEqual(string expected, string actual) {
            Pep440Version v1, v2;
            Assert.IsTrue(Pep440Version.TryParse(expected, out v1), expected);
            Assert.IsTrue(Pep440Version.TryParse(actual, out v2), actual);
            Assert.IsTrue(v1.Equals(v2),
                string.Format(
                    "{0} != {1} ({2} != {3})",
                    v1.OriginalForm, v2.OriginalForm, v1.NormalizedForm, v2.NormalizedForm
                )
            );
        }

        private static void AreVersionsNotEqual(string expected, string actual) {
            Pep440Version v1, v2;
            Assert.IsTrue(Pep440Version.TryParse(expected, out v1), expected);
            Assert.IsTrue(Pep440Version.TryParse(actual, out v2), actual);
            Assert.IsFalse(v1.Equals(v2),
                string.Format(
                    "{0} == {1} ({2} == {3})",
                    v1.OriginalForm, v2.OriginalForm, v1.NormalizedForm, v2.NormalizedForm
                )
            );
        }
    }
}
