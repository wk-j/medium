เริ่มจากการคอมไพล์ก่อนใน C#

```csharp
        static string trya(A A) {
            string ans;
            try { ans = A.B.C.D; } catch { ans = "OUT"; }
            return ans; }
        }
```

คอมไพล์ออกมาเป็น...


```csharp
.method private hidebysig static string  trya(class ConsoleApp1.A A) cil managed
{
  // Code size       30 (0x1e)
  .maxstack  1
  .locals init ([0] string ans)
  .try
  {
    IL_0000:  ldarg.0
    IL_0001:  callvirt   instance class ConsoleApp1.B ConsoleApp1.A::get_B()
    IL_0006:  callvirt   instance class ConsoleApp1.C ConsoleApp1.B::get_C()
    IL_000b:  callvirt   instance string ConsoleApp1.C::get_D()
    IL_0010:  stloc.0
    IL_0011:  leave.s    IL_001c
  }  // end .try
  catch [mscorlib]System.Exception 
  {
    IL_0013:  pop
    IL_0014:  ldstr      "OUT"
    IL_0019:  stloc.0
    IL_001a:  leave.s    IL_001c
  }  // end handler
  IL_001c:  ldloc.0
  IL_001d:  ret
} // end of method Program::trya
```

ทีนี้เรามาลองดูทางด้าน VB กันบ้าง

```vb
    Function trya(a As a) As String
        Dim ans As String
        Try : ans = a.b.c.d
        Catch : ans = "out"
        End Try
        Return ans
    End Function
```

คอมไพล์ออกมาได้...


```csharp
.method public static string  trya(class ConsoleApp2.a a) cil managed
{
  // Code size       39 (0x27)
  .maxstack  1
  .locals init ([0] string ans)
  .try
  {
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class ConsoleApp2.b ConsoleApp2.a::b
    IL_0006:  ldfld      class ConsoleApp2.c ConsoleApp2.b::c
    IL_000b:  ldfld      string ConsoleApp2.c::d
    IL_0010:  stloc.0
    IL_0011:  leave.s    IL_0025
  }  // end .try
  catch [mscorlib]System.Exception 
  {
    IL_0013:  call       void [Microsoft.VisualBasic]Microsoft.VisualBasic.CompilerServices.ProjectData::SetProjectError(class [mscorlib]System.Exception)
    IL_0018:  ldstr      "out"
    IL_001d:  stloc.0
    IL_001e:  call       void [Microsoft.VisualBasic]Microsoft.VisualBasic.CompilerServices.ProjectData::ClearProjectError()
    IL_0023:  leave.s    IL_0025
  }  // end handler
  IL_0025:  ldloc.0
  IL_0026:  ret
} // end of method Module1::trya
```

จะเห็นได้ว่าแทนที่จะ pop ค่า exception ทิ้งออกเหมือน C# คอมไพล์ของ VB นั้นมี method เฉพาะสำหรับการจัดการแทนซึ่งจะว่าไป VB นั้นมักจะมี method งุบงิบพวกนี้เสมอ
แต่ถ้าเขียน il เองแล้วนั้นผมคงเลือกที่จะ pop ทิ้งเอามากกว่า

```csharp
        .method public static string  trya(class ConsoleApplication1.a a) cil managed
	{
		.maxstack  1
		.locals init ([0] string ans)
		.try {
			ldarg.0
			ldfld      class ConsoleApplication1.b ConsoleApplication1.a::b
			ldfld      class ConsoleApplication1.c ConsoleApplication1.b::c
			ldfld      string ConsoleApplication1.c::d
			stloc.0
			leave.s exit
		} 
		catch [mscorlib]System.Exception {
			pop
			ldstr      "out"
			stloc.0
		}
		exit:
		ldloc.0
		ret
	}
```

อย่างไรก็ดีความน่าสนใจมันอยู่ตรงที่ .try นั้นมีลักษณะเหมือน sub stack frame ซึ่งสามารถโหลดค่าจาก variant ของ method stack เข้าไปได้แต่ภายใน sub stack นี้นั้นจะแยกออกต่างหากเป็นเอกเทศซึ่งการส่งค่าเข้าออกระหว่างกันนั้นจะต้องใช้ variant เป็นตัวนำส่งไปไม่สามารถรับค่าจาก method stack ได้โดยตรง และ ไม่สามารถทิ้งค่าเหลือเอาไว้ใน sub stack นี้ได้เมื่อจบ stack นั้นๆ
ที่น่าสนใจอีกอย่างคือเมื่อคอมไพล์ใน release mode นั้น try finally จะถูกกำจัดออกอย่างหมดจดโดยคอมไพล์เลอร์อัตโนมัติทั้ง 2 ภาษา และแม้จะคอมไพล์ใน debug mode ซึ่งไม่กำจัด try finally ออกแต่ใน clr ตัว runtime นั้นก็จะทำการกำจัด try finally ออกเองอยู่ดี ดังนี้ try finally โดยไม่มี catch นั้นได้ตายลงไปเป็นที่เรียบร้อยแล้วครับ