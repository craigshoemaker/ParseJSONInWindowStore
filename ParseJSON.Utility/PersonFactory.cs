using System;
using System.Collections.Generic;
using Windows.Data.Json;

namespace ParseJSON.Utility
{
    internal class PersonFactory
    {
        public static Person Create(string jsonString)
        {
            JsonValue json;
            Person person = new Person();

            if (JsonValue.TryParse(jsonString, out json))
            {
                person = PersonFactory.Create(json);
            }

            return person;
        }

        public static Person Create(JsonValue personValue)
        {
            Person person = new Person();

            JsonObject jsonObject = personValue.GetObject();

            int? id = jsonObject.GetIntegerValue("id");
            if (id.HasValue)
            {
                person.Id = id.Value;
            }

            person.FirstName = jsonObject.GetStringValue("firstName");
            person.LastName = jsonObject.GetStringValue("lastName");
            
            bool? isOnWestCoast = jsonObject.GetBooleanValue("isOnWestCoast");
            if (isOnWestCoast.HasValue)
            {
                person.IsOnWestCoast = isOnWestCoast.Value;
            }

            return person;
        }

        public static IList<Person> CreateList(string peopleJson)
        {
            List<Person> people = new List<Person>();
            JsonArray array = new JsonArray();

            if (JsonArray.TryParse(peopleJson, out array))
            {
                if (array.Count > 0)
                {
                    foreach (JsonValue value in array)
                    {
                        people.Add(PersonFactory.Create(value));
                    }
                }
            }

            return people;
        }
    }
}
/*

"{
    '_backingData': {
        'firstName': 'Craig'
    },
    'firstName': 'Craig',
    'backingData': {
        'firstName':'Craig'}
}"

*/