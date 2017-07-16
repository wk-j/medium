using System;

public class C {
    object o;
    public void M1(int p) {
        int l = 123;
        Action a = () => o = (p + 1);
    }

    public void M2(int p) {
        int l = 123;
        void a() {
            o = (p + l);
        }
    }
}