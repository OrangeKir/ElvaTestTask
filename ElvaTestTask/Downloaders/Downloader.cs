namespace ElvaTestTask
{
    using System;
    using System.IO;
    using System.Net;

    /// <summary>
    /// Загрузчик полигонов карт
    /// </summary>
    public abstract class Downloader
    {
        /// <summary> Расположение записываемого файла </summary>
        protected abstract string FilePath { get; }
        
        /// <summary> Маска запроса с сервиса </summary>
        protected abstract string WebMask { get; }

        /// <summary>
        /// Скачать точки из сервиса
        /// </summary>
        /// <param name="address">Адресс для поиска полигонов</param>
        /// <param name="frequency">Частота точек</param>
        /// <param name="fileName">Имя сохраняемого файла</param>
        public void Download(string address, int frequency, string fileName)
        {
            if (frequency < 1)
            {
                throw new Exception("Non positive frequance value");
            }

            using (var client = new WebClient())
            {
                var webStream = client.OpenRead(String.Format(WebMask, address, ((decimal) frequency - 1) / 1000));
                var content = new byte[webStream.Length];
                webStream.Read(content, 0, content.Length);

                using (var fileStream = new FileStream(Path.Combine(FilePath, fileName), FileMode.OpenOrCreate))
                {
                    fileStream.Write(content);
                }
            }
        }
    }
}