using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTro
{
    public static class ImageUniqueName
    {
        public static string UniqueName(string Source)
        {
            //Đường Dẫn File Ảnh Gốc
            var sourceImageFileInfo = new FileInfo(Source);

            //Tao ten duy nhat
            var uniqueName = $"{Guid.NewGuid()}{sourceImageFileInfo.Extension}";

            //Đường dẫn tập tin exe
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            //Đường dẫn folder Image trong file exe
            var destinationPath = $"{baseDirectory}Image_RoomCategory\\{uniqueName}";

            //Copy Ảnh từ File Ảnh Gốc Sang Folder Ảnh Trong File Exe
            if (!File.Exists(destinationPath))
            {
                File.Copy(Source, destinationPath);
            }
            return uniqueName;
        }
    }
}
