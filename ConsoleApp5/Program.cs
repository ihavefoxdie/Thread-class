namespace Testing
{

    public class Program
    {
        static Semaphore semaphoreObj = new(2, 2);

        public static void Print()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: Text!");
            }

        }

        public static void Loader()
        {
            while (true)
            {
                semaphoreObj.WaitOne();
                //Console.WriteLine($"{Thread.CurrentThread.Name}");
                //Thread.Sleep(1);
                semaphoreObj.Release();

            }
        }

        public static void Main()
        {

            for (int i = 0; i < 3; i++)
            {
                Thread thread = new(Print)
                {
                    Name = "Thread " + i.ToString()
                };
                //thread.IsBackground = true;            //this line of code is most likely going to make it so that no thread ever manages to execute Print()
                thread.Start();
            }

            for (int i = 0; i < 6; i++)
            {
                Thread hell = new(Loader)
                {
                    Name = "Thread " + i.ToString()
                };
                hell.Start();
            }

        }
    }
}
