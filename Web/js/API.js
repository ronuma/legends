function random_color(alpha = 1.0) {
  const r_c = () => Math.round(Math.random() * 255);
  return `rgba(${r_c()}, ${r_c()}, ${r_c()}, ${alpha}`;
}

async function fetchStats() {
  try {
    const stats_response = await fetch("https://quetzal-api.glitch.me/stats", {
      method: "GET",
    });

    const stats = await stats_response.json();
    console.log("Stats: ");
    console.log(stats);

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
            label: "Times Chosen",
            data: itemTimesChosen,
            backgroundColor: itemColors,
            borderColor: itemColors.map((color) => color.replace("0.8", "1")),
            borderWidth: 1,
          },
        ],
      },
    });

    // Average Session Stats
    const sessionStatsLabels = Object.keys(stats.averageSessionStats);
    const sessionStatsValues = Object.values(stats.averageSessionStats);
    const sessionStatsColors = sessionStatsLabels.map(() => random_color(0.8));

    const ctxSessionStats = document
      .getElementById("chartAvgSessionStats")
      .getContext("2d");
    const avgSessionStatsChart = new Chart(ctxSessionStats, {
      type: "bar",
      data: {
        labels: sessionStatsLabels,
        datasets: [
          {
            label: "Average Value",
            data: sessionStatsValues,
            backgroundColor: sessionStatsColors,
            borderColor: sessionStatsColors.map((color) =>
              color.replace("0.8", "1")
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
        labels: ["Total Game Runs", "Total Sessions Finished"],
        datasets: [
          {
            label: "Count",
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
