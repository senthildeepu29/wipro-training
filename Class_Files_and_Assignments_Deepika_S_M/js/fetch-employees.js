(async () => {
  const fetch = (await import('node-fetch')).default;

  try {
    const response = await fetch("https://dummy.restapiexample.com/api/v1/employees");
    const data = await response.json();
    console.log("Employee Data:", data);
  } catch (error) {
    console.error("Error fetching data:", error);
  }
})();
