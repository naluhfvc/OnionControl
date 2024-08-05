import { useState } from "react";
import { useStepContext } from "../../context/StepContext";
import Dropzone from "../Dropzone/Dropzone";
import "./upload.css";
import { toast } from "react-toastify";
import { planilhaService } from "../../api/services/planilhaService";
import { useNavigate } from "react-router-dom";

export const Upload = () => {
    const { previousStep } = useStepContext();
    const [file, setFile] = useState(null);
    const [isFileSelected, setIsFileSelected] = useState(false);
    const navigate = useNavigate();

    const handleFileAccepted = (acceptedFile) => {
        setFile(acceptedFile);
        setIsFileSelected(true);
    };

    const handleUpload = async () => {
        try {
            const response = await planilhaService.uploadPlanilha(file);
            if (response.status === 200){
                toast.success("Sucesso ao enviar");
                navigate("/Dashboard");
            } 
        } catch (error) {
            toast.error("Erro ao enviar o arquivo");
        }
    };

    return (
        <div className="content-upload">
            <div className="lg:w-2/4">
                <h3 className="title-upload">Faça upload da sua planilha</h3>
                <p className="text-[18px] text-tartiary mb-5">
                    Selecione o botão "Faça upload da planilha" ou arraste e
                    solte seu arquivo com facilidade.
                </p>
                <div>
                    <button
                        onClick={() => previousStep()}
                        className="btn text-sm mr-10"
                    >
                        Voltar para modelo
                    </button>
                    {isFileSelected && (
                        <button onClick={handleUpload} className="btn text-sm">
                            Fazer upload
                        </button>
                    )}
                </div>
            </div>

            <div className="w-full lg:w-2/4">
                <div>
                    <div>
                        <Dropzone onFileAccepted={handleFileAccepted} />
                    </div>
                </div>
            </div>
        </div>
    );
};
