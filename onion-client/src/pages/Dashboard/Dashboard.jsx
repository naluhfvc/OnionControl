import React, { useState } from "react";
import Navbar from "../../components/Navbar/Navbar";
import ProductChart from "../../components/Dashboard/Charts/ProductChart";
import RegionChart from "../../components/Dashboard/Charts/RegionChart";
import { OrderProvider } from "../../context/OrdersContext";
import "./dashboard.css";
import LoadingModal from "../../components/Loading";
import TableVendas from "../../components/Dashboard/Tables/TableVendas";

const DashboardPage = () => {
    return (
        <OrderProvider>
            <div>
                <Navbar />
                <div className="content mb-10">
                    <div className="content-dashboard">
                        <div className="lg:w-3/5 mr-6">
                            <h3 className="download-title">
                                Confira as informações das suas vendas
                            </h3>
                            <TableVendas/>
                        </div>

                        <div className="w-full lg:w-3/6">
                            <div>
                                <ProductChart />
                                <RegionChart />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </OrderProvider>
    );
};

export default DashboardPage;
