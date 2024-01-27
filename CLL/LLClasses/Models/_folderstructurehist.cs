using System;
using System.Globalization;
using System.IO;
using CLL.Abstract;

namespace CLL.LLClasses.Models
{
    
    public  class _folderstructurehist : _Common
    {
         private static IResourceProvider resourceProvider_folderstructurehist = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"LanguagesFiles/_folderstructurehist.xml"));//DbResourceProvider(); //  
         
         
        public static string folderstructurehistList
        {
            get
            {
                return resourceProvider_folderstructurehist.GetResource("folderstructurehistList", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string folderstructurehistCreate
        {
            get
            {
                return resourceProvider_folderstructurehist.GetResource("folderstructurehistCreate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string folderstructurehistUpdate
        {
            get
            {
                return resourceProvider_folderstructurehist.GetResource("folderstructurehistUpdate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string folderstructurehistDetails
        {
            get
            {
                return resourceProvider_folderstructurehist.GetResource("folderstructurehistDetails", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         
     
         public static string folderid
        {
            get
            {
                return resourceProvider_folderstructurehist.GetResource("folderid", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string folderidRequired
        {
            get
            {
                return resourceProvider_folderstructurehist.GetResource("folderidRequired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string foldername
        {
            get
            {
                return resourceProvider_folderstructurehist.GetResource("foldername", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string physicalpath
        {
            get
            {
                return resourceProvider_folderstructurehist.GetResource("physicalpath", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string parentfolderid
        {
            get
            {
                return resourceProvider_folderstructurehist.GetResource("parentfolderid", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string isdeleted
        {
            get
            {
                return resourceProvider_folderstructurehist.GetResource("isdeleted", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string deletedbyuser
        {
            get
            {
                return resourceProvider_folderstructurehist.GetResource("deletedbyuser", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string deleteddate
        {
            get
            {
                return resourceProvider_folderstructurehist.GetResource("deleteddate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        
      
    }
}
