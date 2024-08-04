import React from "react";
import { Route, Routes } from "react-router-dom";
import HomePage from "./pages/Home/Home";
import DashboardPage from "./pages/Dashboard/Dashboard";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const App = () => {
    return (
        <>
            <ToastContainer
                position="bottom-right"
                theme="colored"
            />
            <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="/Dashboard" element={<DashboardPage />} />
            </Routes>
        </>
    );
};
export default App;
