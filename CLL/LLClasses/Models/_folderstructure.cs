using System;
using System.Globalization;
using System.IO;
using CLL.Abstract;

namespace CLL.LLClasses.Models
{
    
    public  class _folderstructure : _Common
    {
         private static IResourceProvider resourceProvider_folderstructure = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"LanguagesFiles/_folderstructure.xml"));//DbResourceProvider(); //  
         
         
        public static string folderstructureList
        {
            get
            {
                return resourceProvider_folderstructure.GetResource("folderstructureList", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string folderstructureCreate
        {
            get
            {
                return resourceProvider_folderstructure.GetResource("folderstructureCreate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string folderstructureUpdate
        {
            get
            {
                return resourceProvider_folderstructure.GetResource("folderstructureUpdate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string folderstructureDetails
        {
            get
            {
                return resourceProvider_folderstructure.GetResource("folderstructureDetails", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         
     
         public static string foldername
        {
            get
            {
                return resourceProvider_folderstructure.GetResource("foldername", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string physicalpath
        {
            get
            {
                return resourceProvider_folderstructure.GetResource("physicalpath", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string parentfolderid
        {
            get
            {
                return resourceProvider_folderstructure.GetResource("parentfolderid", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string isdeleted
        {
            get
            {
                return resourceProvider_folderstructure.GetResource("isdeleted", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string deletedbyuser
        {
            get
            {
                return resourceProvider_folderstructure.GetResource("deletedbyuser", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string deleteddate
        {
            get
            {
                return resourceProvider_folderstructure.GetResource("deleteddate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        
      
    }
}
