import { Cabecalho, Container, ContainerOpcoes, Dado, Dados, Tabela, THead } from "./style";
import { FaRedoAlt, FaPlus, FaTrash, FaEdit } from "react-icons/fa";
import { useContext, useState } from "react";
import { ActiveLabel, DisabledLabel } from "../../../../styles/commonStyles";
import { CreateClientModal } from "../CreateClientModal";
import { ClientsContext } from "../ClientsContext";
import { DeleteClientModal } from "../DeleteClientModal";
import { cliente } from "../../../../models/cliente";
import { UpdateClientModal } from "../UpdateClientModal";

export function ListClient() {

    const {clients} = useContext(ClientsContext);
    
    const[modalOpenCreateClient, handlerModalCreateClient] = useState(false);

    function openModalCreateClient() {
        handlerModalCreateClient(true);
    }

    function closeModalCreateClient() {
        handlerModalCreateClient(false);
    }

    const[modalOpenDeleteClient, handlerModalDeleteClient] = useState(false);
    const[actualClientId, setActualClientId] = useState('');

    function openModalDeleteClient() {
        handlerModalDeleteClient(true);
    }

    function closeModalDeleteClient() {
        handlerModalDeleteClient(false);
    }

    const[modalOpenUpdateClient, handlerModalUpdateClient] = useState(false);
    const[actualClient, setActualClient] = useState<cliente>({} as cliente);

    function openModalUpdateClient() {
        handlerModalUpdateClient(true);
    }

    function closeModalUpdateClient() {
        handlerModalUpdateClient(false);
    }



    return (

            <Container>
            
                <ContainerOpcoes>
                    <FaPlus className="icone" onClick={openModalCreateClient}/>
                    <FaRedoAlt className="icone"/>           
                </ContainerOpcoes>

                <Tabela>

                    <Cabecalho>
                        <THead>Nome do cliente</THead>
                        <THead>Host</THead>
                        <THead>Data de Cadastro</THead>
                        <THead>Status</THead>
                        <THead>Banco de dados</THead>
                        <THead>Ações</THead>
                    </Cabecalho>

                   {clients.map( cliente => (

                        <Dados key={cliente.id}>

                            <Dado>{cliente.name}</Dado>
                            <Dado>{cliente.host}</Dado>
                            <Dado>{new Intl.DateTimeFormat('pt-BR').format(new Date(cliente.createdDate))}</Dado>
                            <Dado>
                                {cliente.active ? <ActiveLabel>Ativo</ActiveLabel> : <DisabledLabel>Desativado</DisabledLabel>}
                            </Dado>
                            <Dado>
                                {cliente.updatedDatabase ? <ActiveLabel>Atualizado</ActiveLabel> : <DisabledLabel>Desatualizado</DisabledLabel>}
                            </Dado>
                            <Dado>

                                <FaTrash onClick={() => {

                                    setActualClientId(cliente.id);
                                    openModalDeleteClient();
                                    
                                }} className="icone" title="Exluir" />

                                <FaEdit onClick={() => {

                                    setActualClient(cliente);
                                    openModalUpdateClient();

                                }} className="icone" title="Editar"/>

                                <FaRedoAlt className="icone" title="Atualizar"/>     

                            </Dado>

                        </Dados>       

                    ))}                      

                </Tabela>

                <CreateClientModal isOpen={modalOpenCreateClient} modalHandler={closeModalCreateClient}/>                
                <DeleteClientModal isOpen={modalOpenDeleteClient} modalHandler={closeModalDeleteClient} clientId={actualClientId}/>
                <UpdateClientModal isOpen={modalOpenUpdateClient} modalHandler={closeModalUpdateClient} ActualClient={actualClient}/>

            </Container>

    );

}