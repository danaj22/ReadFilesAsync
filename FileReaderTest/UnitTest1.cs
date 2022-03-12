using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FileReaderTest
{
    [TestClass]
    public class UnitTest1
    {
        public async Task ThrowException()
        {
            await Task.Delay(200);
            Debug.WriteLine("2");
            await Task.Delay(200);
            throw new Exception("b³êdas");
        }


        [TestMethod]
        public async Task TestMethod1()
        {
            var exceptionHandled = false;
            Debug.WriteLine("1");

            var task = ThrowException();

            try
            {

                Debug.WriteLine("3");

                await task;
                Debug.WriteLine("4");
            }
            catch
            {
                exceptionHandled = true;
            }
            Assert.IsTrue(exceptionHandled);
        }


    }
}
