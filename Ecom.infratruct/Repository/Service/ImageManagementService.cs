using Ecom.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.infratruct.Repository.Service
{
    public class ImageManagementService : IImageManagementService
    {
        private readonly IFileProvider fileProvider;
        public ImageManagementService(IFileProvider fileProvider)
        {
                this.fileProvider = fileProvider;
        }
        public async Task<List<string>> AddImageAsync(IFormFileCollection files, string src)
        {
            var SaveImageSrc = new List<string>();
            var ImageDirectory = Path.Combine("wwwroot", "Images", src);
            if (Directory.Exists(ImageDirectory) is not true)
            {
                Directory.CreateDirectory(ImageDirectory);
            }
            foreach (var item in files)
            {
                if(item.Length > 0)
                {
                    var ImageName = item.FileName;
                    // Build a relative path without extra spaces and using forward slashes for URLs.
                    var ImageSrc = Path.Combine("Images", src, ImageName).Replace("\\", "/");
                    var root = Path.Combine(ImageDirectory, ImageName);
                    using(FileStream stream= new FileStream(root, FileMode.Create))
                    {
                      await  item.CopyToAsync(stream);
                    }
                    SaveImageSrc.Add(ImageSrc);

                }

            }
            return SaveImageSrc;
        }

        public async Task DeleteImageAsync(string src)
        {
            var info = fileProvider.GetFileInfo(src);
            var root = info.PhysicalPath;

            if (File.Exists(root))
            {
                // Execute deletion on thread pool to avoid blocking.
                await Task.Run(() => File.Delete(root));
            }
        }

        
    }
}
