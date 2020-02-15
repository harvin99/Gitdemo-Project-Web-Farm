import React,{useState,useEffect} from 'react';
import './Login.css';
import logo from './useicon.png';
import Axios from 'axios';
import { identifier } from '@babel/types';

function Login() {
   const [acount,setAcount] = useState({
     username: "",
     passowrd:""
   })
     
   function handleChange(e){
     setAcount({[e.target.name]: e.target.value})
   }
   async function handleSubmit(e){
     e.preventDefault();
     let res = await Axios.post("localhost:8080/api/account/login",acount)
     console.log(res.data);
    
     
   }
  return (
    <div className = "login">
        <img className = "iconuser" src={logo}></img>
        <h2>Login</h2>
        <form onSubmit = {handleSubmit}>
            <div className = "inputlogin">
                <input name = "username" value ={acount.username} onChange={handleChange} required = "valid"></input>
                <label>Usename</label>
            </div>
            <div className = "inputlogin">
                <input name="password" value ={acount.passowrd} onChange={handleChange} required = "valid"></input>
                <label>Password</label>
            </div>
            <button type = "submit">Submit</button>
            <a href = "#">Forget Password</a>
        </form>
    </div>
  );
}

export default Login;