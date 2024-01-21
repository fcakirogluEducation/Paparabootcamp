namespace PaparaApp.API.AsynchoronousProgramming;

public class SynchronousProgramming
{
    // var olan thread'in bloke olmasına sebep olur.

    public void Method1()
    {
        var response = new HttpClient().GetAsync("https://wwww.google.com").Result;
    }
}

public class AsynchronousProgramming
{
    // var olan thread'in bloke olmaz
    // async-await design pattern'i kullanılır.

    public async Task<string> Method1()
    {
        var response = await new HttpClient().GetAsync("https://wwww.google.com"); //10 sn

        var responseAsString = await response.Content.ReadAsStringAsync();

        return responseAsString;
    }
}

public class MultithreadProgramming
{
    public Task Method1()
    {
        // c# 4.0 Task Parallel Library (TPL)
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var helper = new Helper();


        // parallel programming
        Parallel.ForEach(numbers, new ParallelOptions { MaxDegreeOfParallelism = 6 },
            item => { helper.Calculate(item, item + 1); });


        Parallel.ForEach(numbers, item => { helper.Calculate(item, item + 1); });

        Parallel.For(0, numbers.Count, item => { helper.Calculate(item, item + 1); });

        return Task.CompletedTask;
        //foreach (var item in numbers)
        //{
        //    Task.Run(() =>
        //    {
        //        var result = helper.Calculate(item, item + 1);

        //    });

        //    //helper.Calculate(item, item + 1);
        //}
    }
}

public class Helper
{
    public int Calculate(int a, int b)
    {
        return a + b;
    }

    public Task CalculateWithNoResultAsync(int a, int b)
    {
        var result = a + b;
        return Task.CompletedTask;
    }

    public Task<int> CalculateAsync(int a, int b)
    {
        var result = a + b;
        return Task.FromResult(result);
    }
}