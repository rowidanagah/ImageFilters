using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Globalization;

namespace ImageFilters.Services
{
    public static class Utility
    {
        public static  String UploadFile(IFormFile file, string FolderName)
        {
            try
            {
                var folderName = Path.Combine(@"wwwroot", FolderName);
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = Utility.GetCurrentTime().Ticks.ToString()+
                        Path.GetExtension(file.FileName).Trim('"').Replace(" ", "");

                    var fullPath = Path.Combine(pathToSave, fileName).Replace(" ", "");
                    var dbPath = Path.Combine(FolderName, fileName).Replace(" ", "");

                    using (var stream = new FileStream(fullPath, FileMode.Create)) {file.CopyTo(stream); }

                    return dbPath.Replace("\\", "/").Replace(" ", "");
                }
                else { return "Length file error"; }
            }
            catch (Exception ex) { return "Internal server error"; }
        }
        public static DateTime GetCurrentTime()
        {
            return DateTime.UtcNow.AddHours(2);
        }
        public static string GetAbsolutePathOrSameString(string uri)
        {
            return Uri.IsWellFormedUriString(uri, UriKind.Absolute) ? new Uri(uri).AbsolutePath : uri;
        }

        public static string DeleteFile(string fullPath, string fileName)
        {
            try {
                if (fullPath != null && System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                    return "Filter Deleted";
                }
                return "Internal Server Error";
            }
            catch(Exception e) { return e.Message; }
        }

    }
}
