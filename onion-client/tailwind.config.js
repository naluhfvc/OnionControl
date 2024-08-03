/** @type {import('tailwindcss').Config} */
export default {
    content: ["./index.html", "./src/**/*.{html,js,jsx}"],
    theme: {
        colors: {
            pink: "#e12c9e",
            black: "#02020cfb",
            white: "#fff",
            secondary : "#472ce1",
        },
        fontFamily: {
            mono: ["JetBrains Mono", "monospace"],
            poppins: ["Poppins", "sans-serif"],
        },
        extend: {},
    },
    plugins: [],
};
