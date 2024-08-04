import { useCallback, useState } from "react";
import { useDropzone } from "react-dropzone";
import "./dropzone.css";

const Dropzone = ({ onFileAccepted }) => {
     const [fileName, setFileName] = useState(null);

     const onDrop = useCallback(
         (acceptedFiles) => {
             if (acceptedFiles.length > 0) {
                 setFileName(acceptedFiles[0].name); // Atualiza o nome do arquivo selecionado
                 if (onFileAccepted) {
                     onFileAccepted(acceptedFiles[0]); // Passa o primeiro arquivo aceito para a função de callback
                 }
             }
         },
         [onFileAccepted]
     );

    const { getRootProps, getInputProps, isDragActive } = useDropzone({
        onDrop,
        accept: {
            "application/vnd.ms-excel": [".xls", ".xlsx"],
        },
        maxFiles: 1,
    });

    return (
        <div
            {...getRootProps({
                className: "drop-root",
            })}
        >
            <input {...getInputProps()} />
            {isDragActive ? (
                <p className="text-tartiary text-center">
                    Solte sua planilha aqui
                </p>
            ) : (
                <div className="text-center">
                    {fileName ? (
                        <>
                            <p className="text-primary text-center">
                                <strong>Arquivo selecionado:</strong>
                            </p>
                            <p className="text-secondary text-center">
                                {fileName}
                            </p>
                        </>
                    ) : (
                        <>
                            <button className="btn text-pink text-sm">
                                Selecionar arquivo
                            </button>
                            <p className="text-tartiary mt-6">
                                Ou arraste e solte a sua planilha aqui
                            </p>
                        </>
                    )}
                </div>
            )}
        </div>
    );
};

export default Dropzone;
