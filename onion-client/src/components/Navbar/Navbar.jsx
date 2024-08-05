import React from "react";
import logo from "/public/Onion.png";
import "./navbar.css"; // Importando o arquivo CSS específico para o Navbar
import { Link } from "react-router-dom";

const Navbar = () => {
    return (
        <nav className="navbar">
            <div className="navbar-container">
                <img className="navbar-image" src={logo} alt="Logo" />
                <div className="navbar-title">OnionControl</div>
                <ul className="navbar-links">
                    <li>
                        <Link to={"/"} className="navbar-link">
                            Home
                        </Link>
                    </li>
                    {/* <li>
                        <Link to={"/Dashboard"} className="navbar-link">
                            Dashboard
                        </Link>
                    </li> */}
                </ul>
            </div>
        </nav>
    );
};

export default Navbar;
