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

        public static TResult TryExecuteWithResult<TResult>(Func<TResult> action)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Problem occured while trying to perform action:{ex}");
                throw ex;
            }
        }
    }
}
