const canvas = document.getElementById('my-canvas');
const fullscreenBtn = document.getElementById('fullscreen-btn');

fullscreenBtn.addEventListener('click', toggleFullscreen);

function toggleFullscreen() {
    if (!document.fullscreenElement) {
        canvas.requestFullscreen();
    } else {
    document.exitFullscreen();
    }
}
document.addEventListener('keydown', function(event) {
    if (event.key === 'Escape') {
        document.exitFullscreen();
    }
});