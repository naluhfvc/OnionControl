import Dropzone from "../Dropzone/Dropzone";

const Import = () => {
    return (
        <div className="my-24 md:px-14 px-4 mx-auto" id="import">
            <div className="flex flex-col lg:flex-row justify-between items-center gap-10">
                <div className="lg:w-2/4">
                    <h3 className="text-3xl text-pink font-bold mb-3">Faça upload da sua planilha</h3>
                    <p className="text-[16px] text-tartiary">
                        Selecione o botão "Faça upload da planilha" ou arraste e
                        solte seu arquivo com facilidade.
                    </p>
                </div>

                <div className="w-full lg:w-2/4">
                    <div>
                        <div>
                            <Dropzone/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Import;