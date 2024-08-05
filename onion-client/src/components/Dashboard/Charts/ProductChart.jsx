import React, { useEffect, useState } from "react";
import { useOrderContext } from "../../../context/OrdersContext";
import { processProductData } from "../../../utils/dataProcessing";
import Pie from "./Pie";

const ProductChart = () => {
    const { orderData, loading, error } = useOrderContext();
    const [chartData, setChartData] = useState([]);

    // Efeito que depende dos dados de pedidos
    useEffect(() => {
        const processChartData = async () => {
            const data = await processProductData(orderData);
            setChartData(data);
        };
        if (!loading && orderData) {
            processChartData();
        }
    }, [orderData, loading]);

    if (error) return <p>Error: {error.message}</p>;

    return (
        <div className="mb-3">
            {!loading && orderData && (
                <>
                    <h2 className="text-xl text-tartiary">
                        Pedidos por Produto
                    </h2>
                    <Pie data={chartData} id={"product-chart"} />
                </>
            )}
        </div>
    );
};

export default ProductChart;
