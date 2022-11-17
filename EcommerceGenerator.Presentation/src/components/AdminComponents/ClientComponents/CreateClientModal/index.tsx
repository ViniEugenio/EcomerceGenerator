import Modal from 'react-modal';
import { Container, ContainerErrors, Input } from './style';
import { FaTimes } from "react-icons/fa";
import { FormEvent, useState, useContext } from 'react';
import { useClients } from '../../../../hooks/useClients';

interface CreateClientModalProps {
    isOpen: boolean
    modalHandler: () => void
}

export function CreateClientModal({ isOpen, modalHandler } : CreateClientModalProps) {    

    const {CreateClient} = useClients();

    const[name, setName] = useState('');
    const[host, setHost] = useState('');

    const[nameError, setNameError] = useState(false);
    const[nameListError, setNameListError] = useState<string[]>([]);

    const[hostError, setHostError] = useState(false);
    const[hostListError, setHostListError] = useState<string[]>([]);

    function cleanForm() {

        setNameError(false);
        setNameListError([]);

        setHostError(false);
        setHostListError([]);

    }

    async function handleNewClient(event: FormEvent) {

        event.preventDefault();
        cleanForm();

        var errors = await CreateClient({
            name,
            host
        });

        if(errors.length > 0 ) {

            if(errors.some(e => e.includes('nome'))) {

                setNameError(true);
                setNameListError(errors.filter(e => e.includes('nome')));

            }

            if(errors.some(e => e.includes('ambiente'))) {

                setHostError(true);
                setHostListError(errors.filter(e => e.includes('ambiente')));

            }

        }

        else {
           modalHandler();
        }

    }

    return (

       <Modal 
        isOpen={isOpen} 
        onRequestClose={modalHandler}
        overlayClassName="modal-overlay"
        className="modal-content"
        >

            <Container onSubmit={handleNewClient}>

                <FaTimes className="icone modal-close" onClick={modalHandler}/>
                <h2>Novo cliente</h2>

                <Input placeholder='Digite o nome do cliente' 
                    onChange={event => {

                        setName(event.target.value);
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

                <Input placeholder='Digite o host do cliente'
                    onChange={event=> {
                    
                        setHost(event.target.value)
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

                <button type='submit'>Cadastrar</button>

            </Container>

       </Modal>

    );

}