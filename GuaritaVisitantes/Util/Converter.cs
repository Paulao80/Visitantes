using System;
using System.IO;

namespace GuaritaVisitantes.Util
{
    public static class Converter
    {
        public static byte[] FileToByteArray(string fileName)
        {
            byte[] fileData = null;

            using (FileStream fs = System.IO.File.OpenRead(fileName))
            {
                using (BinaryReader binaryReader = new BinaryReader(fs))
                {
                    fileData = binaryReader.ReadBytes((int)fs.Length);
                }
            }

            return fileData;
        }

        public static string FileToData(string path)
        {
            if (File.Exists(path))
            {
                string extension = Path.GetExtension(path).Replace(".", "");
                var img = "data:image/" + extension + ";base64," + Convert.ToBase64String(FileToByteArray(path));
                return img;
            }
            else return null;
        }

    }
}