using System;

namespace Sample
{
     public class TestContext
    {
        public int CallCount { get; set; }

        public void CallBy(string caller){
            CallCount++;
            System.Console.WriteLine($"caller is {caller} CallCount={CallCount}");
        }
    }
}
