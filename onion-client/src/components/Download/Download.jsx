import { useStepContext } from "../../context/StepContext";

export const Download = () => {
    const { nextStep } = useStepContext();

    const downloadTemplate = () => {
        // Logic to download the template file
        const link = document.createElement("a");
        link.href = "url_to_your_template_file";
        link.download = "modelo_planilha.xlsx";
        link.click();
    };

    return (
        <div className="flex flex-col lg:flex-row justify-between items-center gap-10">
            <div className="lg:w-2/3">
                <h3 className="text-3xl text-pink font-bold mb-3">
                    Modelo de Planilha
                </h3>
                <p className="text-[18px] text-tartiary mb-5">
                    Baixe nosso modelo de planilha para garantir a precisão na
                    importação dos seus pedidos.
                </p>
                <p className="text-[18px] text-tartiary mb-5">
                    Certifique-se de preencher os dados corretamente e manter o
                    formato original para uma importação bem-sucedida.
                    <br />
                    Clique abaixo para baixar o modelo ou prossiga se já tiver o
                    arquivo.
                </p>
                <div>
                    <button onClick={downloadTemplate} className="btn">
                        Baixar modelo
                    </button>
                    <button onClick={() => nextStep()} className="btn ml-6">
                        Já tenho
                    </button>
                </div>
            </div>
        </div>
    );
};
