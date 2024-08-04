import React, { createContext, useContext, useState } from "react";

const StepContext = createContext();

export const StepProvider = ({ children }) => {
    const [currentStep, setCurrentStep] = useState(0);

    // Funções para controlar os passos
    const nextStep = () => setCurrentStep((prevStep) => prevStep + 1);
    const previousStep = () =>
        setCurrentStep((prevStep) => Math.max(prevStep - 1, 0));

    return (
        <StepContext.Provider
            value={{ currentStep, nextStep, previousStep }}
        >
            {children}
        </StepContext.Provider>
    );
};

export const useStepContext = () => useContext(StepContext);
