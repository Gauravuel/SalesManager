export function showChart(amount,date) {
    /*alert("Chart Comming Soon.");*/
    var ctx = document.getElementById('myChart');


    var myChart = new Chart(ctx, {
        type: 'line',

        data: {
            labels: date,
            datasets: [{
             
                data: amount,
                fill: false,
                borderColor: 'rgba(255, 81, 81, 1)',
                tension: 0,

            }]

        },
        options: {
            animations: {
                tension: {
                    duration: 5000,
                    easing: 'linear',
                    from: 1,
                    to: 0,
                    loop: true
                },
            },
            scales: {
                //y: { // defining min and max so hiding the dataset does not change scale range
                //    min: 0,

                //    max: 100
                //}
            }
        }

    });
}