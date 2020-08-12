using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using WebappVisualTester.Models;

namespace WebappVisualTester.Converters
{
    public class CustomJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Command).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);


            string type = (string)jo["_type"];

            if (type == typeof(Project).Name)
            {
                Project item = new Project();
                serializer.Populate(jo.CreateReader(), item);
                return item;
            }
            else if (type == typeof(Test).Name)
            {
                Test item = new Test();
                serializer.Populate(jo.CreateReader(), item);
                return item;
            }
            else if (type == typeof(NavigateToUrlCommand).Name)
            {
                Command item = new NavigateToUrlCommand();
                serializer.Populate(jo.CreateReader(), item);
                return item;
            }
            else if (type == typeof(TakeScreenshotCommand).Name)
            {
                Command item = new TakeScreenshotCommand();
                serializer.Populate(jo.CreateReader(), item);
                return item;
            }
            else if (type == typeof(IfContainsStringCommand).Name)
            {
                Command item = new IfContainsStringCommand();
                serializer.Populate(jo.CreateReader(), item);
                return item;
            }
            else if (type == typeof(FillTextboxCommand).Name)
            {
                Command item = new FillTextboxCommand();
                serializer.Populate(jo.CreateReader(), item);
                return item;
            }
            else if (type == typeof(ClickButtonCommand).Name)
            {
                Command item = new ClickButtonCommand();
                serializer.Populate(jo.CreateReader(), item);
                return item;
            }
            return null;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer,
            object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
