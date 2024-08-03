import React from "react";
import Navbar from "../../components/Navbar/Navbar";
import Banner from "../../components/Banner/Banner";
import Import from "../../components/Import/Import";

const HomePage = () => {
    return (
        <>
            <Navbar />
            <div className="md:px-12 p-4 mx-auto xl:mt-20 mt-10">
                <Banner />
                <Import />
            </div>
        </>
    );
};

export default HomePage;
