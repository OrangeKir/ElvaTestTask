namespace ElvaTestTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
        /// <summary>
        /// Ну Main и Main, чего бубнить-то?
        /// </summary>
        static void Main()
        {
            //OpenStreetDemonstrator();
            FullFieldDemonstration();
        }

        /// <summary>
        /// Скучная демонстрация загрузчика от OpenStreetMap, не больше, не меньше
        /// </summary>
        static void OpenStreetDemonstrator()
        {
            var instance = new OpenStreetDownloader();
            instance.Download("Москва", 1, "result.json");
        }
        
        /// <summary>
        /// Консольное приложение, демонстратор возможного использования загрузчика и его хелпера
        /// </summary>
        static void FullFieldDemonstration()
        {
            var downloaders = DownloaderHelper.GetDownloaders();
            int i = 1;
            foreach (var downloader in downloaders)
            {
                Console.WriteLine($"{i}) {downloader.Key}");
                i++;
            }
            
            Console.WriteLine("0) Выход");
            var index = Convert.ToInt32(Console.ReadLine());
            if (index == 0)
            {
                return;
            }

            if (index > 0 && index < i)
            {
                Console.Write("Всё путем, давай адресс: ");
                var address = Console.ReadLine();
                Console.Write("А теперь давай частоту точек: ");
                var frequancy = Convert.ToInt32(Console.ReadLine());
                Console.Write("Мы почти на месте, теперь называй файл и поехали: ");
                var fileName = Console.ReadLine();
                downloaders.ElementAt(index - 1).Value.Download(address, frequancy, fileName);
                Console.WriteLine("Загрузка выполнена");
                return;
            }
            Console.WriteLine("Ты зачем циферки путаешь? Так не пойдет, давай кабанчиком перезапускай и пробуй по новой");
        }
    }
}