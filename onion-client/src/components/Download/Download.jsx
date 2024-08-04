import { planilhaService } from "../../api/services/planilhaService";
import { useStepContext } from "../../context/StepContext";
import "./download.css";

export const Download = () => {
    const { nextStep } = useStepContext();

    const handleDownload = async () => {
        try {
            const response = await planilhaService.downloadPlanilhaModelo();
            const url = window.URL.createObjectURL(new Blob([response]));
            const link = document.createElement("a");
            link.href = url;
            link.setAttribute("download", "planilhaModelo.xlsx");
            document.body.appendChild(link);
            link.click();
        } catch (error) {
            console.error("Erro ao enviar o arquivo:", error);
        }
    };

    return (
        <div className="content-download">
            <div className="lg:w-2/3">
                <h3 className="download-title">
                    Modelo de Planilha
                </h3>
                <p className="download-text">
                    Baixe nosso modelo de planilha para garantir a precisão na
                    importação dos seus pedidos.
                </p>
                <p className="download-text">
                    Certifique-se de preencher os dados corretamente e manter o
                    formato original para uma importação bem-sucedida.
                    <br />
                    Clique abaixo para baixar o modelo ou prossiga se já tiver o
                    arquivo.
                </p>
                <div>
                    <button onClick={handleDownload} className="btn">
                        Baixar modelo
                    </button>
                    <button onClick={() => nextStep()} className="btn ml-6">
                        Já tenho
                    </button>
                </div>
            </div>

            <div className="w-full lg:w-2/4">
                <div>
                    <div>
                        image
                    </div>
                </div>
            </div>
        </div>
    );
};
