import Modal from 'react-modal';
import { Container } from './style';
import { FaTimes } from "react-icons/fa";
import { useContext } from 'react';
import { useClients } from '../../../../hooks/useClients';

interface DeleteClientModalProps {

    isOpen: boolean;
    modalHandler: () => void;
    clientId: string;

}

export function DeleteClientModal({isOpen, modalHandler, clientId}: DeleteClientModalProps) {

    const { ChangeStatusClient } = useClients();

    function handlerDeleteClient() {

        ChangeStatusClient(clientId);
        modalHandler();

    }

    return(

        <Modal 
        isOpen={isOpen} 
        onRequestClose={modalHandler}
        overlayClassName="modal-overlay"
        className="modal-content"
        >

            <Container>

                <FaTimes className="icone modal-close" onClick={modalHandler}/>
                <h2>Tem certeza que deseja excluir este cliente?</h2>

                <button type='button' onClick={handlerDeleteClient}>Sim</button>
                <button type='button' onClick={modalHandler}>Não</button>

            </Container>

        </Modal>

    );

}