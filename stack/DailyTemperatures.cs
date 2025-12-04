using System.Diagnostics;

int[] DailyTemperatures(int[] temperatures)
{
    var tempCount = temperatures.Count();
    var result = new int[tempCount];
    var stack = new Stack<Tuple<int, int>>();

    for(int i = 0; i < tempCount; i++)
    {
        while(stack.Count() > 0 && temperatures[i] > stack.Peek().Item1)
        {
            var tuple = stack.Pop();
            result[tuple.Item2] = i - tuple.Item2;
        }
        stack.Push(new Tuple<int, int>(temperatures[i], i));
    }

    return result;
}

Debug.Assert(DailyTemperatures([22,21,20]).SequenceEqual([0,0,0]));

