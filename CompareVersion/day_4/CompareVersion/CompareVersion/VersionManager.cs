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
            int i = 0;
            while (i < v1.Length || i < v2.Length)
            {
                int v1Int = i < v1.Length ? Int32.Parse(v1[i]) : 0;
                int v2Int = i < v2.Length ? Int32.Parse(v2[i]) : 0;
                if (v1Int != v2Int)
                    return v1Int > v2Int ? 1 : -1;
                i++;
            }
            return 0;
        }
    }
}