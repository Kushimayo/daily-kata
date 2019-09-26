using System;

namespace CompareVersion
{
    public class VersionManager
    {
        public VersionManager()
        {
        }

        public int CompareVersion(string version1, string version2)
        {
            string[] v1 = version1.Split('.');
            string[] v2 = version2.Split('.');
            int compare1, compare2 = 0;
            for (int i = 0; i < v1.Length || i < v2.Length; i++)
            {
                compare1 = i < v1.Length ? int.Parse(v1[i]) : 0;
                compare2 = i < v2.Length ? int.Parse(v2[i]) : 0;
                if (compare1 != compare2)
                    return compare1 > compare2 ? 1 : -1;
            }
            return 0;
        }
    }
}