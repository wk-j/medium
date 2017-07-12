using Xunit;
using System;

namespace WP {
    public static class Ext {
        public static Tr Return<Ts,Tr>(this Ts o, Func<Ts, Tr> func, Tr value) 
            where Tr : class where Ts : class 
                => o == null ? value : func(o);
    }

    public class T {
        [Fact]
        public void Test() {
            T id<T>(T value) => value;
            string s = null;
            var ans = s.Return(id, "Foo").Return(id, null).Return(id, "Bar");
            var expected = "Foo";
            Assert.Equal(expected, ans);
        }
    }
}