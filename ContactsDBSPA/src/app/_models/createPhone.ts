export class CreatePhone {


    public PersonId: string;
    public Number: string;
    public Name: string;


    constructor(personId, phoneNumber, name) {
        this.PersonId = personId;
        this.Number = phoneNumber;
        this.Name = name;

}

}
