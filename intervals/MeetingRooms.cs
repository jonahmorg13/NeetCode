using System.Diagnostics;

var sol = new Solution();

var res = sol.CanAttendMeetings([new Interval(0, 30),new Interval(5,10),new Interval(9, 15)]);
Debug.Assert(!res);

public class Interval {
    public int start, end;
    public Interval(int start, int end) {
        this.start = start;
        this.end = end;
    }
}


public class Solution {
    public bool CanAttendMeetings(List<Interval> intervals) {
        if(intervals.Count <= 1)
            return true;

        intervals = intervals.OrderBy(x => x.start).ToList();

        for(int i = 0; i < intervals.Count - 1; i++)
            if(intervals[i].end > intervals[i + 1].start) return false;

        return true;
    }
}
