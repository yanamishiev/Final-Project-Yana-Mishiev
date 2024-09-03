import React from 'react';
import '../CSS/Home.css';

export default function Home() {
  return (
    <div className='home-page'>
      <h1>ברוכים הבאים</h1>
      <h1>לפרויקט הגמר שלכם</h1>
      <p> לכניסה לחצו
        <a href='/signIn'> כאן </a>
      </p>
    </div>
  );
}
