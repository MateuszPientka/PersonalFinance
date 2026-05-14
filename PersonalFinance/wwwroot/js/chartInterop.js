window.setupChart = (canvasId, type, labels, data, title) => {
    if (!window.charts) {
        window.charts = {};
    }

    const canvas = document.getElementById(canvasId);
    if (!canvas) return;

    if (window.charts[canvasId]) {
        window.charts[canvasId].destroy();
    }

    const ctx = canvas.getContext('2d');

    window.charts[canvasId] = new Chart(ctx, {
        type: type,
        data: {
            labels: labels,
            datasets: [{
                label: title,
                data: data,
                backgroundColor: type === 'line' ? 'rgba(13, 110, 253, 0.2)' : [
                    '#0d6efd', '#198754', '#ffc107', '#dc3545', '#0dcaf0', '#6610f2'
                ],
                borderColor: type === 'line' ? '#0d6efd' : 'transparent',
                borderWidth: type === 'line' ? 2 : 0,

                fill: true,
                tension: 0.3,
                pointRadius: type === 'line' ? 3 : 0
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            resizeDelay: 100,
            plugins: {
                legend: {
                    display: type !== 'line',
                    labels: { color: 'white' }
                }
            },
            scales: type === 'line' ? {
                y: { grid: { color: 'rgba(255,255,255,0.1)' }, ticks: { color: 'white' } },
                x: { grid: { display: false }, ticks: { color: 'white' } }
            } : {}
        }
    });
};