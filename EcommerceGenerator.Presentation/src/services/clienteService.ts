import { api } from "./api";

export class clientService {

    public GetAllClients() {

        api.get('client')
        .then(response => console.log(response.data));

    }

}