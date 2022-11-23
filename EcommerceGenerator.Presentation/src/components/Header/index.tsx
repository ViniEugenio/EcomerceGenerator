import { NavLink } from "react-router-dom";
import {Container, Menu, Link} from "./style";

interface LinkObj {
    active: boolean;
    url: string;    
}

export function Header() {

    const Links: LinkObj[] = [{active:false,url:''}]

    return (

       <Container>

            <Menu>

                <Link active={true}>
                    <img src="" alt="Logo"/>
                </Link>
                <Link active={false}>
                    <NavLink to="clients">Clientes</NavLink>                    
                </Link>      
                <Link active={false}>
                    <NavLink to="product/create">Cadastrar Produto</NavLink>                    
                </Link>         

            </Menu>

       </Container>

    );

}