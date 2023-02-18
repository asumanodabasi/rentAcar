using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;  //File,Directory,Path icin
using System.Text;
using Core.Utilities.Helpers.GuidHelperr;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHeplerManager : IFileHelper
    {
        public void Delete(string filepath)
        {
            if (File.Exists(filepath))  //dosya var mi diye kontrol ettim varsa sil
            {
                File.Delete(filepath);
            }
        }


        //IFormFile projemize bir dosya yüklemek için kulanılan yöntemdir, HttpRequest ile gönderilen bir dosyayı temsil eder.

        public string Update(IFormFile file, string filepath, string root)
        {
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))  // dosyanin kaydedilecegi adres dizini var mi diye bakiyo
                {
                    Directory.CreateDirectory(root); //yoksa kaydediyo
                }
                string extension = Path.GetExtension(file.FileName); //dosyanin uzantisini olusturduk
                string guid = GuidHelper.CreateGuid(); //dosyanin adini olusturduk.
                string filepath = guid + extension; //burda da ikisini yan yana getirdik.
//FileStream, Stream ana soyut sınıfı kullanılarak genişletilmiş, belirtilen kaynak dosyalar üzerinde okuma/yazma/atlama gibi operasyonları yapmamıza yardımcı olan bir sınıftır
                using (FileStream fileStream = File.Create(root + filepath))
                {
                    file.CopyTo(fileStream);  //kopyalanacak dosyanin akisini yazdim.
                    fileStream.Flush(); //arabellekten sil
                    return filepath; //sql server e dosya eklenirken adi ile eklensin diye dosyanin tam adini dondurdum.
                }
            }
            return null;
        }
    }
}
