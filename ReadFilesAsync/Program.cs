using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ReadFilesAsync
{
    class Program
    {
        static async Task FooAsync()
        {
            Console.WriteLine("Foo start");

            await Task.Delay(2000);
            Console.WriteLine("Foo middle ");
            

            Console.WriteLine("Foo end");

        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("Main started");

            Task task = null;
            try
            {
                task = FooAsync();
                Console.WriteLine("coś tam robie se");

            }
            catch (Exception)
            {

                Console.WriteLine("Error");
            }

            await task;
            Console.WriteLine("Czesc");

            Console.WriteLine("Press key...");
            Console.ReadKey();

            //var stopwatch = Stopwatch.StartNew();
            //var fileReader = new FileReader();
            //var result = fileReader.Read(@"C:\Users\Daniel\Pictures\Screenpresso");
            //var size = await result;
            //stopwatch.Stop();

            //Console.WriteLine($"Finished in: {stopwatch.ElapsedMilliseconds} ms, size { size } and result = { result}");

        }
    }
}
