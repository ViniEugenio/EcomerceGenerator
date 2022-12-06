import styled from "styled-components";

export const Container = styled.div`
    height: 60rem;  
    display :flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
`;

export const LoginBox = styled.div`

    background-color: white;
    height: 35rem;
    width: 30rem;
    border-radius: 10px;
    display :flex;
    flex-direction: column;
    justify-content: center;

`

export const IconContainer = styled.div`

    display: flex;
    flex-direction: column;
    align-items: center;

    svg {
        
        font-size: 4.7em;
        margin: 5px;
        color: var(--blue);
        
    }

`;

export const OptionsContainer = styled.div`

    display: flex;
    flex-direction: column;
    align-items: center;

    a {
        text-decoration: none;
        transition: ease-in-out .2s;
    }

    a:hover {
        padding: 0 2px;
    }

`;

export const LoginButton = styled.button`

    background-color: var(--blue);
    border: none;
    width: 30%;
    height: 3rem;
    border-radius: 10px;
    color: white;
    font-size: 18px;
    margin: 10px 0;
    transition: ease-in-out .2s;    

    :hover {
        filter: contrast(1.75);
    }

`;