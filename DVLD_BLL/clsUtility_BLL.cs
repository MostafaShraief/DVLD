﻿using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    internal class clsUtility_BLL
    {
        public static bool CheckOnlyLettersAndSpaces(string str)
        {
            if (str == null)
                return false;

            bool IsOk = true;

            foreach (char ch in str)
            {
                if (!((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || ch == ' ')) // check if character is not letter or space, then break.
                {
                    IsOk = false;
                    break;
                }
            }

            return IsOk;
        }

        public static bool CheckCharactersByExpression(Func<char, bool> exp, string str)
        {
            bool IsOk = true;

            foreach (char ch in str)
            {
                if (!exp(ch)) // check if character is not meet expression conditions.
                {
                    IsOk = false;
                    break;
                }
            }

            return IsOk;
        }

        public static bool CheckOnlyLettersInListOfString(ref List<string> Strings)
        {
            bool IsOk = true;

            foreach (string str in Strings)
            {
                if (!CheckOnlyLettersAndSpaces(str))
                {
                    IsOk = false;
                    break;
                }
            }

            return IsOk;
        }

        public static Func<string, bool> CheckStringNotNullableOrEmpty =
            (str) => (str == null || str == string.Empty);

        public static bool CheckStringsInListNotNullableOrEmpty(ref List<string> list)
        {
            bool IsOk = true;

            foreach (string str in list)
            {
                if (String.IsNullOrEmpty(str))
                {
                    IsOk = false;
                    break;
                }
            }

            return IsOk;
        }

        public static bool CheckListOfStringByExpression(Func<char, bool> exp, ref List<string> list)
        {
            bool IsOk = true;

            foreach (string str in list)
            {
                if (!CheckCharactersByExpression(exp, str)) // if str not meet conditions in the experstion then break.
                {
                    IsOk = false;
                    break;
                }
            }

            return IsOk;
        }

        public static Func<string, bool> CheckOnlyLettersAndNotEmpty =
            (str) => (str != string.Empty && clsUtility_BLL.CheckOnlyLettersAndSpaces(str));

        public static bool CheckEmail(string Email)
        {
            if (Email == null)
                return false;

            bool IsOk = true;

            List<string> list = Email.Split('@').ToList();

            if (list.Count != 2)
                return false;

            string part = list[1];

            list.RemoveAt(1);

            list.AddRange(part.Split('.').ToList());

            if (list.Count != 3)
                return false;

            foreach (string str in list)
                if (str.Length == 0) // Check if str is empty.
                    return false;

            if (CheckListOfStringByExpression(((c) => ((c >= 'a' && c <= 'z') ||
            (c >= 'A' && c <= 'Z') ||
            (c >= '0' && c <= '9'))),
            ref list) == false) // check if characters only numbers and letters.
                return false;

            return IsOk;
        }

        public static void CreateDirectoryIfNotExist(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
        }
        
        public static class Image
        {
            public static bool IsImageValid(byte[] imageBytes)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        // Use System.Drawing.Image.FromStream
                        using (var image = System.Drawing.Image.FromStream(ms))
                        {
                            var test = image.Size; // Accessing properties forces validation
                            return true;
                        }
                    }
                }
                catch
                {
                    return false;
                }
            }

            public static bool IsFileExist(string Path)
            {
                return File.Exists(Path);
            }

            public static Byte[] ImageToByteArray(System.Drawing.Image image)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Save the image to the MemoryStream in the specified format
                        image.Save(ms, image.RawFormat);
                        ms.Seek(0, SeekOrigin.Begin);  // Ensure the stream is at the start
                        return ms.ToArray(); // Convert the stream to a byte array
                    }
                }
                catch
                {
                    return null;
                }
            }

            public static System.Drawing.Image ByteArrayToImage(Byte[] imageBytes)
            {
                try
                {
                    MemoryStream ms = new MemoryStream(imageBytes);
                    return System.Drawing.Image.FromStream(ms);
                }
                catch
                {
                    return null;
                }
            }

            public static Byte[] LoadImageFromFile(string imagePath)
            {
                Byte[] bytesImage = null;

                if (IsFileExist(imagePath))
                {
                    using (System.Drawing.Image image = System.Drawing.Image.FromFile(imagePath))
                    {
                        bytesImage = ImageToByteArray(image);
                    }
                }

                return bytesImage;
            }

            public static string GetStringOfImageFormat(ImageFormat format)
            {
                var formatMap = new Dictionary<Guid, string>
                {
                    { ImageFormat.Jpeg.Guid, ".jpg" },
                    { ImageFormat.Png.Guid, ".png" },
                    { ImageFormat.Bmp.Guid, ".bmp" },
                    { ImageFormat.Gif.Guid, ".gif" },
                    { ImageFormat.Tiff.Guid, ".tiff" }
                };

                if (formatMap.ContainsKey(format.Guid))
                    return formatMap[format.Guid];

                return ".Unknown";
            }

            public static string GetRandomImageFileName(ImageFormat format)
            {
                string FileName = Guid.NewGuid().ToString() +
                    GetStringOfImageFormat(format);

                return FileName;
            }

            public static string CreateImagePath(System.Drawing.Image image)
            {
                string FileName = GetRandomImageFileName(image.RawFormat);

                string path = Path.Combine(clsSettings.DeffaultImageFolder,
                    GetRandomImageFileName(image.RawFormat));

                return path;
            }

            public static bool SaveImageToPath(System.Drawing.Image image, string path)
            {
                bool Ok = true;

                CreateDirectoryIfNotExist(clsSettings.DeffaultImageFolder);

                try
                {
                    image.Save(path);
                }
                catch
                {
                    Ok = false;
                }

                return Ok;
            }
        }

        public static class Characters
        {
            private static bool ValidateCharacters(string input, string pattern)
            {
                return Regex.IsMatch(input, pattern);
            }

            public static class English
            {
                public static bool ValidateOnlyLetters(string input) => ValidateCharacters(input, @"^[a-zA-Z]+$");
                public static bool ValidateLettersAndNumbers(string input) => ValidateCharacters(input, @"^[a-zA-Z0-9]+$");
                public static bool ValidateOnlyNumbers(string input) => ValidateCharacters(input, @"^\d+$");
                public static bool ValidateEmail(string input) => ValidateCharacters(input, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

                public static bool ValidateOnlyLettersWithSpaces(string input) => ValidateCharacters(input, @"^[a-zA-Z\s]+$");
                public static bool ValidateLettersAndNumbersWithSpaces(string input) => ValidateCharacters(input, @"^[a-zA-Z0-9\s]+$");
                public static bool ValidateOnlyNumbersWithSpaces(string input) => ValidateCharacters(input, @"^[\d\s]+$");
            }

            public static class AllLanguages
            {
                public static bool ValidateOnlyLetters(string input) => ValidateCharacters(input, @"^[\p{L}]+$");
                public static bool ValidateLettersAndNumbers(string input) => ValidateCharacters(input, @"^[\p{L}\p{N}]+$");
                public static bool ValidateOnlyNumbers(string input) => English.ValidateOnlyNumbers(input);
                public static bool ValidateEmail(string input) => ValidateCharacters(input, @"^[\p{L}0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

                public static bool ValidateOnlyLettersWithSpaces(string input) => ValidateCharacters(input, @"^[\p{L}\s]+$");
                public static bool ValidateLettersAndNumbersWithSpaces(string input) => ValidateCharacters(input, @"^[\p{L}\p{N}\s]+$");
                public static bool ValidateOnlyNumbersWithSpaces(string input) => ValidateCharacters(input, @"^[\d\s]+$");
            }
        }

        public static bool _IsValidUsernameOrPassword(string input, int Length)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{" + Length.ToString() + ",}$";
            return Regex.IsMatch(input, pattern);
        }

        public static string Encrypt(string input, int shift = clsSettings.DeffaultShiftValue)
        {
            string result = "";
            foreach (char c in input)
            {
                result += (char)(c + shift); // Shift each character
            }
            return result;
        }

        public static string Decrypt(string input, int shift = clsSettings.DeffaultShiftValue)
        {
            string result = "";
            foreach (char c in input)
            {
                result += (char)(c - shift); // Reverse the shift
            }
            return result;
        }

        public static Func<object, string> ConvertObjectToString =
            (obj) => ((obj != DBNull.Value && obj != null) ? obj.ToString() : string.Empty);
    }
}
