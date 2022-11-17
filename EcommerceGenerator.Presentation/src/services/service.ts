import axios, { AxiosInstance, AxiosResponse } from 'axios'

export class service {

    private api: AxiosInstance;    

    constructor(endPoint: string) {

        this.api = axios.create({

            baseURL:`https://localhost:7159/api/${endPoint}/`
        
        });

    }

    protected async get<T>(endPoint: string): Promise<AxiosResponse<T, any>> {
        return await this.api.get<T>(endPoint);
    }

    protected async post<T>(endPoint: string, body: any): Promise<AxiosResponse<T, any>> {
        return await this.api.post<T>(endPoint, body);
    }

    protected async patch<T>(endPoint: string, body: any): Promise<AxiosResponse<T, any>> {
        return await this.api.patch<T>(endPoint, body);
    }

    protected async put<T>(endPoint: string, body: any): Promise<AxiosResponse<T, any>> {
        return await this.api.put<T>(endPoint, body);
    }

}