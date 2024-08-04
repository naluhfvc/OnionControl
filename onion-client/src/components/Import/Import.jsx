import { useStepContext } from "../../context/StepContext";
import { Download } from "../Download/Download";
import { Upload } from "../Upload/Upload";
import "./import.css";

const Import = () => {
    const {currentStep} = useStepContext();

    return (
        <div className="content-import" id="import">
            {currentStep === 0 ? <Download /> : <Upload />}
        </div>
    );
};

export default Import;
