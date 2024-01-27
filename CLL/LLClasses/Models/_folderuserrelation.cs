using System;
using System.Globalization;
using System.IO;
using CLL.Abstract;

namespace CLL.LLClasses.Models
{
    
    public  class _folderuserrelation : _Common
    {
         private static IResourceProvider resourceProvider_folderuserrelation = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"LanguagesFiles/_folderuserrelation.xml"));//DbResourceProvider(); //  
         
         
        public static string folderuserrelationList
        {
            get
            {
                return resourceProvider_folderuserrelation.GetResource("folderuserrelationList", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string folderuserrelationCreate
        {
            get
            {
                return resourceProvider_folderuserrelation.GetResource("folderuserrelationCreate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string folderuserrelationUpdate
        {
            get
            {
                return resourceProvider_folderuserrelation.GetResource("folderuserrelationUpdate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string folderuserrelationDetails
        {
            get
            {
                return resourceProvider_folderuserrelation.GetResource("folderuserrelationDetails", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         
     
         public static string folderid
        {
            get
            {
                return resourceProvider_folderuserrelation.GetResource("folderid", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string userid
        {
            get
            {
                return resourceProvider_folderuserrelation.GetResource("userid", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        
      
    }
}
