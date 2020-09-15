﻿using BenchmarkDotNet.Attributes;
using System;
using Towel;

namespace Towel_Benchmarking
{
	[Value(Program.Name, "Sorting Algorithms")]
	public class Sort_Benchmarks
	{
		[Params(10, 1000, 10000)] public int N;

		public int[] Values;

		[IterationSetup] public void IterationSetup()
		{
			Values = new int[N];
			Stepper.Iterate(N, i => Values[i] = i);
			Random random = new Random(7);
			random.Shuffle(Values);
		}

		[Benchmark] public void SystemArraySort() =>
			Array.Sort(Values);

		[Benchmark] public void SystemArraySortDelegate() =>
			Array.Sort(Values, (int a, int b) => a.CompareTo(b));

		[Benchmark] public void SystemArraySortIComparer() =>
			Array.Sort(Values, default(ComparerInt));

		[Benchmark] public void BubbleRunTime() =>
			Sort.Bubble(Values);

		[Benchmark] public void BubbleCompileTime() =>
			Sort.Bubble<int, CompareInt>(Values);

		[Benchmark] public void SelectionRunTime() =>
			Sort.Selection(Values);

		[Benchmark] public void SelectionCompileTime() =>
			Sort.Selection<int, CompareInt>(Values);

		[Benchmark] public void InsertionRunTime() =>
			Sort.Insertion(Values);

		[Benchmark] public void InsertionCompileTime() =>
			Sort.Insertion<int, CompareInt>(Values);

		[Benchmark] public void QuickRunTime() =>
			Sort.Quick(Values);

		[Benchmark] public void QuickCompileTime() =>
			Sort.Quick<int, CompareInt>(Values);

		[Benchmark] public void MergeRunTime() =>
			Sort.Merge(Values);

		[Benchmark] public void MergeCompileTime() =>
			Sort.Merge<int, CompareInt>(Values);

		[Benchmark] public void HeapRunTime() =>
			Sort.Heap(Values);

		[Benchmark] public void HeapCompileTime() =>
			Sort.Heap<int, CompareInt>(Values);

		[Benchmark] public void OddEvenRunTime() =>
			Sort.OddEven(Values);

		[Benchmark] public void OddEvenCompileTime() =>
			Sort.OddEven<int, CompareInt>(Values);

		[Benchmark] public void GnomeRunTime() =>
			Sort.Gnome(Values);

		[Benchmark] public void GnomeCompileTime() =>
			Sort.Gnome<int, CompareInt>(Values);

		[Benchmark] public void CombRunTime() =>
			Sort.Comb(Values);

		[Benchmark] public void CombCompileTime() =>
			Sort.Comb<int, CompareInt>(Values);

		[Benchmark] public void ShellRunTime() =>
			Sort.Shell(Values);

		[Benchmark] public void ShellCompileTime() =>
			Sort.Shell<int, CompareInt>(Values);

		[Benchmark] public void CocktailRunTime() =>
			Sort.Cocktail(Values);

		[Benchmark] public void CocktailCompileTime() =>
			Sort.Cocktail<int, CompareInt>(Values);

		[Benchmark] public void SlowRunTime()
		{
			if (Values.Length > 10)
			{
				throw new Exception("Too Slow.");
			}
			Sort.Slow(Values);
		}

		[Benchmark] public void SlowCompileTime()
		{
			if (Values.Length > 10)
			{
				throw new Exception("Too Slow.");
			}
			Sort.Slow<int, CompareInt>(Values);
		}

		[Benchmark] public void BogoRunTime()
		{
			if (Values.Length > 10)
			{
				throw new Exception("Too Slow.");
			}
			Sort.Bogo(Values);
		}

		[Benchmark] public void BogoCompileTime()
		{
			if (Values.Length > 10)
			{
				throw new Exception("Too Slow.");
			}
			Sort.Bogo<int, CompareInt>(Values);
		}

		public struct ComparerInt : System.Collections.Generic.IComparer<int>
		{
			public int Compare(int a, int b) => a.CompareTo(b);
		}
	}
}
