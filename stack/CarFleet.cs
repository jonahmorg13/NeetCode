using System.Diagnostics;

int CarFleet(int target, int[] position, int[] speed) {
    int[][] pair = new int[position.Length][];
    for (int i = 0; i < position.Length; i++) {
        pair[i] = new int[] { position[i], speed[i] };
    }
    Array.Sort(pair, (a, b) => b[0].CompareTo(a[0]));
    Stack<double> stack = new Stack<double>();
    foreach (var p in pair) {
        stack.Push((double)(target - p[0]) / p[1]);
        if (stack.Count >= 2 && stack.Peek() <= stack.ElementAt(1)) {
            stack.Pop();
        }
    }
    return stack.Count;
}

Debug.Assert(CarFleet(10, [1,4], [3,2]) == 1);
Debug.Assert(CarFleet(10, [4,1,0,7], [2,2,1,1]) == 3);