import {Container, Menu, Link} from "./style";

export function Header() {

    return (

       <Container>

            <Menu>

                <Link>
                    <img src="" alt="Logo"/>
                </Link>
                <Link>
                    <a href="#">Contas e Listas</a>                    
                </Link>
                <Link>
                    <a href="#">Devoluções e Pedidos</a>                    
                </Link>
                <Link>
                    <a href="#">Carrinho</a>
                </Link>

            </Menu>

       </Container>

    );

}