using JsonSubTypes;
using Newtonsoft.Json;
using System;

namespace WebappVisualTester.Models
{
    public abstract class Command : ICommand
    {
        protected Command()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public int OrderIndex { get; set; }
        public string Title { get; set; }
        public Guid? BelongsToCommandIndex { get; set; }

        public string _type => GetType().Name;
public static JsonConverter StandardJsonConverter
        {
            get
            {
                return JsonSubtypesConverterBuilder
                    .Of(typeof(Command), "_type")
                    .Build();
            }
        }

        public abstract ICommand GetClone();
        
    }
}
