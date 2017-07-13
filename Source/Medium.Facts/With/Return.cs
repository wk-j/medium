using Xunit;
using System;


namespace KKKK { 
    public class Province {
        public string Name { set;get;}
    }
    public class Address {
        public Province Province  { set;get;}
    }

    public class Person {
        public Address Address { set;get;}
    }


    public static class ObjectExtensions {
        public static Tr With<Ts,Tr>(this Ts o, Func<Ts,Tr> func) 
            where Tr : class where Ts : class  => o == null ? null : func(o);

        public static Tr Return<Ts,Tr>(this Ts o, Func<Ts, Tr> func, Tr value) 
            where Tr : class where Ts : class  { 
                Console.WriteLine($" >>> {o} ===");
                return o == null ? value : func(o);
            }
    }

    public class Tx {
        [Fact]
        public void Test() {

            T id<T>(T v) => v;

            string s = null;
            var ans = s.Return(id, "Foo").Return(id, null).Return(id, "Bar");
            Assert.Equal("Foo", ans);

            var p = new Person();

            var ans2 = p.With(x => x.Address).With(x => x.Province).Return(x => x.Name, "Bangkok");
            Assert.Equal("Bangkok", ans2);

            var ans3 = p?.Address?.Province?.Name ?? "Bangkok";
            Assert.Equal("Bangkok", ans2);
        }
    }
}