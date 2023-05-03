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
]
var usedColors = []

random_color = () => {
   if (usedColors.length === colors.length) {
      usedColors = []
   }
   let color
   do {
      color = colors[Math.floor(Math.random() * colors.length)]
   } while (usedColors.includes(color))
   usedColors.push(color)
   return color
}

// Get the DOM elements
const userEmailInput = document.getElementById("userEmail")
const userStatsBtn = document.getElementById("userStatsBtn")
const userStatsChartCanvas = document.getElementById("userStatsChart")
const userTotalSessions = document.getElementById("userTotalSessions")
const userHeroStats = document.getElementById("userHeroStats")
const heroStatsChartCanvas = document.getElementById("heroStatsChart")
const containers = document.querySelectorAll(".container")
const userCarousel = document.getElementById("userCarousel")
const inputFieldAndButton = document.getElementById("inputFieldAndButton")
const errorDisp = document.getElementById("errorDisp")

userStatsBtn.addEventListener("click", async () => {
   const email = userEmailInput.value

   if (email) {
      try {
         const response = await fetch(
            `https://quetzal-api.glitch.me/stats/runs/${email}`
         )

         if (!response.ok) {
            throw new Error(
               `Error fetching user stats. HTTP status: ${response.status}`
            )
         }

         const data = await response.json()

         const averageStatsLabels = [
            "Daño",
            "Salud",
            "Maná",
            "Defensa",
            "Velocidad",
         ]
         const averageStatsValues = Object.values(data.averageStats)
         const averageStatsColors = averageStatsLabels.map(() =>
            random_color(0.8)
         )

         // Display total runs and finished runs
         userTotalSessions.textContent = `Total de Partidas: ${data.runs}, Finalizadas: ${data.finished_runs}`

         // Process hero stats data
         const heroStatsLabels = Object.keys(data.heroStats)
         const heroStatsFinishedRuns = heroStatsLabels.map(
            hero => data.heroStats[hero].finished_runs
         )
         const heroStatsStartedRuns = heroStatsLabels.map(
            hero => data.heroStats[hero].runs
         )
         const heroStatsColors = heroStatsLabels.map(() => random_color())

         const ctxUserStats = userStatsChartCanvas.getContext("2d")
         const userStatsChart = new Chart(ctxUserStats, {
            type: "pie",
            data: {
               labels: averageStatsLabels,
               datasets: [
                  {
                     label: "Valor Promedio",
                     data: averageStatsValues,
                     backgroundColor: averageStatsColors,
                     borderColor: averageStatsColors.map(color =>
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
         })

         const ctxHeroStats = heroStatsChartCanvas.getContext("2d")
         const heroStatsChart = new Chart(ctxHeroStats, {
            type: "bar",
            data: {
               labels: heroStatsLabels,
               datasets: [
                  {
                     label: "Partidas Completadas",
                     data: heroStatsFinishedRuns,
                     backgroundColor: heroStatsColors,
                     borderColor: heroStatsColors.map(color =>
                        color.replace("0.8", "1")
                     ),
                     borderWidth: 1,
                  },
                  {
                     label: "Partidas Iniciadas",
                     data: heroStatsStartedRuns,
                     backgroundColor: heroStatsColors.map(color =>
                        color.replace("1", "0.5")
                     ),
                     borderColor: heroStatsColors.map(color =>
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
         })
         containers.forEach(container => container.classList.remove("hidden"))
         userCarousel.classList.remove("hidden")
         inputFieldAndButton.classList.add("hidden")
         errorDisp.classList.add("hidden")
      } catch (error) {
         console.error(error)
         errorDisp.textContent = `Usuario no encontrado. Inténtalo de nuevo.`
         errorDisp.classList.remove("hidden")
      }
   } else {
      alert("Please enter an email address.")
   }
})
