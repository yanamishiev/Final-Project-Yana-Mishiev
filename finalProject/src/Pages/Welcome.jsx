import React from 'react';
import { useUser } from '../Providers/userProvider';
import '../CSS/Welcome.css';

export default function Welcome() {
  const { user } = useUser();

  return (
    <div className="welcome-container">
      <div className="tab">
      <button className="tablinks">דף הבית</button>
        <button className="tablinks">עריכת פרטי משתמש</button>
        <button className="tablinks">לוחות זמנים</button>
        <button className="tablinks">העלאת קבצים</button>
        <button className="tablinks">אבני דרך</button>
        <button className="tablinks">מסמך אפיון</button>
        <button className="tablinks">רשימת משימות</button>
        <button className="tablinks">דף הבית</button>
      </div>
      
      <div className="welcome-content">
        <h1>ברוך הבא {user.firstName}</h1>
        <h2>למערכת פרויקט הגמר שלך</h2>
        <p>
          כאן תוכל לנהל את כל שלבי פרויקט הגמר שלך: 
          עריכת פרטי המשתמש, ניהול לוחות זמנים, העלאת קבצים, מעקב אחרי אבני הדרך,
          מסמך האפיון ורשימת המשימות.
        </p>
      </div>
      

    </div>
  );
}
