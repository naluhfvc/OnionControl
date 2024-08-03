import React from "react";
import Navbar from "../../components/Navbar/Navbar";
import Banner from "../../components/Banner/Banner";

const HomePage = () => {
    return (
        <div>
            <Navbar />
            <div className="md:px-12 p-4 max-w-screen-2xl mx-auto xl:mt-7 mt-16">
                <Banner />
            </div>
        </div>
    );
};

export default HomePage;
