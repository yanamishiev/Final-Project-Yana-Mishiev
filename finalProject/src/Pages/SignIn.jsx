import React, { useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import '../CSS/SignIn.css';
import { IoPersonCircleOutline } from "react-icons/io5";
import { useUser } from '../Providers/userProvider';

export default function SignIn() {
  const [ID, setID] = useState("");
  const [pass, setPass] = useState("");
  const [loading, setLoading] = useState(false);
  const [errorMessage, setErrorMessage] = useState(""); // State for error message
  const navigate = useNavigate();
  const { setUser } = useUser();

  function FuncSignIn() {
    setLoading(true);
    setErrorMessage(""); // Clear any previous error message

    const myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");

    const raw = JSON.stringify({
      ID: ID,
      Passworde: pass,
    });

    const requestOptions = {
      method: "POST",
      headers: myHeaders,
      body: raw,
      redirect: "follow",
    };

    fetch("http://localhost:5000/api/SignInUser/SignInSucsseful", requestOptions)
      .then((response) => {
        if (!response.ok) {
          if (response.status === 401) {
            throw new Error("תעודת זהות או סיסמא אינם נכונים");
          } else {
            throw new Error("אירעה שגיאה, משתמש זה אינו רשום במערכת");
          }
        }
        return response.text();
      })
      .then((result) => {
        setLoading(true);
        localStorage.setItem("ID", result);
        setUser(JSON.parse(result));
        navigate("/Welcome");
      })
      .catch((error) => {
        setErrorMessage(error.message); // Set the error message
      });
  }

  return (
    <div className="App">
      <div className="form-container">
        <div className="icon-wrapper">
          <IoPersonCircleOutline size={75} color="#333" />
        </div>
        <form className="login-form">
          {errorMessage && (
            <p style={{ color: "red", textAlign: "center" }}>{errorMessage}</p>
          )}
          <input
            type="text"
            placeholder="ת.ז"
            className="input-field"
            value={ID}
            onChange={(e) => setID(e.target.value)}
          />
          <input
            type="password"
            placeholder="סיסמא"
            className="input-field"
            value={pass}
            onChange={(e) => setPass(e.target.value)}
          />
          <button
            type="button"
            className="login-btn"
            onClick={FuncSignIn}
          >
            התחברות
          </button>
        </form>
        <p className="register-link">
          פעם ראשונה שלכם כאן? <Link to="/signUp">להרשמה</Link>
        </p>
      </div>
    </div>
  );
}
