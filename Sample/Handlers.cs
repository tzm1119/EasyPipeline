using System;

namespace Sample
{
   using System;
using System.Threading.Tasks;
using EasyPipeline;

namespace UT
{
    public class ExceptionHandler : Handler<TestContext>
    {
        protected override async Task Handle(TestContext data)
        {
            try
            {
                data.CallBy(nameof(ExceptionHandler));
                //call next handler
                await base.Handle(data);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }
    }

    public class FirstHandler : Handler<TestContext>
    {
        protected override async Task Handle(TestContext data)
        {
            data.CallBy(nameof(FirstHandler));
            await base.Handle(data);
        }
    }
    public class SecondtHandler : Handler<TestContext>
    {
        protected override async Task Handle(TestContext data)
        {
            //first call
            data.CallBy(nameof(SecondtHandler));

            await base.Handle(data);
            //second call
            data.CallBy(nameof(SecondtHandler));

        }
    }

    public class ThirdHandler : Handler<TestContext>
    {
        protected override async Task Handle(TestContext data)
        {
            data.CallBy(nameof(ThirdHandler));
            await base.Handle(data);
        }
    }
}

}
