function BuildChart(ShopName, TodayOrderCount, TomorrowOrderCount, _3DaysOrderCount, _4DaysOrderCount, _5DaysOrderCount) {
    $(".OrderPendingStatusChartParent").html('<canvas id="OrderPendingStatusChart"></canvas>');
    var SingleShopOrderStatus = document.getElementById("OrderPendingStatusChart").getContext('2d');
    new Chart(SingleShopOrderStatus, {
        type: 'bar',
        data: {
            labels: [ShopName],
            datasets: [
                {
                    label: 'Orders Completing by Today',
                    data: [TodayOrderCount],
                    borderWidth: 2,
                    backgroundColor: '#191d21',
                    borderColor: '#191d21',
                    borderWidth: 2.5,
                    pointBackgroundColor: '#ffffff',
                    pointRadius: 4
                },
                {
                    label: 'Orders Completing by Tomorrow',
                    data: [TomorrowOrderCount],
                    borderWidth: 2,
                    backgroundColor: 'orange',
                    borderColor: 'orange',
                    borderWidth: 2.5,
                    pointBackgroundColor: '#ffffff',
                    pointRadius: 4
                },
                {
                    label: 'Orders Completing in 3 Days',
                    data: [_3DaysOrderCount],
                    borderWidth: 2,
                    backgroundColor: 'blue',
                    borderColor: 'blue',
                    borderWidth: 2.5,
                    pointBackgroundColor: '#ffffff',
                    pointRadius: 4
                },
                {
                    label: 'Orders Completing in 4 Days',
                    data: [_4DaysOrderCount],
                    borderWidth: 2,
                    backgroundColor: 'green',
                    borderColor: 'green',
                    borderWidth: 2.5,
                    pointBackgroundColor: '#ffffff',
                    pointRadius: 4
                },
                {
                    label: 'Orders Completing in 5 Days',
                    data: [_5DaysOrderCount],
                    borderWidth: 2,
                    backgroundColor: 'red',
                    borderColor: 'red',
                    borderWidth: 2.5,
                    pointBackgroundColor: '#ffffff',
                    pointRadius: 4
                }
            ]
        },
        options: {
            responsive: true,
            legend: {
                position: 'bottom',
            },
        }
    });
}