import { useState } from "react";
import { planilhaService } from "../../api/services/planilhaService";
import { useStepContext } from "../../context/StepContext";
import "./download.css";

export const Download = () => {
    const { nextStep } = useStepContext();
    const [isDownloading, setIsDownloading] = useState(false);

    const handleDownload = async () => {
        setIsDownloading(true);
        try {
            const response = await planilhaService.downloadPlanilhaModelo();
            const url = window.URL.createObjectURL(new Blob([response]));
            const link = document.createElement("a");
            link.href = url;
            link.setAttribute("download", "planilhaModelo.xlsx");
            document.body.appendChild(link);
            link.click();
            link.remove();
            setTimeout(() => {
                setIsDownloading(false);
                nextStep();
            }, 1000);
        } catch (error) {
            console.error("Erro ao enviar o arquivo:", error);
            setIsDownloading(false);
        } finally {
        }
    };

    return (
        <div className="content-download">
            <div className="lg:w-2/3">
                <h3 className="download-title">Modelo de Planilha</h3>
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
                    <button
                        onClick={handleDownload}
                        disabled={isDownloading}
                        className="btn"
                    >
                        {isDownloading ? "Baixando..." : "Baixar modelo"}
                    </button>
                    <button
                        onClick={() => nextStep()}
                        disabled={isDownloading}
                        className="btn ml-6"
                    >
                        Já tenho
                    </button>
                </div>
            </div>

            <div className="w-full lg:w-2/4">
                <div>
                    <div>image</div>
                </div>
            </div>
        </div>
    );
};
