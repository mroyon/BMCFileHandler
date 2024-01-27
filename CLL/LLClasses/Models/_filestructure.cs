using System;
using System.Globalization;
using System.IO;
using CLL.Abstract;

namespace CLL.LLClasses.Models
{
    
    public  class _filestructure : _Common
    {
         private static IResourceProvider resourceProvider_filestructure = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"LanguagesFiles/_filestructure.xml"));//DbResourceProvider(); //  
         
         
        public static string filestructureList
        {
            get
            {
                return resourceProvider_filestructure.GetResource("filestructureList", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string filestructureCreate
        {
            get
            {
                return resourceProvider_filestructure.GetResource("filestructureCreate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string filestructureUpdate
        {
            get
            {
                return resourceProvider_filestructure.GetResource("filestructureUpdate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string filestructureDetails
        {
            get
            {
                return resourceProvider_filestructure.GetResource("filestructureDetails", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         
     
         public static string folderid
        {
            get
            {
                return resourceProvider_filestructure.GetResource("folderid", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string filename
        {
            get
            {
                return resourceProvider_filestructure.GetResource("filename", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string userfilename
        {
            get
            {
                return resourceProvider_filestructure.GetResource("userfilename", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string filepath
        {
            get
            {
                return resourceProvider_filestructure.GetResource("filepath", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string isdeleted
        {
            get
            {
                return resourceProvider_filestructure.GetResource("isdeleted", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string deletedbyuser
        {
            get
            {
                return resourceProvider_filestructure.GetResource("deletedbyuser", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string deleteddate
        {
            get
            {
                return resourceProvider_filestructure.GetResource("deleteddate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        
      
    }
}
