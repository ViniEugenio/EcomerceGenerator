import { SearchBar } from "../../CommonComponents/Inputs/Search";
import { CardProduct } from "../CardProduct";
import { DivList, Container } from "./style";

export function ListProduct() {

    return (
       
        <>
        
            <Container>

                <SearchBar/>

                <DivList id="productList">            
                    <CardProduct/>
                    <CardProduct/>
                    <CardProduct/>
                    <CardProduct/>
                    <CardProduct/>
                    <CardProduct/>
                    <CardProduct/>
                    <CardProduct/>
                    <CardProduct/>
                    <CardProduct/>
                    <CardProduct/>
                    <CardProduct/>
                    <CardProduct/>
                    <CardProduct/>
                    <CardProduct/>
                    <CardProduct/>
                </DivList>

            </Container>
        
        </>        

    );

}