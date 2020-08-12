using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WebappVisualTester.Converters;

namespace WebappVisualTester.Models
{
    public class Test
    {
        public Test()
        {
            Id = Guid.NewGuid();
            Commands = new List<ICommand>();
        }

        public Guid Id { get; set; }

        public int OrderIndex { get; set; }

        public string Title { get; set; }

        //[JsonConverter(typeof(ConcreteTypeConverter<Command>))]
        public List<ICommand> Commands { get; set; }
        public string _type => GetType().Name;
        public Test GetClone()
        {
            Test test = new Test();
            test.Id = Guid.NewGuid();
            test.OrderIndex = 0;
            test.Title = this.Title;

            Dictionary<Guid, Guid> localToClonedCommands = new Dictionary<Guid, Guid>();

            foreach (var cmd in this.Commands)
            {
                ICommand clonedCommand = cmd.GetClone();
                localToClonedCommands.Add(cmd.Id, clonedCommand.Id);
                test.Commands.Add(clonedCommand);
            }
            foreach(var cmd in test.Commands)
            {
                if(cmd.BelongsToCommandIndex.HasValue)
                {
                    cmd.BelongsToCommandIndex = localToClonedCommands[cmd.BelongsToCommandIndex.Value];
                }
            }
            return test;
        }
    }
}
