import axios from "axios";

// Cria uma instância do Axios com configurações padrão
const apiClient = axios.create({
    baseURL: "http://localhost:2001/api",
});

apiClient.interceptors.response.use(
    (response) => response,
    (error) => {
        // Lida com erros
        if (error.response) {
            console.error("Erro na resposta:", error.response);
        } else if (error.request) {
            console.error("Erro na solicitação:", error.request);
        } else {
            console.error("Erro desconhecido:", error.message);
        }
        return Promise.reject(error);
    }
);

export default apiClient;