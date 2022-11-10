import {createContext, ReactNode, useEffect, useState} from 'react';
import { cliente } from '../../../models/cliente';
import { response } from '../../../models/response';
import { api } from '../../../services/api';

interface clientCreateData {
    name: string;
    host: string;   
}

interface clientContextData {

    clients: cliente[];
    CreateClient: (model: clientCreateData) => Promise<string[]>;
    ChangeStatusClient: (clientId: string) => void;
    UpdateClient: (model: cliente) => Promise<string[]>;

}

interface ClientContextProps {
    children: ReactNode;
}

export const ClientsContext = createContext<clientContextData>({} as clientContextData);

export function ClientsProvider({children} : ClientContextProps) {

    const [clients, setClients] = useState<cliente[]>([]);

    useEffect(() => {

        api.get<cliente[]>('https://localhost:7159/api/admin/client') 
        .then(response => {

            setClients(response.data);           

        })
        .catch(error=> alert(error));

    }, []);

    async function CreateClient(model: clientCreateData): Promise<string[]> {

        let errors: string[] = [];

        await api.post<response>('https://localhost:7159/api/admin/client', model)
        .then( response => {
            
            const NewClient: cliente = response.data.data;
            NewClient.updatedDatabase = true;

            setClients([NewClient, ...clients]);           

        })
        .catch(error => {
            errors = error.response.data.errors;
        });     
        
        return errors;
       
    }

    function ChangeStatusClient(clientId: string) {
            
        api.patch<response>(`https://localhost:7159/api/admin/client/${clientId}`)
        .then( response => {

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

        await api.put<response>('https://localhost:7159/api/admin/client', model)
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

    return(

        <ClientsContext.Provider value={{
            clients,
            CreateClient,
            ChangeStatusClient,
            UpdateClient
        }}>

            {children}

        </ClientsContext.Provider>

    )

}