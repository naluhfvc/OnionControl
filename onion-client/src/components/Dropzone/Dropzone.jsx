import { useCallback, useState } from "react";
import { useDropzone } from "react-dropzone";

const Upload = () => {
    const [files, setFiles] = useState([]);

    const onDrop = useCallback((acceptedFiles) => {
        console.log(acceptedFiles);
    }, []);
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
                className:
                    "p-20 border border-dashed border-tartiary cursor-pointer rounded-lg",
            })}
        >
            <input {...getInputProps()} />
            {isDragActive ? (
                <p className="text-tartiary text-center">Solte sua planilha aqui</p>
            ) : (
                <div className="text-center">
                    <button className="text-pink btn text-sm">
                        Selecionar arquivo
                    </button>
                    <p className="text-tartiary mt-6">
                        Ou arraste e solte a sua planilha aqui
                    </p>
                </div>
            )}
        </div>
    );
};

export default Upload;
