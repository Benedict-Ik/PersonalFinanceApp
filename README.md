# Personal Finance App

Here is what we did in this branch:

- Chart.js is a simple yet flexible JavaScript charting library that allows you to create beautiful, interactive charts using HTML5’s \<canvas> element.
- It supports various chart types, such as:
    - Line
    - Bar
    - Pie
    - Doughnut
    - Radar
    - Polar area
    - Bubble
    - Scatter

To embed Chart.js in your application, do the following:

- In the `index.cshtml` file, include the below line just below the container div.
```html
<div>
  <canvas id="myChart"></canvas>
</div>
```

- Add the below scripts just below the above created div.
```js
<script src="https://cdn.jsdelivr.net/npm/chart.js"></script>

<script>
  const ctx = document.getElementById('myChart');

  new Chart(ctx, {
    type: 'bar',
    data: {
      labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
      datasets: [{
        label: '# of Votes',
        data: [12, 19, 3, 5, 2, 3],
        borderWidth: 1
      }]
    },
    options: {
      scales: {
        y: {
          beginAtZero: true
        }
      }
    }
  });
</script>
```

- When you run the app, you should see a static chart displayed.

Adjusting to meet our application's needs:

- Define and implement a new method (`GetChartData`) in the IService and Service classes respectively.
- The implemented service should look like:
```C#
public IQueryable GetChartData()
{
    var data =
        _appDbContext.Expenses
        .GroupBy(e => e.Category)
        .Select(g => new
        {
            Category = g.Key,
            Total = g.Sum(e => e.Amount)
        });
    return data;
}
```
- The above code tries to achieve the following:
    1.  Retrieves expense data from the _appDbContext.Expenses database table.
    2. Groups the data by the Category property using the GroupBy method.
    3. Selects a new anonymous object with two properties:
        - Category: the category name (from the GroupBy key).
        - Total: the total amount for each category (calculated using the Sum method).
    4. Returns the resulting data as an IQueryable object.

- Next, we create a new action method in the controller class called `GetChart` with the below code.
```c#
public IActionResult GetChart()
{
    var data = _expensesService.GetChartData();
    return Json(data);
}
```

- Once done, navigate to the `Index.cshtml` page to modify the previously inserted script. 
- Note that in order for us to use data labels, we had to insert the script.
- Updated code:
```html
<h2>Expenses Overview</h2>
<div>
    <canvas id="myChart" width="400" height="400"></canvas>
</div>

<script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
<script src="https://cdn.jsdelivr.net/npm/chartjs-plugin-datalabels@2"></script>

<script>
    const ctx = document.getElementById('myChart');

    fetch('/Expenses/GetChart')
        .then(response => response.json())
        .then(data => {
            console.log('Chart data:', data); 

            // Check if data exists
            if (!data || data.length === 0) {
                console.warn('No chart data returned');
                return;
            }

            // Create the chart
            new Chart(ctx, {
                type: 'pie',
                data: {
                    labels: data.map(d => d.category),
                    datasets: [{
                        data: data.map(d => d.total),
                        backgroundColor: [
                            '#FF6384',
                            '#36A2EB',
                            '#FFCE56',
                            '#4BC0C0',
                            '#9966FF',
                            '#FF9F40'
                        ]
                    }]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    plugins: {
                        legend: {
                            position: 'bottom'
                        },
                        title: {
                            display: true,
                            text: 'Expenses by Category'
                        },
                        datalabels: {
                            color: '#fff',
                            // Display both category and formatted amount value on the chart
                            formatter: (value, context) => {
                                const category = context.chart.data.labels[context.dataIndex];
                                return `${category}: ₦${value.toLocaleString('en-NG')}`;
                            },
                            font: {
                                weight: 'bold'
                            }
                        }
                    }
                },
                plugins: [ChartDataLabels] 
            });
        })
        .catch(error => console.error('Error fetching chart data:', error));
</script>
```