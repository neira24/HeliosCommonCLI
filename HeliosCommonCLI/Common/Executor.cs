namespace HeliosCommonCLI
{
    public static class Executor
    {
        public static void TryExecute(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Problem occured while trying to perform action:{ex}");
            }
        }
    }
}
