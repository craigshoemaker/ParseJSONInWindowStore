(function () {
    "use strict";

    var _model = {

        contact: {
            id: 1000,
            firstName: "Craig",
            lastName: "Shoemaker"
        },

        contacts: [
            {
                id: 1001,
                firstName: "Craig",
                lastName: "Shoemaker",
                isOnWestCoast: "true"
            },
            {
                id: 1002,
                firstName: "Jason",
                lastName: "Beres",
                isOnWestCoast: "0"
            }
        ]
    }

    var _vm = {
        ViewModel: WinJS.Binding.as({
            model: _model,
            contactMsg: "",
            contactsMsg: "",

            addContact: function () {
                var controller = ParseJSON.Utility.ContactsController();
                var jsonString = JSON.stringify(_vm.ViewModel.model.contact);
                controller.addContactAsync(jsonString).done(function (response) {
                    _vm.ViewModel.contactMsg = response;
                });
            },

            addContacts: function () {
                var controller = ParseJSON.Utility.ContactsController();
                var jsonString = JSON.stringify(_vm.ViewModel.model.contacts);
                controller.addContactsAsync(jsonString).done(function (response) {
                    _vm.ViewModel.contactsMsg = response;
                });
            }
        })
    };

    WinJS.Namespace.define("Application.Pages", { "Home": _vm });

    WinJS.UI.Pages.define("/pages/home/home.html", {
        
        ready: function (element, options) {
            WinJS.Binding.processAll(null, Application.Pages.Home.ViewModel);

            Application.Pages.Home.ViewModel.addContact();
            Application.Pages.Home.ViewModel.addContacts();
        }
    });
})();
