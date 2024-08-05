export const processRegionData = (data) => {
    // Conta a quantidade de regiões
    const regionCounts = data.reduce((acc, order) => {
        const region = order.regiao;
        acc[region] = (acc[region] || 0) + 1;
        return acc;
    }, {});

    // Converte o resultado para o formato esperado pelo amCharts
    const formattedData = Object.entries(regionCounts).map(
        ([category, value]) => ({
            category,
            value,
        })
    );

    console.log("region", formattedData);

    return formattedData;
};

export const processProductData = (data) => {
    const productCounts = data.reduce((acc, order) => {
        const product = order.nomeProduto;
        acc[product] = (acc[product] || 0) + 1;
        return acc;
    }, {});

    const formattedData = Object.entries(productCounts).map(
        ([category, value]) => ({
            category,
            value,
        })
    );

    console.log("product", formattedData);

    return formattedData;
};

// Função para formatar valores como moeda brasileira
export const formatCurrency = (value) => {
    return `R$ ${parseFloat(value).toFixed(2).replace('.', ',')}`;
};