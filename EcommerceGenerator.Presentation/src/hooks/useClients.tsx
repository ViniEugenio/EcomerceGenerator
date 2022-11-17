import {createContext, ReactNode, useContext, useEffect, useState} from 'react';
import { cliente } from '../models/cliente';
import { response } from '../models/response';
import { clienteService } from '../services/clienteService';

interface clientCreateData {
    name: string;
    host: string;   
}

interface clientContextData {

    clients: cliente[];
    CreateClient: (model: clientCreateData) => Promise<string[]>;
    ChangeStatusClient: (clientId: string) => void;
    UpdateClient: (model: cliente) => Promise<string[]>;
    UpdateOutdatedClient: (clientId: string) => void;
    UpdatedOutdatedClients: () => void;

}

interface ClientContextProps {
    children: ReactNode;
}

const ClientsContext = createContext<clientContextData>({} as clientContextData);
const clientService = new clienteService();

export function ClientsProvider({children} : ClientContextProps) {

    const [clients, setClients] = useState<cliente[]>([]);

    useEffect(() => {

        const fetchData = async () => {

            await clientService.GetAllClients()
            .then(response=> {
              setClients(response.data);
            })
            .catch(error => alert(error));

        }     

        fetchData();

    }, []);

    async function CreateClient(model: clientCreateData): Promise<string[]> {

        let errors: string[] = [];

        await clientService.CreateClient(model)
        .then(response => {

            const NewClient: cliente = response.data.data;
            NewClient.updatedDatabase = true;

            setClients([NewClient, ...clients]);       

        })
        .catch(error=> {
            errors = error.response.data.errors;
        });

        return errors;
       
    }

    function ChangeStatusClient(clientId: string) {
            
        clientService.ChangeStatusClient(clientId)
        .then( () => {

            setClients(clients.map(client => {

                if(client.id === clientId) {

                    client.active = !client.active;                   

                }

                return client;

            }));

        })
        .catch(error=>{

            alert('Erro');

        });

    }

    async function UpdateClient(model: cliente): Promise<string[]> {

        let errors: string[] = [];

       await clientService.UpdateClient(model)
        .then(response => {          

           setClients(clients.map(client => {

                if(client.id === model.id) {
                    return response.data.data;
                }

                return client;

           }));

        })
        .catch(error => {
            errors = error.response.data.errors;
        });

        return errors;

    }

    async function UpdateOutdatedClient(clientId: string) {

        await clientService.UpdateOutdatedClient(clientId)
        .then(response => {

            setClients(clients.map(client=> {

                if(client.id == clientId) {
                    client.updatedDatabase = true;                   
                }

                return client;

            }));

        })
        .catch(error =>{
            alert(error.response.data.message);
        });

    }

    async function UpdatedOutdatedClients() {

        await clientService.UpdatedOutdatedClients()
        .then(response=> {

            setClients(clients.map(client=> {

                if(!client.updatedDatabase) {
                    client.updatedDatabase = true;                   
                }

                return client;

            }));

        })
        .catch(error =>{
            alert(error.response.data.message);
        });

    }

    return(

        <ClientsContext.Provider value={{
            clients,
            CreateClient,
            ChangeStatusClient,
            UpdateClient,
            UpdateOutdatedClient,
            UpdatedOutdatedClients
        }}>

            {children}

        </ClientsContext.Provider>

    )

}

export function useClients() {

    var context = useContext(ClientsContext);
    return context;

}