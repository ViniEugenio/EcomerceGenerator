import { FormInput } from "../../CommonComponents/Inputs/FormInput";
import { Container, IconContainer, LoginBox, LoginButton, OptionsContainer } from "./style";
import { FaUserCircle } from "react-icons/fa";

export function LoginComponent(){

    return (
        <Container>

            <LoginBox>

                <IconContainer>

                    <FaUserCircle/>
                    <h2>LOGIN</h2>

                </IconContainer>

            
                <FormInput Type="text" TextLabel="UserName ou Email" Heigth={3} Width={100}></FormInput>
                <FormInput Type="password" TextLabel="Senha" Heigth={3} Width={100}></FormInput>

                <OptionsContainer>

                    <LoginButton>Login</LoginButton>
                    <span>Me manter logado</span>
                    <span>Esqueceu sua senha? <a href="google.com">clique aqui</a></span>
                    <span>Ainda não é usuário? <a href="google.com">clique aqui</a></span>

                </OptionsContainer>

            </LoginBox>

        </Container>
    );

}