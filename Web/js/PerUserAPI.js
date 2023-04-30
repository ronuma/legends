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

// Get the DOM elements
const userEmailInput = document.getElementById("userEmail");
const userStatsBtn = document.getElementById("userStatsBtn");
const userStatsChartCanvas = document.getElementById("userStatsChart");

userStatsBtn.addEventListener("click", async () => {
  const email = userEmailInput.value;
  if (email) {
    try {
      const response = await fetch(`http://127.0.0.1:8000/stats/runs/${email}`);
      const data = await response.json();

      const averageStatsLabels = Object.keys(data.averageStats);
      const averageStatsValues = Object.values(data.averageStats);
      const averageStatsColors = averageStatsLabels.map(() =>
        random_color(0.8)
      );

      const ctxUserStats = userStatsChartCanvas.getContext("2d");
      const userStatsChart = new Chart(ctxUserStats, {
        type: "pie",
        data: {
          labels: averageStatsLabels,
          datasets: [
            {
              label: "Valor Promedio",
              data: averageStatsValues,
              backgroundColor: averageStatsColors,
              borderColor: averageStatsColors.map((color) =>
                color.replace("0.8", "1")
              ),
              borderWidth: 1,
            },
          ],
        },
        options: {
          scales: {
            y: {
              beginAtZero: true,
            },
          },
        },
      });
    } catch (error) {
      console.error(error);
      alert(
        "Error fetching user stats. Please check the email address and try again."
      );
    }
  } else {
    alert("Please enter an email address.");
  }
});
