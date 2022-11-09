import styled from "styled-components";

export const Container = styled.form`

    h2 {

        font-size: 1.5rem;
        margin-bottom: 2rem;

    }

    button[type="submit"] {

        width: 100%;
        padding: 0 1.5rem;
        height: 4rem;
        background: var(--green);
        color: #FFF;
        border-radius: 0.25rem;
        border: 0;
        font-weight: 600;
        font-size: 1rem;
        margin-top: 1.5rem;

        transition: filter .2s;

        &:hover {
            filter: brightness(0.9);
        }

    }

`;

interface InputProps {
    haveError: boolean;
}

export const Input = styled.input<InputProps>`

    width: 100%;
    padding: 0 1.5rem;
    height: 4rem;
    border: 1px ${props => props.haveError ? 'solid var(--red)' : '#d7d7d7'};
    border-radius: 0.25rem;
    background: #e7e9ee;
    font-weight: 400;
    font-size: 1rem;        

    &::placeholder {
        color: #A19F9F;
    }

    & + input {
        margin-top: 1rem;
    }

`;

export const ContainerErrors = styled.div`

    color: var(--red);
    font-size: 13px;

    margin: 0 2rem 1rem;

`;
