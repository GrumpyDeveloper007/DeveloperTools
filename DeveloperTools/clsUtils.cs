using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestFrameworkCommon
{
    /// <summary>
    /// Static utility functions
    /// </summary>
    public class clsUtils
    {
        /// <summary>
        /// Struct which holds information about particular firmware file, used for sorting by dateCreated and DateModified
        /// </summary>
       public struct firmwareFileInfo
       {
           /// <summary>
           /// Firmware file name placeholder
           /// </summary>
           public string sFirmwareFileName;
           /// <summary>
           /// Firmware file date last modified place holder
           /// </summary>
           public DateTime dtFirmwareFileDateLastWritten;
       }



        /// <summary>
        /// Returns the current zigbee time (time since 2000)
        /// </summary>
        /// <returns></returns>
        public static UInt32 GetCurrentZigbeeTime()
        {
            UInt32 ticks = (UInt32)(DateTime.UtcNow - DateTime.Parse("01/01/2000 00:00:00")).TotalSeconds;
            return ticks;
        }

        /// <summary>
        /// Converts a uint32 to a hex string
        /// </summary>
        /// <param name="iValue"></param>
        /// <returns></returns>
        public static string ToHex(UInt32 iValue)
        {
            return "0x" + iValue.ToString("X");
        }


        /// <summary>
        /// Converts a int to a hex string 
        /// </summary>
        /// <param name="iValue"></param>
        /// <returns></returns>
        public static string ToHex(int iValue)
        {
            return "0x" + iValue.ToString("X");
        }

        /// <summary>
        /// Converts a generic hex string to a byte array
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static byte[] FromHex(string hex)
        {
            string[] sBytes;
            int i = 0;

            sBytes = hex.Split(',');
            if (sBytes.Count() == 1 && hex.Length > 4)
            {
                sBytes = hex.Split(' ');
                if (sBytes.Count() == 1)
                {
                    sBytes = hex.Split('-');
                    if (sBytes.Count() == 1)
                    {
                        sBytes = new string[(int)Math.Ceiling((double)hex.Length / 2)];
                        for (int t = 0; t < hex.Length; t++)
                        {
                            if (hex.Length < t + 2)
                            {
                                sBytes[t / 2] = hex.Substring(t, 1);
                            }
                            else
                            {
                                sBytes[t / 2] = hex.Substring(t, 2);
                            }
                        }
                    }
                }
            }
            byte[] raw = new byte[sBytes.Length];

            foreach (string sByte in sBytes)
            {
                string sHexChar = sByte.Trim().Replace("-", "").Replace("0x", "").Replace(",", "").Replace("{", "").Replace("}", "").Replace(" ", "");
                raw[i] = Convert.ToByte(sHexChar, 16);
                i++;
            }
            return raw;
        }

        /// <summary>
        /// Converts a generic hex string to a byte array, with specified length (will pad)
        /// </summary>
        /// <param name="hex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static byte[] FromHex(string hex, int length)
        {
            string[] sBytes;
            int i = 0;

            sBytes = hex.Split(',');
            if (sBytes.Count() == 1 && hex.Length > 4)
            {
                sBytes = hex.Split(' ');
            }

            if (!hex.Contains(' '))
            {
                for (int k = 0; k < hex.Length; k = k + 2)
                {
                    int j = 0;
                    
                    sBytes[j] = hex.ToCharArray(k, 2).ToString();
                    j++;
                }
            }

            byte[] raw = new byte[length];

            foreach (string sByte in sBytes)
            {
                string sHexChar = sByte.Trim().Replace("-", "").Replace("0x", "").Replace(",", "").Replace("{", "").Replace("}", "").Replace(" ", "");
                raw[i] = Convert.ToByte(sHexChar, 16);
                i++;
            }
            return raw;
        }

        /// <summary>
        /// Convert as ASCII string to a string of hex characters
        /// </summary>
        /// <param name="sData"></param>
        /// <param name="iLength"></param>
        /// <returns></returns>
        public static string StringToHexString(string sData, int iLength)
        {
            string sTemp = sData.Substring(1, sData.Length - 2);
            byte[] bBytes = System.Text.Encoding.ASCII.GetBytes(sTemp);
            byte[] bCorrectSizeBuffer = new byte[iLength];

            for (int i = 0; i < bBytes.Length; i++)
            {
                bCorrectSizeBuffer[i] = bBytes[i];
            }

            sTemp = BitConverter.ToString(bCorrectSizeBuffer);
            return sTemp;
        }

        /// <summary>
        /// Convert a hex string to as string of ASCII characters
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        public static string HexStringToString(string sData)
        {
            string sTemp = "";
            byte[] bBytes = FromHex(sData);

            sTemp += "\"";
            sTemp += System.Text.Encoding.ASCII.GetString(bBytes);
            sTemp += "\"";
            sTemp = sTemp.Replace('\0', '0');

            return sTemp;
        }

        /// <summary>
        /// Convert a hex string to as string of ASCII characters
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        public static string HexStringToString_RAW(string sData)
        {
            string sTemp = "";
            byte[] bBytes = FromHex(sData);

            sTemp += System.Text.Encoding.ASCII.GetString(bBytes);

            return sTemp;
        }


        /// <summary>
        /// Converts a hex string to a integer value
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        public static string HexStringToInteger(string sData)
        {
            long lValue = 0;
            byte[] bBytes = FromHex(sData);

            if (bBytes.Length <= 4)
            {
                for (int i = bBytes.Length - 1; i >= 0; i--)
                {
                    lValue = lValue * 256;
                    lValue += bBytes[i];
                }
                return lValue.ToString();
            }
            else
            {
                return sData;
            }
        }


        /// <summary>
        /// Converts an array of bytes to a integer values - big endian
        /// </summary>
        /// <param name="bBytes"></param>
        /// <returns></returns>
        public static int ByteArrayToInt(byte[] bBytes)
        {
            int i;
            int iResult = 0;
            for (i = bBytes.Count() - 1; i >= 0; i--)
            {
                iResult *= 256;
                iResult += bBytes[i];
            }
            return iResult;
        }

        /// <summary>
        /// Converts an array of bytes to a integer values - big endian, with a specific start and length
        /// </summary>
        /// <param name="bBytes"></param>
        /// <param name="iOffset"></param>
        /// <param name="iLength"></param>
        /// <returns></returns>
        public static int ByteArrayToInt(byte[] bBytes, int iOffset, int iLength)
        {
            int i;
            int iResult = 0;
            for (i = iOffset + iLength - 1; i >= iOffset; i--)
            {
                iResult *= 256;
                iResult = bBytes[i];
            }
            return iResult;
        }


       

        /// <summary>
        /// Specify a directory and this method will search it for all .bin files and return an ordered array based on their date Modified
        /// with the most recent file being in position 0
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="firmwareFilenameArray"></param>
        /// <returns></returns>
        public string getFirmwareFileArrayFromDirectory(string directoryPath, out string[] firmwareFilenameArray)
        {
            List<firmwareFileInfo> tempFilesList = new List<firmwareFileInfo>();
            firmwareFileInfo firmwareFileInfoTemp = new firmwareFileInfo();
            try
            {
                firmwareFilenameArray = System.IO.Directory.GetFiles(directoryPath,"*.bin");
                
                foreach(string s in firmwareFilenameArray)
                {
                    firmwareFileInfoTemp.sFirmwareFileName = s;
                    firmwareFileInfoTemp.dtFirmwareFileDateLastWritten = System.IO.File.GetLastWriteTime(s);
                    tempFilesList.Add(firmwareFileInfoTemp);
                }
                               
                tempFilesList.Sort((x, y) => DateTime.Compare(y.dtFirmwareFileDateLastWritten, x.dtFirmwareFileDateLastWritten));
                int i = 0;
                foreach (firmwareFileInfo e in tempFilesList)
                {
                    firmwareFilenameArray[i] = e.sFirmwareFileName;
                    i++;
                }
    
                return "";
            }
            catch (Exception ex)
            {
                firmwareFilenameArray = new string[0];
                return "Error getting files from directory :" + directoryPath + " Exception was: " + ex.Message;
            }
        }

          

    }
}
