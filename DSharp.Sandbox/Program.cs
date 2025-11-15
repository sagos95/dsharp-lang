using DSharp.Sandbox.Generated;

namespace DSharp.Sandbox;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== D# Language Sandbox ===");
        Console.WriteLine("Testing D# to C# translation...\n");
        
        // Call methods from generated .ds files
        Console.WriteLine("--- Example 1: Static Methods ---");
        Example.HelloFromDSharp();
        Example.PrintMessage("This is D# in action!");
        
        Console.WriteLine("\n--- Example 2: Calculator Class ---");
        var calc = new Calculator();
        calc.Add(10);
        calc.Add(5);
        calc.Subtract(3);
        calc.DisplayResult();
        Console.WriteLine($"Final result from GetResult(): {calc.GetResult()}");
        
        Console.WriteLine("\n--- Example 3: Async Methods with D# ---");
        await AsyncExample.RunMultipleTasks();
        
        Console.WriteLine("\n--- Example 4: AUTO-ASYNC in D# ---");
        Console.WriteLine("Testing automatic async/await detection...\n");
        
        var autoAsync = new AutoAsyncExample();
        
        // Test 1: func with Task.Delay → async Task
        await autoAsync.DelayedPrint("Test Message");
        
        // Test 2: int with Task.Delay → async Task<int>
        var result = await autoAsync.CalculateWithDelay();
        Console.WriteLine($"Calculation result: {result}");
        
        // Test 3: Regular synchronous method (no async)
        autoAsync.RegularMethod();
        
        // Test 4: string with Task.Delay → async Task<string>
        var message = await autoAsync.GetMessageAsync();
        Console.WriteLine($"Async message: {message}");
        
        // Test 5: Multiple delays
        await autoAsync.MultipleDelays();
        
        // Test 6: Propagation - method calling async methods
        await autoAsync.CallOtherAsyncMethods();
        
        // Test 7: Task.Run
        var runResult = await autoAsync.UseTaskRun();
        Console.WriteLine($"Task.Run result: {runResult}");
        
        // Test 8: Fire-and-forget with Run.Async
        autoAsync.StartBackgroundTask();
        await Task.Delay(100); // Small delay to see the output
        
        Console.WriteLine("\n=== Sandbox Complete ===");
    }
}

