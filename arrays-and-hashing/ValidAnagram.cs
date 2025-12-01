using System.Diagnostics;

bool IsAnagram(string s, string t)
{
    var sDict = new Dictionary<char, int>();
    foreach(var c in s)
    {
        if(sDict.ContainsKey(c))
        {
            sDict[c]++;
        }
        else
        {
            sDict[c] = 1;
        }
    }

    var tDict = new Dictionary<char, int>();
    foreach(var c in t)
    {
        if(tDict.ContainsKey(c))
        {
            tDict[c]++;
        }
        else
        {
            tDict[c] = 1;
        }
    }

    return (sDict.Count == tDict.Count) && !sDict.Except(tDict).Any();
}

Debug.Assert(IsAnagram("racecar", "carrace"));
Debug.Assert(!IsAnagram("jar", "jam"));
Debug.Assert(!IsAnagram("xx", "x"));