import { Routes, Route } from 'react-router-dom'
import { ListClient } from './components/AdminComponents/ClientComponents/ListClient';
import { CreateProduct } from './components/AdminComponents/ProductComponents/CreateProduct';
import { ListProduct } from './components/ProductComponents/ListProduct';
import { AdminLayout } from './layouts/AdminLayout';
import { ClientLayout } from './layouts/ClientLayout';

export function Router() {

    return (

        <Routes>

            <Route path='/' element={<ListProduct/>}/>

            <Route path='admin' element={<AdminLayout/>}>
                
               <Route path='clients' element={<ClientLayout/>}>
                    <Route path='' element={<ListClient/>}></Route>
               </Route>

               <Route path='product/create' element={<CreateProduct/>}/>

            </Route>

        </Routes>

    );

}