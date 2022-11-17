import { AxiosResponse } from "axios";
import { cliente } from "../models/cliente";
import { response } from "../models/response";
import { service } from "./service";

export class clienteService extends service {

    constructor() {
        super('admin/client');
    }

    async GetAllClients(): Promise<AxiosResponse<cliente[], any>> {
       return await this.get<cliente[]>('');              
    } 

    async CreateClient(body: any): Promise<AxiosResponse<response, any>> {        
        return await this.post('', body);
    }

    async ChangeStatusClient(clientId: string): Promise<AxiosResponse<response, any>> {
        return await this.patch(`${clientId}`, null);
    }

    async UpdateClient(body: cliente): Promise<AxiosResponse<response,any>> {
        return await this.put<response>('', body);
    }

    async UpdateOutdatedClient(clientId: string): Promise<AxiosResponse<response, any>> {
        return await this.put(`${clientId}`, null);
    }

    async UpdatedOutdatedClients(): Promise<AxiosResponse<response, any>> {
        return await this.put('UpdateOutdatedClients', null);
    }

}