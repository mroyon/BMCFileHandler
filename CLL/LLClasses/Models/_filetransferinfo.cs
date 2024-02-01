using System;
using System.Globalization;
using System.IO;
using CLL.Abstract;

namespace CLL.LLClasses.Models
{
    
    public  class _filetransferinfo : _Common
    {
         private static IResourceProvider resourceProvider_filetransferinfo = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"LanguagesFiles/_filetransferinfo.xml"));//DbResourceProvider(); //  
         
         
        public static string filetransferinfoList
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("filetransferinfoList", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string filetransferinfoCreate
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("filetransferinfoCreate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string filetransferinfoUpdate
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("filetransferinfoUpdate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string filetransferinfoDetails
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("filetransferinfoDetails", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         
     
         public static string folderid
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("folderid", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string folderidRequired
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("folderidRequired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string fileid
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("fileid", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string fileidRequired
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("fileidRequired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string fromusername
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("fromusername", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string fromuserid
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("fromuserid", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string tousername
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("tousername", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string touserid
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("touserid", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string fromuserremark
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("fromuserremark", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string sentdate
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("sentdate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string showedpopup
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("showedpopup", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string showeddate
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("showeddate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string isreceived
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("isreceived", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string receiveddate
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("receiveddate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string isopen
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("isopen", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string opendate
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("opendate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string filename
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("filename", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string fileversion
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("fileversion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string fullpath
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("fullpath", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string priority
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("priority", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string filejsondata
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("filejsondata", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string status
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("status", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string expecteddate
        {
            get
            {
                return resourceProvider_filetransferinfo.GetResource("expecteddate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        
      
    }
}
