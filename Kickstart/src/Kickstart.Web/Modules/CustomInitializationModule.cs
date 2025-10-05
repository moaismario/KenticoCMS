using CMS;
using CMS.Core;
using CMS.DataEngine;
using CMS.IO;
using Kentico.Xperience.AzureStorage;
using Kickstart.Web.Modules;

[assembly: RegisterModule(typeof(CustomInitializationModule))]

namespace Kickstart.Web.Modules
{
    public class CustomInitializationModule : Module
    {
        public CustomInitializationModule() : base("CustomInit") { }

        protected override void OnInit()
        {
            base.OnInit();

            var assetsProvider = AzureStorageProvider.Create();

            assetsProvider.PublicExternalFolderObject = true;

            StorageHelper.MapStoragePath("~/assets", assetsProvider);
        }
    }
}
