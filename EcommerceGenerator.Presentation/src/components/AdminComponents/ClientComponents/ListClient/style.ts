import styled from "styled-components";

export const Container = styled.div`

    width: 80%;
    margin: 0 auto;

`;

export const Tabela = styled.table`

    width: 100%;
    border-collapse: collapse; 

`;

export const Cabecalho = styled.tr`

    background-color: var(--blue);
    color: #FFF;
    font-size: 18px;

`;

export const THead = styled.th`

    padding: 12px 0;

`;

export const Dados = styled.tr`

    background-color: var(--background);
    text-align: center;    

`;

export const Dado = styled.td`

    padding: 12px;

`;

export const ContainerOpcoes = styled.div`

    display: flex;
    flex-direction: row-reverse;
    margin: 10px 0;

`;