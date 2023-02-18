using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.GuidHelperr
{
   public class GuidHelper
    {
        public static string CreateGuid()
        {
            //Guid.NewGuid()=> bu metot bize essiz bir deger olusturdu.
            return Guid.NewGuid().ToString();
            // Yani dosya eklerken dosyanin adi kendi olmasin,biz ona essiz bir isim olusturalim ki ayni isimde baska bir dosya adi varsa cakismasinlar.
        }
    }
}
