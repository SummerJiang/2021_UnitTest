using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MyWhereTest
{
    public class MyWhereLibTest
    {
        [Test]
        public void Where_Adult()
        {
            var people = new List<Person>
            {
                new Person {Name = "James", Age = 17},
                new Person {Name = "CC", Age = 19},
                new Person {Name = "Frank", Age = 20}
            };
            var expected = new List<Person>
            {
                new Person {Name = "CC", Age = 19},
                new Person {Name = "Frank", Age = 20}
            };
            Assert.AreEqual(expected, people.HiWhere(person => person.Age >= 18));
        }

        [Test]
        public void Where_Name_Has_a()
        {
            var people = new List<Person>
            {
                new Person {Name = "James", Age = 17},
                new Person {Name = "CC", Age = 19},
                new Person {Name = "Frank", Age = 20}
            };
            var expected = new List<Person>
            {
                new Person {Name = "James", Age = 17},
                new Person {Name = "Frank", Age = 20}
            };
            Assert.AreEqual(expected, people.HiWhere(person => person.Name.Contains("a")));
        }

        [Test]
        public void Where_numbers_should_more_than_3()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            var expected = new[] { 4, 5 };
            Assert.AreEqual(expected, numbers.HiWhere(number => number > 3));
        }

        [Test]
        public void Select_Output_Same()
        {
            var people = new List<Person>
            {
                new Person {Name = "James", Age = 17},
                new Person {Name = "CC", Age = 19},
                new Person {Name = "Frank", Age = 20}
            };
            var expected = new List<Person>
            {
                new Person {Name = "James", Age = 17},
                new Person {Name = "CC", Age = 19},
                new Person {Name = "Frank", Age = 20}
            };
            Assert.AreEqual(expected, people.HiSelect(person => person));
        }

        [Test]
        public void Select_Age()
        {
            var people = new List<Person>
            {
                new Person {Name = "James", Age = 17},
                new Person {Name = "CC", Age = 19},
                new Person {Name = "Frank", Age = 20}
            };
            var expected = new List<Person>
            {
                new Person {Age = 17},
                new Person {Age = 19},
                new Person {Age = 20}
            };
            Assert.AreEqual(expected, people.HiSelect(person => new Person { Age = person.Age }));
        }

        [Test]
        public void Select_Name()
        {
            var people = new List<Person>
            {
                new Person {Name = "James", Age = 17},
                new Person {Name = "CC", Age = 19},
                new Person {Name = "Frank", Age = 20}
            };
            var expected = new List<Person>
            {
                new Person {Name = "James"},
                new Person {Name = "CC"},
                new Person {Name = "Frank"}
            };
            Assert.AreEqual(expected, people.HiSelect(person => new Person {Name= person.Name }));
        }

        [Test]
        public void Select_doublenumber()
        {
            var numbers = new[] { 1, 2, 3 };
            var expected = new[] { 1,4, 9 };
            Assert.AreEqual(expected, numbers.HiSelect(number => number * number));
        }

    }

    public struct Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public static class MyWhere
    {
        public static IEnumerable<T> HiWhere<T>(this IEnumerable<T> source, Func<T, bool> condition)
        {
            foreach (var s in source)
                if (condition(s))
                    yield return s;
        }
    }

    public static class MySelect
    {
        public static IEnumerable<T> HiSelect<T>(this IEnumerable<T> source, Func<T, T> selector)
        {
            foreach (var s in source)
                    yield return selector(s);
        }
    }
}