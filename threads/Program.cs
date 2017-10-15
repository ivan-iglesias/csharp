using System;
using System.Threading;

/*
 * A thread is analogous to the operating system process in which your application runs.
 * Just as processes run in parallel on a computer, threads run in parallel within a single process.
 * Processes are fully isolated from each other; threads have just a limited degree of isolation.
 * In particular, threads share (heap) memory with other threads running in the same application.
 * 
 * http://eledwin.com/blog/tutorial-de-hilos-en-c-con-ejemplos-parte-2-35
 * http://www.albahari.com/threading/
*/

namespace threads
{
    class Program
    {
        static void Main(string[] args)
        {
            // Asigno un nombre al hilo principal.
            Thread.CurrentThread.Name = "main";

            Messages message = new Messages();
            Download download = new Download("FileToDownload");

            // Al instanciar Thread, debemos pasarle por argumento la instancia de un
            // delegado, el cual apunta al proceso a ejecutar. En C# es opcional, ya
            // que el compilador seleccionara el delegado correspondiente.
            ThreadStart _delegate = new ThreadStart(message.ShowA);

            Thread threadA = new Thread(_delegate);
            Thread threadB = new Thread(message.ShowB);
            Thread threadC = new Thread(new ParameterizedThreadStart(message.ShowC));
            Thread threadD = new Thread(() => message.ShowD("Hello"));
            Thread threadE = new Thread(download.start);

            // Inicializo los hilos.
            threadA.Start();
            threadB.Start();
            threadC.Start("Good By");
            threadD.Start();

            // Doy nombre nombre al hilo de descarga.
            threadE.Name = "Downloading Thread";
            threadE.Start();

            // Interrumpo el hilo A.
            threadA.Interrupt();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"PARENT {i}");
                Thread.Sleep(100);
            }

            // Espero a que termine el hilos de descarga.
            threadE.Join();

            Console.WriteLine("============================");
            Console.ReadKey();
        }
    }

    class Messages
    {
        public void ShowA()
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Message from A");
                    Thread.Sleep(150);
                }
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine("ShowA has been interrupted by main thread.");
            }
        }

        public void ShowB()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Message from B");
                Thread.Sleep(200);
            }
        }

        public void ShowC(object arg)
        {
            string text = (string)arg;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Message from C: {text}");
                Thread.Sleep(200);
            }
        }

        public void ShowD(string arg)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Message from D: {arg}");
                Thread.Sleep(200);
            }
        }
    }

    public class Download
    {
        string _filename;

        public Download(string filename)
        {
            _filename = filename;
        }

        public void start()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Downloading: {_filename}");
                Thread.Sleep(300);
            }
        }
    }
}
