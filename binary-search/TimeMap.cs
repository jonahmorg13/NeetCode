using System.Diagnostics;

var timemap = new TimeMap();

timemap.Set("alice", "happy", 1);
timemap.Set("alice", "sad", 3);

public class TimeMap
{
    private Dictionary<string, List<Entry>> map;

    private class Entry
    {
        public string Value;
        public int Timestamp;

        public Entry(string value, int timestamp)
        {
            this.Value = value;
            this.Timestamp = timestamp;
        }
    }

    public TimeMap()
    {
        map = new Dictionary<string, List<Entry>>();
    }

    public void Set(string key, string value, int timestamp)
    {
        if(!map.ContainsKey(key))
        {
            map[key] = new List<Entry>();
        }
        map[key].Add(new Entry(value, timestamp));
    }

    public string Get(string key, int timestamp)
    {
        if(!map.ContainsKey(key))
        {
            return string.Empty;
        }
        else
        {
            var currEntryList = map[key];
            var left = 0;
            var right = currEntryList.Count - 1;
            var res = string.Empty;
            while(left <= right)
            {
                var mid = left + (right - left) / 2;
                if(currEntryList[mid].Timestamp <= timestamp)
                {
                    res = currEntryList[mid].Value;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return res;
        }
    }
}