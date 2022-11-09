import styled from "styled-components";

export const Container = styled.div`

    text-align: center;    

    h2 {
        font-size: 1.3rem;
    }

    button {

        width: 40%;
        border-radius: 0.25rem;
        border: 0;
        font-weight: 600;
        font-size: 1rem;
        margin-top: 1.5rem;
        margin-right: 1.5rem;
        height: 3rem;
        color: #FFF;        
        transition: filter .2s;

        &:hover {
            filter: brightness(0.9);
        }

    }

    button:nth-child(3) {
        background-color: var(--green);
    }

    button:nth-child(4) {
        background-color: var(--red);
    }

`;