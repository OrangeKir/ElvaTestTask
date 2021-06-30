namespace ElvaTestTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
    /// <summary>
    /// Хелпер загрузчика полигонов карт
    /// </summary>
    public class DownloaderHelper
    {
        /// <summary>
        /// Получить загрузчики
        /// </summary>
        /// <returns>Загрузчики</returns>
        public static Dictionary<string, Downloader> GetDownloaders()
        {
            return Assembly.GetAssembly(typeof(Downloader))
                .GetTypes().Where(t => t.IsSubclassOf(typeof(Downloader)))
                .ToDictionary(k => k.Name, v => (Downloader) Activator.CreateInstance(v));
        }
    }
}