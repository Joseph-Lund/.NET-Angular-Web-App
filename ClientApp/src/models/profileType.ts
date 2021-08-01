class ProfileType{
    givenName: string;
    surname: string;
    userPrincipalName: string;
    id: string

    constructor(_givenName: string, _surname: string, _userPrincipalName: string, _id: string){
        this.givenName = _givenName;
        this.surname = _surname;
        this.userPrincipalName = _userPrincipalName;
        this.id = _id;
    }
}