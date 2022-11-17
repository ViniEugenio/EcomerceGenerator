import { useState } from "react";
import { ContentPage } from "./components/ContentPage";
import { Header } from "./components/Header";
import { GlobalStyle } from "./styles/global";
import Modal from 'react-modal';
import { ClientsProvider } from "./hooks/useClients";

export function App() {

  return (

    <>
    

      <GlobalStyle/>    
      <Header/>    
      <ContentPage/>


     
    </>

  );

}
