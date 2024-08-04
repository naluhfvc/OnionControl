/** @type {import('tailwindcss').Config} */
export default {
    content: ["./index.html", "./src/**/*.{html,js,jsx}"],
    theme: {
        colors: {
            pink: "#e12c9e",
            purple : "#472ce1",
            black: "#02020cfb",
            white: "#fff",
            tartiary: "#707070",
        },
        fontFamily: {
            mono: ["JetBrains Mono", "monospace"],
            poppins: ["Poppins", "sans-serif"],
        },
        extend: {},
    },
    plugins: [],
};
