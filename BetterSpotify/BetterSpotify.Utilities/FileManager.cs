using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BetterSpotify.Utilities
{
    public class FileManager
    {
        private FileManager()
        {
            
        }

        public enum FileCategory 
        {
            Album,
            Artist,
            Category,
            Song,
            Profile
        }

        public enum FileType
        {
            Music,
            Picture
        }

        public string SaveFile(IFormFile file, string wwwRootPath, FileCategory category, FileType type = FileType.Picture)
        {
            if (type == FileType.Picture)
            {
                var filename = category.ToString() + "_" + Guid.NewGuid().ToString();
                var Uploads = Path.Combine(wwwRootPath, "images\\" + category.ToString() + "Pics");
                var extenstion = Path.GetExtension(file.FileName);

                using (var filestream = new FileStream(Path.Combine(Uploads, filename + extenstion), FileMode.Create))
                {
                    file.CopyTo(filestream);
                }

                return @"\images\" + category.ToString() + @"Pics\" + filename + extenstion;
            }

            return "";
        }

        public string SaveFile(IFormFile file, string wwwRootPath, string category, FileType type = FileType.Music)
        {

                var filename = category.ToString() + "_" + Guid.NewGuid().ToString();
                var Uploads = Path.Combine(wwwRootPath, "music\\musicfiles\\" + category);
                var extenstion = Path.GetExtension(file.FileName);

                using (var filestream = new FileStream(Path.Combine(Uploads, filename + extenstion), FileMode.Create))
                {
                    file.CopyTo(filestream);
                }

                return category + "/" + filename + extenstion;

                
            return "";
        }


        private static FileManager instance;

        private static readonly object myLock = new();


        public static FileManager GetInstance()
        {
            //return new Ja();

            lock (myLock)
            {
                return instance ??= new FileManager();
            }
        }
    }
}
