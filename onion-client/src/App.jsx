import React from "react";
import { Route, Routes } from "react-router-dom";
import HomePage from "./pages/Home/Home";
import DashboardPage from "./pages/Dashboard/Dashboard";

const App = () => {
    return (
        <Routes>
            <Route path="/" element={<HomePage />} />
            <Route path="/Dashboard" element={<DashboardPage />} />
        </Routes>
    );
};
export default App;
