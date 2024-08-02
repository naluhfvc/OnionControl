import React from "react";
import logo from "/public/Onion.png";
import "./navbar.css"; // Importando o arquivo CSS específico para o Navbar

const Navbar = () => {
    return (
        <nav className="navbar">
            <div className="navbar-container">
                <img className="navbar-image" src={logo} alt="" />
                <div className="navbar-title">OnionControl</div>
                <ul className="navbar-links">
                    <li>
                        <a href="#home" className="navbar-link">
                            Início
                        </a>
                    </li>
                    <li>
                        <a href="#about" className="navbar-link">
                            About
                        </a>
                    </li>
                </ul>
            </div>
        </nav>
    );
};

export default Navbar;
