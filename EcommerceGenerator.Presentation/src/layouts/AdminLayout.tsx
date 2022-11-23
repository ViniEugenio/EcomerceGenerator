import { Outlet } from "react-router-dom";
import { Header } from "../components/Header";
import { ClientsProvider } from "../hooks/useClients";
import { ContentPage } from "../styles/commonStyles";

export function AdminLayout() {

    return(

        <div>
            <Header/>
            <ContentPage>
                <Outlet/>
            </ContentPage>
            
        </div>

    );

}