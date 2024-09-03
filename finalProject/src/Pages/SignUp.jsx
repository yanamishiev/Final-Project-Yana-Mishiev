import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import '../CSS/SignUp.css'; // Your custom CSS styles
import { IoPersonCircleOutline } from "react-icons/io5";

export default function SignUp() {
    const [ID, setID] = useState("");
    const [pass, setPass] = useState("");
    const [conPass, setConPass] = useState("");
    const [FirstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [email, setEmail] = useState("");
    const [Department, setDepartment] = useState("");
    const [projectGroup, setProjectGroup] = useState("");

    const [IDError, setIDError] = useState("");
    const [passwordError, setPasswordError] = useState("");
    const [conPassError, setConPassError] = useState("");
    const [FirstnameError, setFirstNameError] = useState("");
    const [lastNameError, setLastNameError] = useState("");
    const [emailError, setEmailError] = useState("");  

    const navigate = useNavigate();

    function validateID() {
        const regex = /^[0-9]{9}$/;
        if (!regex.test(ID)) {
            setIDError("התעודת זהות צריכה להכיל 9 מספרים בלבד");
            return false;
        }
        setIDError("");
        return true;
    }

    function validatePassword() {
        const regex = /^(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{7,12}$/;
        if (!regex.test(pass)) {
            setPasswordError("הסיסמא צריכה להכיל בין 7-12 תווים, מספרים ואותיות באנגלית, אות אחת גדולה, אות אחת קטנה ותווים מיוחדים");
            return false;
        }
        setPasswordError("");
        return true;
    }

    function validateConfirmPassword() {
        if (conPass !== pass) {
            setConPassError("סיסמאות לא תואמות");
            return false;
        }
        setConPassError("");
        return true;
    }

    function validateFirstName() {
        const regex = /^[a-zA-Zא-ת]+$/;
        if (!regex.test(FirstName)) {
            setFirstNameError("השם יכול להכיל בעברית ואנגלית בלבד");
            return false;
        }
        setFirstNameError("");
        return true;
    }

    function validateLastName() {
        const regex = /^[a-zA-Zא-ת]+$/;
        if (!regex.test(lastName)) {
            setLastNameError("השם יכול להכיל בעברית ובאנגלית בלבד");
            return false;
        }
        setLastNameError("");
        return true;
    }

    function validateEmail() {
        const regex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
        if (!regex.test(email)) {
            setEmailError("פורמט האימייל אינו תקין");
            return false;
        }
        setEmailError("");
        return true;
    }

    function registerUser() {
        if (
            validateID() &&
            validatePassword() &&
            validateConfirmPassword() &&
            validateFirstName() &&
            validateLastName() &&
            validateEmail()
        ) {
            const raw = JSON.stringify({
                "id": ID,
                "email": email,
                "passworde": pass,  // fixed typo here
                "confirmPassword": conPass,
                "firstName": FirstName,
                "lastName": lastName,
                "depNum": Department,
                "ProjNum": projectGroup
            });

            let options = {
                method: 'POST',
                body: raw,
                headers: {
                    'Content-Type': 'application/json; charset=UTF-8'
                },
            };

            fetch("http://localhost:5000/api/User/SignUp", options)
                .then((response) => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    return response.text();
                })
                .then((result) => {
                    console.log(result);
                    if (result === 'done:)') {
                        navigate('/SignIn');
                    }
                })
                .catch((error) => {
                    console.error('There was a problem with the registration:', error);
                });
        }
    }

    return (
        <div className='sign-up-container'>
            <div className="icon-wrapper">
                <IoPersonCircleOutline size={75} color="#333" />
            </div>
            <div className='form-container'>
                <div className="input-row">
                    <label>תעודת זהות</label>
                    <input
                        type="text"
                        value={ID}
                        onChange={(e) => setID(e.target.value)}
                        className={`form-input ${IDError ? 'input-error' : ''}`}
                    />
                    <span className='error-message'>{IDError}</span>
                    
                    <label>סיסמא</label>
                    <input
                        type="password"
                        value={pass}
                        onChange={(e) => setPass(e.target.value)}
                        className={`form-input ${passwordError ? 'input-error' : ''}`}
                    />
                    <span className='error-message'>{passwordError}</span>
                </div>

                <div className="input-row">
                    <label>אישור סיסמא</label>
                    <input
                        type="password"
                        value={conPass}
                        onChange={(e) => setConPass(e.target.value)}
                        className={`form-input ${conPassError ? 'input-error' : ''}`}
                    />
                    <span className='error-message'>{conPassError}</span>
                    
                    <label>שם פרטי</label>
                    <input
                        type="text"
                        value={FirstName}
                        onChange={(e) => setFirstName(e.target.value)}
                        className={`form-input ${FirstnameError ? 'input-error' : ''}`}
                    />
                    <span className='error-message'>{FirstnameError}</span>
                </div>

                <div className="input-row">
                    <label>שם משפחה</label>
                    <input
                        type="text"
                        value={lastName}
                        onChange={(e) => setLastName(e.target.value)}
                        className={`form-input ${lastNameError ? 'input-error' : ''}`}
                    />
                    <span className='error-message'>{lastNameError}</span>
                    
                    <label>אימייל</label>
                    <input
                        type="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        className={`form-input ${emailError ? 'input-error' : ''}`}
                    />
                    <span className='error-message'>{emailError}</span>
                </div>

                <div className="input-row">
                    <label>מחלקה</label>
                    <input
                        type="text"
                        value={Department}
                        onChange={(e) => setDepartment(e.target.value)}
                        className="form-input"
                    />
                    <label>קבוצה</label>
                    <input
                        type="text"
                        value={projectGroup}
                        onChange={(e) => setProjectGroup(e.target.value)}
                        className="form-input"
                    />
                </div>

                <button
                    className='submit-button'
                    onClick={registerUser}
                >
                    הרשמה
                </button>
            </div>
            <p>רשומים? לכניסה לחצו
                <a href='/signIn'> כאן </a>
            </p>
        </div>
    );
}
