import logo from './logo.svg';
import './App.css';
import Product from './components/Product';
import AddProduct from './components/AddProduct';
import Products from './components/Products';
import RegisterUser from './components/RegisterUser';
import Login from './components/Login';




function App() {
  return (
    //<div className="App">
    //   <div className="container text-center">
    //     <div className = "row">
    //       <div className = "col">
    //         <Products/>
    //       </div>
    //       <div className="col">
    //         <AddProduct/>
    //       </div>
    //     </div>
    //   </div>
    // </div>
    <div className="App">
            <Login/>
    </div>
  );
}

export default App;
