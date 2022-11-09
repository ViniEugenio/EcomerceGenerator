import { FormEvent, useState } from 'react';
import Modal from 'react-modal';
import { cliente } from '../../../../models/cliente';
import { FaTimes } from "react-icons/fa";
import { Container, ContainerErrors, Input } from './style';

interface UpdateClientModalProps {
    isOpen: boolean;
    modalHandler: () => void;
    ActualClient: cliente;
}

export function UpdateClientModal({isOpen, modalHandler, ActualClient}: UpdateClientModalProps) {   

    const[nameError, setNameError] = useState(false);
    const[nameListError, setNameListError] = useState<string[]>([]);

    const[hostError, setHostError] = useState(false);
    const[hostListError, setHostListError] = useState<string[]>([]);

    function handleUpdateClient(event: FormEvent) {

        event.preventDefault();

    }

    return(

        <Modal 
        isOpen={isOpen} 
        onRequestClose={modalHandler}
        overlayClassName="modal-overlay"
        className="modal-content"
        >

            <Container onSubmit={handleUpdateClient}>

                <FaTimes className="icone modal-close" onClick={modalHandler}/>
                <h2>Alterar cliente</h2>

                <Input value={ActualClient.name} placeholder='Digite o nome do cliente' 
                    onChange={event => {

                        ActualClient.name = event.target.value;
                        setNameListError([]);

                    }}
                    haveError={nameError}/>                

                    { nameListError.map( error => (

                        <ContainerErrors>

                            <ul>
                                <li>{error}</li>
                            </ul>   

                        </ContainerErrors>                    

                    ))}

                <Input value={ActualClient.host} placeholder='Digite o host do cliente'
                    onChange={event=> {
                    
                        ActualClient.host = event.target.value;
                        setHostListError([]);

                    }}
                    haveError={hostError}/>

                { hostListError.map( error => (

                    <ContainerErrors>

                        <ul>
                            <li>{error}</li>
                        </ul>                        

                    </ContainerErrors>

                ))}

                <button type='submit'>Alterar</button>

            </Container>

       </Modal>

    )

}