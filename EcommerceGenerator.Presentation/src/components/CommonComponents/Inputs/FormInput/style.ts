import styled from "styled-components";

export const Container = styled.div`

    display: flex;
    flex-direction: column;
    margin: 10px;

`;

interface InputProps {
    Heigth: number;
    Width: number;
}

export const Input = styled.input<InputProps>`

    border: none;
    outline: none;
    box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
    height: ${ props=>props.Heigth }rem;
    width: ${ props=>props.Width }%;
    border-radius: 5px;
    margin-top: 5px;
    padding: 15px;
    font-size: 16px;

`;

export const Label = styled.label`

    color: black;
    margin-left: 5px;

`;