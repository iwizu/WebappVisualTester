using JsonSubTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebappVisualTester.Models
{
    public class Command : ICommand
    {
        public Command()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public int OrderIndex { get; set; }
        public string Title { get; set; }
        public int? BelongsToCommandIndex { get; set; }

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
    }
}
