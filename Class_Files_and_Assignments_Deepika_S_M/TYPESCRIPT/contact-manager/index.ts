interface Contact {
  id: number;
  name: string;
  email: string;
  phone: string;
}

class ContactManager {
  private contacts: Contact[] = [];

  addContact(contact: Contact): void {
    this.contacts.push(contact);
    console.log("Contact added.");
  }

  viewContacts(): Contact[] {
    return this.contacts;
  }

  modifyContact(id: number, updated: Partial<Contact>): void {
    const contact = this.contacts.find(c => c.id === id);
    if (!contact) {
      console.log("Contact not found.");
      return;
    }
    Object.assign(contact, updated);
    console.log("Contact modified.");
  }

  deleteContact(id: number): void {
    const index = this.contacts.findIndex(c => c.id === id);
    if (index === -1) {
      console.log("Contact not found.");
      return;
    }
    this.contacts.splice(index, 1);
    console.log("Contact deleted.");
  }
}

// Test
const manager = new ContactManager();

manager.addContact({ id: 1, name: "Alice", email: "alice@mail.com", phone: "1234567890" });
manager.addContact({ id: 2, name: "Bob", email: "bob@mail.com", phone: "9876543210" });

console.log(manager.viewContacts());

manager.modifyContact(1, { phone: "1112223333" });
manager.deleteContact(2);

console.log(manager.viewContacts());
