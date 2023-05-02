var colors = [
  "#0d6efd",
  "#6610f2",
  "#6f42c1",
  "#d63384",
  "#dc3545",
  "#fd7e14",
  "#ffc107",
  "#198754",
  "#20c997",
  "#0dcaf0",
];
var usedColors = [];

random_color = () => {
  if (usedColors.length === colors.length) {
    usedColors = [];
  }
  let color;
  do {
    color = colors[Math.floor(Math.random() * colors.length)];
  } while (usedColors.includes(color));
  usedColors.push(color);
  return color;
};

async function fetchStats() {
  try {
    const stats_response = await fetch("https://quetzal-api.glitch.me/stats", {
      method: "GET",
    });

    const stats = await stats_response.json();

    // Most Used Items
    const itemNames = stats.mostUsedItems.map((item) => item.name);
    const itemTimesChosen = stats.mostUsedItems.map(
      (item) => item.times_chosen
    );
    const itemColors = stats.mostUsedItems.map(() => random_color(0.8));

    const ctxItems = document
      .getElementById("chartMostUsedItems")
      .getContext("2d");
    const mostUsedItemsChart = new Chart(ctxItems, {
      type: "bar",
      data: {
        labels: itemNames,
        datasets: [
          {
            label: "Veces Elegido",
            data: itemTimesChosen,
            backgroundColor: itemColors,
            borderColor: itemColors.map((color) => color.replace("0.8", "1")),
            borderWidth: 1,
          },
        ],
      },
    });

    // Average Session Stats
    const sessionStatsLabels = [
      "Daño",
      "Salud",
      "Maná",
      "Defensa",
      "Velocidad",
    ];
    const sessionStatsValues = Object.values(stats.averageSessionStats);
    const sessionStatsColors = sessionStatsLabels.map(() => random_color(0.8));

    const ctxSessionStats = document
      .getElementById("chartAvgSessionStats")
      .getContext("2d");
    const avgSessionStatsChart = new Chart(ctxSessionStats, {
      type: "pie",
      data: {
        labels: sessionStatsLabels,
        datasets: [
          {
            label: "Valor Promedio",
            data: sessionStatsValues,
            backgroundColor: sessionStatsColors,
            borderColor: sessionStatsColors.map((color) =>
              color.replace("1", ".8")
            ),
            borderWidth: 1,
          },
        ],
      },
    });

    // Total Game Runs and Finished Sessions
    const ctxTotalSessions = document
      .getElementById("chartTotalSessions")
      .getContext("2d");
    const totalSessionsChart = new Chart(ctxTotalSessions, {
      type: "bar",
      data: {
        labels: ["Partidas Jugadas", "Partidas Terminadas"],
        datasets: [
          {
            label: "Cuenta",
            data: [stats.totalGameRuns, parseInt(stats.totalSessionsFinished)],
            backgroundColor: [random_color(0.8), random_color(0.8)],
            borderColor: [random_color(1.0), random_color(1.0)],
            borderWidth: 1,
          },
        ],
      },
    });
  } catch (error) {
    console.log(error);
  }
}
fetchStats();
