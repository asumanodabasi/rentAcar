using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.FileHelper
{
    public interface IFileHelper
    {
        string Upload(IFormFile file,string root);
        void Delete(string filepath);  //filepath dosyanin kaydedildigi adres yolu 
        string Update(IFormFile file,string filepath,string root);  //root dosyanin yeni adres yolu
    }
}
