const fetch = require('node-fetch');

fetch("https://dummy.restapiexample.com/api/v1/employees")
  .then(res => res.json())
  .then(data => {
    console.log("Employee Data:");
    console.log(data);
  })
  .catch(err => {
    console.error("Fetch error:", err);
  });
