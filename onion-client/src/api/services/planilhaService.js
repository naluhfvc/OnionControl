import apiClient from "../apiClient"

export const downloadPlanilhaModelo = async () => {
    try {
        const response = await apiClient.get("/planilha/downloadModelo", {
            responseType: "blob",
        }); 
        return response.data;
    } catch (error) {
        console.error("Erro ao enviar o arquivo:", error);
        throw error;
    }
}


export const planilhaService = {
    downloadPlanilhaModelo
}