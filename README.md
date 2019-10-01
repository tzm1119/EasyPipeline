# EasyPipeline
This lib aims at build a pipeline for handle a complex process in the easiest way

## Build and run pipeline

```c#
public async Task ComplexTask()
{
    TestContext context = new TestContext();

    await new ExceptionHandler()
        .SetRoot()
        .Next(new FirstHandler())
        .Next(new SecondtHandler())
        .Next(new ThirdHandler())
        .Run(context);
}
```

## Context
```c#
public class TestContext
{
    public int CallCount { get; set; }

    public void CallBy(string caller)
    {
        CallCount++;
        System.Console.WriteLine($"caller is {caller} CallCount={CallCount}");
    }
}
```
## Handler
```c#
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
```
