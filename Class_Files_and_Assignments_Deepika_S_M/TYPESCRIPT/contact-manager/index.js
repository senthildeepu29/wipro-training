var ContactManager = /** @class */ (function () {
    function ContactManager() {
        this.contacts = [];
    }
    ContactManager.prototype.addContact = function (contact) {
        this.contacts.push(contact);
        console.log("Contact added.");
    };
    ContactManager.prototype.viewContacts = function () {
        return this.contacts;
    };
    ContactManager.prototype.modifyContact = function (id, updated) {
        var contact = this.contacts.find(function (c) { return c.id === id; });
        if (!contact) {
            console.log("Contact not found.");
            return;
        }
        Object.assign(contact, updated);
        console.log("Contact modified.");
    };
    ContactManager.prototype.deleteContact = function (id) {
        var index = this.contacts.findIndex(function (c) { return c.id === id; });
        if (index === -1) {
            console.log("Contact not found.");
            return;
        }
        this.contacts.splice(index, 1);
        console.log("Contact deleted.");
    };
    return ContactManager;
}());
// Test
var manager = new ContactManager();
manager.addContact({ id: 1, name: "Alice", email: "alice@mail.com", phone: "1234567890" });
manager.addContact({ id: 2, name: "Bob", email: "bob@mail.com", phone: "9876543210" });
console.log(manager.viewContacts());
manager.modifyContact(1, { phone: "1112223333" });
manager.deleteContact(2);
console.log(manager.viewContacts());
