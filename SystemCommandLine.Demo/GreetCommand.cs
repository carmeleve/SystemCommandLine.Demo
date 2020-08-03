using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

namespace SystemCommandLine.Demo
{
    public class GreetCommand : Command
    {
        private readonly GreetOptions options;

        public GreetCommand(GreetOptions options)
           : base("greet", "Says a greeting to the specified person.")
        {
            var name = new Option<string>("name")
            {
                Name = "name",
                Description = "The name of the person to greet.",
                IsRequired = true
            };

            this.AddOption(name);

            this.Handler = CommandHandler.Create(
                (string name) => this.HandleCommand(name));
            this.options = options;
        }

        private int HandleCommand(string name)
        {
            try
            {
                Console.WriteLine($"{this.options.Greeting} {name}!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 1;
            }

            return 0;
        }
    }
}