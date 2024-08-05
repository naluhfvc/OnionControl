import React, { useEffect, useState } from "react";
import Pie from "./Pie";
import { useOrderContext } from "../../../context/OrdersContext";
import { processRegionData } from "../../../utils/dataProcessing";

const RegionChart = () => {
    const { orderData, loading, error } = useOrderContext();
    const [chartData, setChartData] = useState([]);

    useEffect(() => {
        if (!loading && orderData) {
            const data = processRegionData(orderData);
            setChartData(data);
        }
    }, [orderData, loading]);

    if (loading) return <p>Loading...</p>;
    if (error) return <p>Error: {error.message}</p>;

    return (
        <div>
            <h2>Pedidos por Região</h2>
            {loading ? (
                <p>Loading...</p>
            ) : (
                <Pie data={chartData} id={"region-chart"} />
            )}
        </div>
    );
};

export default RegionChart;
