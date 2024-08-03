import banner from "../../assets/bannerimage.png";
import { motion } from "framer-motion";
import { fadeIn } from "../../variants";

const Banner = () => {
    return (
        <div className="gradientBg rounded-xl rounded-br-[80px] md:p-9 px-4 py-9">
            <div className="flex flex-col md:flex-row-reverse justify-between items-center gap-10">
                <motion.div
                    variants={fadeIn("down", 0.2)}
                    initial="hidden"
                    whileInView={"show"}
                    viewport={{ once: false, amount: 0.7 }}
                >
                    <img src={banner} className="lg:h-[386px]" />
                </motion.div>
                <div className="md:w-3/5">
                    <h2 className="md:text-4xl text-4xl font-bold text-white mb-6 leaning-relaxed">
                        Otimize suas operações de Vendas e Logística
                    </h2>
                    <p className="text-white text-xl mb-8">
                        Importe sua planilha de pedidos e visualize gráficos de
                        vendas e listas detalhadas em instantes.
                    </p>
                    <p className="text-white text-xl mb-8">
                        Transforme seus dados em insights valiosos!
                    </p>
                    <div>
                        <button className="btn">Começar</button>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Banner;
