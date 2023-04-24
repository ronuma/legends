async function fetchStats() {
  try {
    const stats_response = await fetch("http://127.0.0.1:8000/stats", {
      method: "GET",
    });

    const stats = await stats_response.json();
    console.log("Stats: ");
    console.log(stats);
  } catch (error) {
    console.log(error);
  }
}

fetchStats();
