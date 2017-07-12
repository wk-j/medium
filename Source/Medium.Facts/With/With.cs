using System;
using Xunit;

namespace X
{

    public static class ObjectExtensions
    {
        public static Tr With<Ts, Tr>(this Ts o, Func<Ts, Tr> func)
            where Tr : class where Ts : class => o == null ? null : func(o);
        public static Tr Return<Ts, Tr>(this Ts o, Func<Ts, Tr> func, Tr value)
            where Tr : class where Ts : class => o == null ? value : func(o);
    }

    public class Province
    {
        public string ThaiName { set; get; }
        public string EnglishName { set; get; }
    }

    public class Address
    {
        public Province Province { set; get; }
    }

    public class Person
    {
        public int Id { set; get; }
        public Address Address { set; get; }
    }

    public class WithFacts
    {
        [Fact]
        public void T()
        {
            var person = new Person { Address = new Address() };
            var name = person.With(x => x.Address).With(x => x.Province).With(x => x.ThaiName);
            Assert.Null(name);
        }

        [Fact]
        public void T2()
        {
            var person = new Person { Address = new Address() };
            var name = person.With(x => x.Address).With(x => x.Province).Return(x => x.ThaiName, "wk");
            Assert.Equal("wk", name);
        }

        public void T3()
        {
            T id<T>(T value) => value;
            string s = null;
            var ans = s.Return(id, "Foo");
            Assert.Equal("Foo", ans);
        }
    }
}