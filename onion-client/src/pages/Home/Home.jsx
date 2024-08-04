import React from "react";
import Navbar from "../../components/Navbar/Navbar";
import Banner from "../../components/Banner/Banner";
import Import from "../../components/Import/Import";
import "../Home/home.css";
import { StepProvider } from "../../context/StepContext";

const HomePage = () => {
    return (
        <>
            <Navbar />
            <div className="content">
                <Banner />
                <StepProvider>
                    <Import />
                </StepProvider>
            </div>
        </>
    );
};

export default HomePage;
