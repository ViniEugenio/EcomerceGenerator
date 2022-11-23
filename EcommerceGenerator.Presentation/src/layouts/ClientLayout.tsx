import { Outlet } from "react-router-dom";
import { ClientsProvider } from "../hooks/useClients";

export function ClientLayout() {

    return(

        <ClientsProvider>
            <Outlet/>
        </ClientsProvider>

    );

}