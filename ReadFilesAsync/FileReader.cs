using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReadFilesAsync
{
    class FileReader
    {
        public async Task<int> Read(string path)
        {
            var files = Directory.GetFiles(path);
            List<Task> tasks = new List<Task>();
            var bytes = 0;
            foreach (var file in files)
            {
                var task = Task.Run(() =>
                {
                    using (var reader = new StreamReader(file))
                    {
                        //Thread.Sleep(100); // is the same as await Task.Delay(100);
                        //await Task.Delay(100);
                        Console.WriteLine($"Reading file : {file}");
                        var text = reader.ReadToEnd();
                        bytes += text.Length;
                    }
                });
                tasks.Add(task); 
            }
            await Task.WhenAll(tasks);

            return bytes;
        }


        private async Task<int> ProcessFilesAsync()
        {
            var filesPath = "D:/files/";
            var totalLength = 0;
            List<Task> tasks = new List<Task>();

            for (int i = 1; i <= 5; i++)
            {
                var filePath = filesPath + $"{i}.txt";

                var task = Task.Run(() =>
                {
                    using (var reader = new StreamReader(filePath, Encoding.UTF8))
                    {

                        var fileContent = reader.ReadToEnd();


                        totalLength += fileContent.Length;
                        // processing file content..
                    }
                });

                tasks.Add(task);

            }

            await Task.WhenAll(tasks);

            return totalLength;
        }

        private void ProcessFiles()
        {
            var filesPath = @"C:\Users\Daniel\Pictures\Screenpresso";
            for (int i = 1; i <= 5; i++)
            {
                var filePath = filesPath + $"{i}.txt";

                using (var reader = new StreamReader(filePath, Encoding.UTF8))
                {
                    Console.WriteLine($"Reading {filePath}..");

                    var fileContent = reader.ReadToEnd();

                    // processing file content..
                }
            }
        }
    }
}
