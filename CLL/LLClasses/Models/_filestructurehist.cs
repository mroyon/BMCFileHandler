using System;
using System.Globalization;
using System.IO;
using CLL.Abstract;

namespace CLL.LLClasses.Models
{
    
    public  class _filestructurehist : _Common
    {
         private static IResourceProvider resourceProvider_filestructurehist = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"LanguagesFiles/_filestructurehist.xml"));//DbResourceProvider(); //  
         
         
        public static string filestructurehistList
        {
            get
            {
                return resourceProvider_filestructurehist.GetResource("filestructurehistList", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string filestructurehistCreate
        {
            get
            {
                return resourceProvider_filestructurehist.GetResource("filestructurehistCreate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string filestructurehistUpdate
        {
            get
            {
                return resourceProvider_filestructurehist.GetResource("filestructurehistUpdate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string filestructurehistDetails
        {
            get
            {
                return resourceProvider_filestructurehist.GetResource("filestructurehistDetails", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         
     
         public static string fileid
        {
            get
            {
                return resourceProvider_filestructurehist.GetResource("fileid", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string fileidRequired
        {
            get
            {
                return resourceProvider_filestructurehist.GetResource("fileidRequired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string folderid
        {
            get
            {
                return resourceProvider_filestructurehist.GetResource("folderid", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string filename
        {
            get
            {
                return resourceProvider_filestructurehist.GetResource("filename", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string userfilename
        {
            get
            {
                return resourceProvider_filestructurehist.GetResource("userfilename", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string filepath
        {
            get
            {
                return resourceProvider_filestructurehist.GetResource("filepath", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string isdeleted
        {
            get
            {
                return resourceProvider_filestructurehist.GetResource("isdeleted", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string deletedbyuser
        {
            get
            {
                return resourceProvider_filestructurehist.GetResource("deletedbyuser", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string deleteddate
        {
            get
            {
                return resourceProvider_filestructurehist.GetResource("deleteddate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        
      
    }
}
