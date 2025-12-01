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

    foreach(var c in t)
    {
        if(sDict.ContainsKey(c))
        {
            sDict[c]--;
        }
        else
        {
            return false;
        }
    }

    return sDict.All((kv) => kv.Value == 0);
}

Debug.Assert(IsAnagram("racecar", "carrace"));
Debug.Assert(!IsAnagram("jar", "jam"));
Debug.Assert(!IsAnagram("xx", "x"));