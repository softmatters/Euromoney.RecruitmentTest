using Autofac;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // hooking up DI and moving the code to the TextAnalyser Start method

            // Create the builder with which components/services are registered.
            var builder = new ContainerBuilder();

            // Register types that expose interfaces...
            builder.RegisterType<TextAnalyserService>().As<ITextAnalyserService>().SingleInstance();
            builder.RegisterType<WordsRepository>().As<IWordsRepository>().SingleInstance();
            builder.RegisterType<TextAnalyser>().SingleInstance();

            var container = builder.Build();

            var textAnalyser = container.Resolve<TextAnalyser>();

            textAnalyser.Start();
        }
    }
}