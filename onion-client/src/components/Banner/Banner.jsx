import banner from "../../assets/bannerimage.png";
import { motion } from "framer-motion";
import "./banner.css";
import { fadeIn } from "../../variants/variants";

const Banner = () => {
    return (
        <div className="gradient-bg banner">
            <div className="banner-content">
                <motion.div
                    variants={fadeIn("down", 0.2)}
                    initial="hidden"
                    whileInView={"show"}
                    viewport={{ once: false, amount: 0.7 }}
                >
                    <img src={banner} className="banner-image" />
                </motion.div>
                <div className="md:w-3/5">
                    <h2 className="banner-title">
                        Otimize suas operações de Vendas e Logística
                    </h2>
                    <p className="banner-text">
                        Importe sua planilha de pedidos e visualize gráficos de
                        vendas e listas detalhadas em instantes.
                    </p>
                    <p className="banner-text">
                        Transforme seus dados em insights valiosos!
                    </p>
                    <div>
                        <a href="#import">
                            <button className="btn">Vamos lá</button>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Banner;
