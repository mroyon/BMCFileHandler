using System;
using System.Globalization;
using System.IO;
using CLL.Abstract;

namespace CLL.LLClasses.Models
{
    
    public  class _fileuserrelation : _Common
    {
         private static IResourceProvider resourceProvider_fileuserrelation = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"LanguagesFiles/_fileuserrelation.xml"));//DbResourceProvider(); //  
         
         
        public static string fileuserrelationList
        {
            get
            {
                return resourceProvider_fileuserrelation.GetResource("fileuserrelationList", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string fileuserrelationCreate
        {
            get
            {
                return resourceProvider_fileuserrelation.GetResource("fileuserrelationCreate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string fileuserrelationUpdate
        {
            get
            {
                return resourceProvider_fileuserrelation.GetResource("fileuserrelationUpdate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string fileuserrelationDetails
        {
            get
            {
                return resourceProvider_fileuserrelation.GetResource("fileuserrelationDetails", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         
     
         public static string fileid
        {
            get
            {
                return resourceProvider_fileuserrelation.GetResource("fileid", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string userid
        {
            get
            {
                return resourceProvider_fileuserrelation.GetResource("userid", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        
      
    }
}
