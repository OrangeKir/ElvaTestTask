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
                var webStream = client.OpenRead(String.Format(WebMask, address));
                var content = new byte[webStream.Length];
                webStream.Read(content, 0, content.Length);

                content = ContentCutter(content, frequency);
                
                using (var fileStream = new FileStream(Path.Combine(FilePath, fileName), FileMode.OpenOrCreate))
                {
                    fileStream.Write(content);
                }
            }
        }

        public byte[] ContentCutter(byte[] content, int frequency)
        {
            if (frequency == 1)
            {
                return content;
            }
            
            var result = new byte[content.Length / frequency];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = content[i * frequency];
            }

            return result;
        }
    }
}