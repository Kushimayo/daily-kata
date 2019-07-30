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
            string[] splitV1 = v1.Split('.');
            int[] version1 = new int[splitV1.Length];
            for (int i = 0; i < splitV1.Length; i++)
            {
                version1[i] = Int32.Parse(splitV1[i]);
            }
            return 0;
            //int version1 = Int32.Parse(v1);
            //int version2 = Int32.Parse(v2);

            //if (version1 > version2)
            //    return 1;
            //else if (version1 < version2)
            //    return -1;
            //else
            //    return 0;
        }

        private int[] ConvertToIntegerArray(string version)
        {
            string[] splitVersion = version.Split('.');
            int[] intArray = new int[splitVersion.Length];
            for (int i = 0; i < splitVersion.Length; i++)
            {
                intArray[i] = Int32.Parse(splitVersion[i]);
            }

            return intArray;
        }
    }
}