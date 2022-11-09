import { useState } from "react";
import { ContentPage } from "./components/ContentPage";
import { Header } from "./components/Header";
import { GlobalStyle } from "./styles/global";
import Modal from 'react-modal';
import { ClientsProvider } from "./components/AdminComponents/ClientComponents/ClientsContext";

export function App() {

  return (

    <>
    

      <GlobalStyle/>    
      <Header/>    
      <ContentPage/>


     
    </>

  );

}
