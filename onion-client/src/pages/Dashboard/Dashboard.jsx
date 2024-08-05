import React from "react";
import Navbar from "../../components/Navbar/Navbar";
import ProductChart from "../../components/Dashboard/Charts/ProductChart";
import RegionChart from "../../components/Dashboard/Charts/RegionChart";
import { OrderProvider } from "../../context/OrdersContext";

const DashboardPage = () => {
    return (
        <div>
            <Navbar />
            <div className="content">
                <OrderProvider>
                    <ProductChart/>
                    <RegionChart/>
                </OrderProvider>
            </div>
        </div>
    );
};

export default DashboardPage;
