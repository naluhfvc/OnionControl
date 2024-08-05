import React, { useEffect } from "react";
import * as am5 from "@amcharts/amcharts5";
import * as am5percent from "@amcharts/amcharts5/percent";
import am5themes_Animated from "@amcharts/amcharts5/themes/Animated";

const PieChart3D = ({ data, id }) => {
    useEffect(() => {
        // Cria uma nova instância do gráfico
        let root = am5.Root.new(id);

        // Aplica o tema Animated
        root.setThemes([am5themes_Animated.new(root)]);

        // Cria o gráfico de pizza
        let chart = root.container.children.push(
            am5percent.PieChart.new(root, {
                layout: root.verticalLayout,
                innerRadius: am5.percent(40),
            })
        );

        // Adiciona uma série de pizza
        let series = chart.series.push(
            am5percent.PieSeries.new(root, {
                valueField: "value",
                categoryField: "category",
                alignLabels: false,
            })
        );

        // Configura os slices da série
        series.slices.template.setAll({
            draggable: true,
            cornerRadius: 5,
        });

        // Define os dados para a série
        series.data.setAll(data);

        // Limpeza ao desmontar o componente
        return () => {
            root.dispose();
        };
    }, [data]);

    return <div id={id} style={{ width: "100%", height: "500px" }}></div>;
};

export default PieChart3D;
