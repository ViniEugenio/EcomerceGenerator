import { ClientsProvider } from "../AdminComponents/ClientComponents/ClientsContext";
import { ListClient } from "../AdminComponents/ClientComponents/ListClient";
import { ListProduct } from "../ProductComponents/ListProduct";
import { Container } from "./style";

export function ContentPage(){

    return (

        <ClientsProvider>
            <Container>                   

                <ListClient/>

            </Container>
        </ClientsProvider>

    );

}