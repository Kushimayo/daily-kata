using System;

namespace CompareVersionNumber
{
    public class VersionManager
    {
        public VersionManager()
        {
        }

        public int CompareVersion(string v1, string v2)
        {
            int[] version1 = ConvertVersionToInteger(v1);
            int[] version2 = ConvertVersionToInteger(v2);

            int i = 0;
            int result = 0;
            while(i < version1.Length || i < version2.Length)
            {
                int compare1 = i < version1.Length ? version1[i] : 0;
                int compare2 = i < version2.Length ? version2[i] : 0;
                if ((result = CompareInteger(compare1, compare2)) != 0)
                    return result;
                i++;
            }            
            return result;
        }

        private int CompareInteger(int v1, int v2)
        {
            if (v1 > v2)
                return 1;
            else if (v2 > v1)
                return -1;
            else
                return 0;
        }

        private int[] ConvertVersionToInteger(string v)
        {
            string[] splitVersion = v.Split('.');
            int[] versionInt = new int[splitVersion.Length];
            for (int i = 0; i < splitVersion.Length; i++)
            {
                versionInt[i] = Int32.Parse(splitVersion[i]);
            }

            return versionInt;
        }
    }
}