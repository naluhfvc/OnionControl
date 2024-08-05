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

    if (error) return <p>Error: {error.message}</p>;

    return (
        <div>
            {!loading && orderData && (
                <>
                    <h2 className="text-xl text-tartiary">
                        Pedidos por Região
                    </h2>

                    <Pie data={chartData} id={"region-chart"} />
                </>
            )}
        </div>
    );
};

export default RegionChart;
