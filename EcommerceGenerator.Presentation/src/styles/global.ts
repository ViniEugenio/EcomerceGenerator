import {createGlobalStyle} from 'styled-components'

export const GlobalStyle = createGlobalStyle`


    :root {

        --blue: #314AD7;
        --green: #0FEC45;
        --red: #EE2110;
        --background: #e1dede;

    }

    * {

        margin: 0;
        padding: 0;
        box-sizing: border-box;

    }

    body {

        background-color: var(--background);        

    }

    body, input {

        font-family: 'Poppins', sans-serif;
        
    }

    button {

        cursor: pointer;

    }

    [disabled] {

        cursor: not-allowed;
        
    }

    .icone {

        font-size: 1.7em;
        cursor: pointer;        
        margin: 5px;
        color: var(--blue);
        transition: ease-in-out .2s;        

    }

    .icone:hover {

        filter: contrast(1.75);

    }

    .modal-overlay {

        background: rgba(0,0,0,0.5);

        position: fixed;
        top:0;
        bottom: 0;
        right: 0;
        left: 0;

        display: flex;
        align-items: center;
        justify-content: center;

    }

    .modal-content {

        width: 100%;
        max-width: 576px;
        background: var(--background);
        padding: 3rem;
        position: relative;
        border-radius: 0.25rem;

    }

    .modal-close {
        position: absolute;
        right: .5rem;
        top: .5rem;
        border: 0;
    }

`;