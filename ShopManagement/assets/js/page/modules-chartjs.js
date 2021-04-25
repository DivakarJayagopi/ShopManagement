"use strict";


var ctx = document.getElementById("myChart5").getContext('2d');
var myChart = new Chart(ctx, {
    type: 'bar',
    data: {
        labels: ["Best Shop", "New Shop", "Super Shop"],
        datasets: [
            {
            label: 'Total Orders',
            data: [500, 800, 300],
            borderWidth: 2,
            backgroundColor: '#6777ef',
            borderColor: '#6777ef',
            borderWidth: 2.5,
            pointBackgroundColor: '#ffffff',
            pointRadius: 4
            },
            {
                label: 'Pending Orders',
                data: [100, 200, 200],
                borderWidth: 2,
                backgroundColor: 'red',
                borderColor: 'red',
                borderWidth: 2.5,
                pointBackgroundColor: '#ffffff',
                pointRadius: 4
            },
            {
                label: 'Completed Orders',
                data: [400, 600, 100],
                borderWidth: 2,
                backgroundColor: 'green',
                borderColor: 'green',
                borderWidth: 2.5,
                pointBackgroundColor: '#ffffff',
                pointRadius: 4
            }
        ]
    },
    options: {
        legend: {
            display: false
        },
        scales: {
            yAxes: [{
                gridLines: {
                    drawBorder: false,
                    color: '#f2f2f2',
                },
                ticks: {
                    beginAtZero: true,
                    stepSize: 150
                }
            }],
            xAxes: [{
                ticks: {
                    display: false
                },
                gridLines: {
                    display: false
                }
            }]
        },
    }
});

var ctx = document.getElementById("myChart6").getContext('2d');
var myChart = new Chart(ctx, {
    type: 'bar',
    data: {
        labels: ["Best Shop", "New Shop", "Super Shop"],
        datasets: [
            {
                label: 'Total Amount',
                data: [600, 900, 400],
                borderWidth: 2,
                backgroundColor: 'yellow',
                borderColor: 'yellow',
                borderWidth: 2.5,
                pointBackgroundColor: '#ffffff',
                pointRadius: 4
            },            
            {
                label: 'Completed Recived',
                data: [500, 700, 200],
                borderWidth: 2,
                backgroundColor: 'orange',
                borderColor: 'orange',
                borderWidth: 2.5,
                pointBackgroundColor: '#ffffff',
                pointRadius: 4
            },
            {
                label: 'Pending Amount',
                data: [200, 300, 300],
                borderWidth: 2,
                backgroundColor: '#6777ef',
                borderColor: '#6777ef',
                borderWidth: 2.5,
                pointBackgroundColor: '#ffffff',
                pointRadius: 4
            }
        ]
    },
    options: {
        legend: {
            display: false
        },
        scales: {
            yAxes: [{
                gridLines: {
                    drawBorder: false,
                    color: '#f2f2f2',
                },
                ticks: {
                    beginAtZero: true,
                    stepSize: 150
                }
            }],
            xAxes: [{
                ticks: {
                    display: false
                },
                gridLines: {
                    display: false
                }
            }]
        },
    }
});