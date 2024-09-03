import { useState, useEffect } from 'react'
import './App.css'
import {Router, Route,  Routes} from 'react-router-dom'
import SignIn from './Pages/SignIn'
import SignUp from './Pages/SignUp'
import Home from './Pages/Home'
import Welcome from './Pages/Welcome'
import { UserProvider } from './Providers/userProvider';


function App() {
  const [count, setCount] = useState(0)

 
  return (
    <>
     <UserProvider>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/signUp" element={<SignUp />} />
        <Route path="/signIn" element={<SignIn />} />
        <Route path="/welcome" element={<Welcome />} />
      </Routes>
    </UserProvider>
    </>
  )
}

export default App
