using System;
using System.Collections.Generic;
using System.IO;

public class INIFile
{
    private string filePath;

    public INIFile(string path)
    {
        filePath = path;
    }

    public void Write(string section, string key, string value)
    {
        NativeMethods.WritePrivateProfileString(section, key, value, filePath);
    }

    public string Read(string section, string key)
    {
        const int bufferSize = 256;
        var buffer = new char[bufferSize];
        NativeMethods.GetPrivateProfileString(section, key, "", buffer, bufferSize, filePath);

        // Find the first null character in the buffer and trim the string accordingly
        int nullIndex = Array.IndexOf(buffer, '\0');
        if (nullIndex >= 0)
        {
            return new string(buffer, 0, nullIndex);
        }

        // If no null character is found, return the entire buffer
        return new string(buffer);
    }


    private static class NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        public static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

        [System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        public static extern int GetPrivateProfileString(string section, string key, string defaultValue, char[] result, int size, string filePath);
    }
}
