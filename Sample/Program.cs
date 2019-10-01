using System;
using System.Threading.Tasks;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1().Wait();

        }

        public async Task Test1()
        {
            TestContext context = new TestContext();

            await new ExceptionHandler()
                .SetRoot()
                .Next(new FirstHandler())
                .Next(new SecondtHandler())
                .Next(new ThirdHandler())
                .Run(context);
        }
    }
}
