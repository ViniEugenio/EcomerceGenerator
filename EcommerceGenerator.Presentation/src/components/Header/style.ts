import styled from "styled-components";

export const Container = styled.header`

    width: 100%;
    background-color: var(--blue);    
    padding: 5px 0;

`;

export const Menu = styled.ul`

    display: flex;
    flex-direction: row;
    justify-content: center;
    list-style: none;

`;

export const Link = styled.li`

    margin: 0 5px;
    padding: 10px 5px;   
    text-align: center;

    &:hover {

        cursor: pointer;
        outline: 1px solid #FFF;
        border-radius: 5px;

    }

    a {

        text-decoration: none;
        color: #FFF;        

    }

`;