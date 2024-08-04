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

export const uploadPlanilha = async (file) => {
    if(!file) throw new Error("Nenhum arquivo selecionado");

    const formData = new FormData();
    formData.append("file", file);

    try {
        const response = await apiClient.post("/planilha/upload", formData, {
            headers: {
                "Content-Type": "multipart/form-data",
            },
        });
        return response;
    } catch (error) {
        console.error("Erro ao enviar o arquivo:", error);
        throw error;
    }
}

export const planilhaService = {
    downloadPlanilhaModelo,
    uploadPlanilha
}