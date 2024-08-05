import { toast } from "react-toastify";
import { formatCurrency } from "../../../utils/dataProcessing";
import LoadingModal from "../../Loading";
import './tableVendas.css';
import { useOrderContext } from "../../../context/OrdersContext";
import { useNavigate } from "react-router-dom";

const TableVendas = () => {
    const { orderData, loading, error } = useOrderContext();
    const navigate = useNavigate();
    if (loading) return <LoadingModal isOpen={loading}/>;

    if (error){
        navigate('/') ;
        return toast.error("Erro ao buscar as vendas. Tente novamente.");
    } 

    return (
        <div className="overflow-x-auto">
            <table className="min-w-full divide-y divide-gray-200">
                <thead className="bg-purple text-white">
                    <tr>
                        <th className="text-header">
                            Cliente
                        </th>
                        <th className="text-header">
                            Produto
                        </th>
                        <th className="text-header">
                            Valor Final
                        </th>
                        <th className="text-header">
                            Data de Entrega
                        </th>
                        <th className="text-header">Região</th>
                    </tr>
                </thead>
                <tbody className="bg-[#be91bbbe] divide-y divide-gray-200">
                    {orderData?.map((item, index) => (
                        <tr key={index}>
                            <td className="px-6 py-4 whitespace-nowrap text-sm  text-black">
                                {item.nomeCliente}
                            </td>
                            <td className="px-6 py-4 whitespace-nowrap text-sm text-black">
                                {item.nomeProduto}
                            </td>
                            <td className="px-6 py-4 whitespace-nowrap text-sm text-black">
                                {formatCurrency(item.valorFinal)}
                            </td>
                            <td className="px-6 py-4 whitespace-nowrap text-sm text-black">
                                {item.dataDeEntrega}
                            </td>
                            <td className="px-6 py-4 whitespace-nowrap text-sm text-black">
                                {item.regiao}
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default TableVendas;
