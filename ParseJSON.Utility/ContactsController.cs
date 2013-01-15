using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Foundation;

namespace ParseJSON.Utility
{
    public sealed class ContactsController
    {
        #region AddPerson Async Support
        public IAsyncOperation<string> AddContactAsync(string personJson)
        {
            return Task.Run<string>(async () =>
            {
                return await StartAddContactTask(personJson);
            }).AsAsyncOperation();
        }

        private Task<string> StartAddContactTask(string personJson)
        {
            return Task.Factory.StartNew<string>(() =>
            {
                return this.AddContact(personJson);
            });
        }
        #endregion

        private string AddContact(string personJson)
        {
            Person person = PersonFactory.Create(personJson);

            return string.Format("{0} {1} is added to the system.", 
                person.FirstName, 
                person.LastName);
        }

        #region AddPerson Async Support
        public IAsyncOperation<string> AddContactsAsync(string personJson)
        {
            return Task.Run<string>(async () =>
            {
                return await StartAddContactsTask(personJson);
            }).AsAsyncOperation();
        }

        private Task<string> StartAddContactsTask(string personJson)
        {
            return Task.Factory.StartNew<string>(() =>
            {
                return this.AddContacts(personJson);
            });
        }
        #endregion

        private string AddContacts(string personJson)
        {
            IList<Person> people = PersonFactory.CreateList(personJson);

            return string.Format("{0} {1} and {2} {3} are added to the system.",
                people[0].FirstName,
                people[0].LastName,
                people[1].FirstName,
                people[1].LastName);
        }
    }
}