using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
static class Module1
{
	public static List<string[]> Subsets(string[] Input)
	{
		List<string[]> Out = new List<string[]>();

		foreach (void Item_loopVariable in Input) {
			Item = Item_loopVariable;
			Out.Add({ Item });
		}

		dynamic e = Input.Length;
		dynamic x = 0;
		dynamic y = 0;
		dynamic l = e;
		dynamic i = 0;

		string Ty = null;
		//Tempolary index y object relation.
		List<string> Tl = new List<string>();
		//Tempolary index l object relation
		string[] Ti = null;
		//Tempolary index i object relation


		while (x < e) {
			while (i < l) {
				while (y < e) {
					Ty = FileSystem.Input(y);
					Ti = Out(i);
					if (NotIn(Ti, Ty)) {
						Tl.AddRange(Ti);
						Tl.Add(Ty);
						if (NotSame(Out, Tl.ToArray))
							Out.Add(Tl.ToArray);
						Tl.Clear();
					}
					y += 1;
				}
				i += 1;
				y = 0;
			}
			y = 0;
			i = l;
			l = Out.Count;
			x += 1;
		}

		return Out;
	}

	public static bool NotIn(string[] Host, string Input)
	{
		foreach (void Item_loopVariable in Host) {
			Item = Item_loopVariable;
			if (object.ReferenceEquals(Item, Input))
				return false;
		}
		return true;
	}

	public static bool NotSame(List<string[]> Input, string[] Target)
	{
		dynamic count = Target.Length;

		foreach (void Item_loopVariable in Input) {
			Item = Item_loopVariable;
			if (Item.Length == count) {
				dynamic Same = 0;

				//A member
				foreach (void AM_loopVariable in Item) {
					AM = AM_loopVariable;
					//B member
					foreach (void BM_loopVariable in Target) {
						BM = BM_loopVariable;
						if (object.ReferenceEquals(AM, BM))
							Same += 1;
					}
				}

				if (Same == count)
					return false;
			}
		}
		return true;
	}

	public static List<int[]> SubSum(List<int[]> Input, int Target)
	{
		List<int[]> Out = new List<int[]>();

		foreach (void Item_loopVariable in Input) {
			Item = Item_loopVariable;
			if (Item.Sum == Target)
				Out.Add(Item);
		}

		return Out;
	}

	public static List<int[]> ToInts(List<string[]> Input)
	{
		List<int[]> Out = new List<int[]>();
		List<int> Tmp = new List<int>();

		foreach (void Item_loopVariable in Input) {
			Item = Item_loopVariable;
			foreach (void mem_loopVariable in Item) {
				mem = mem_loopVariable;
				Tmp.Add(Convert.ToInt32(mem));
			}

			Out.Add(Tmp.ToArray);
			Tmp.Clear();
		}

		return Out;
	}

	public static void Main()
	{
		Console.WriteLine("===========================================================================");
		Console.WriteLine("Input example : number1 number2 number3 ... numberN");
		Console.WriteLine("5 5 6 8 8 12 8 10");
		Console.WriteLine("After input all value then press Enter for get subsets that sum equal to 40.");
		Console.WriteLine("===========================================================================");
		do {
			dynamic Txt_In = Console.ReadLine;

			if (string.IsNullOrEmpty(Txt_In)) {
				Console.WriteLine("===========================================================================");
				continue;
			}

			dynamic Input = Subsets(Txt_In.Split(" "));
			dynamic Out = SubSum(ToInts(Input), 40);

			Console.WriteLine("===========================================================================");

			foreach (void Item_loopVariable in Out) {
				Item = Item_loopVariable;
				Console.WriteLine(string.Join(",", Item));
			}

			Console.WriteLine("===========================================================================");

		} while (true);
	}

}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
