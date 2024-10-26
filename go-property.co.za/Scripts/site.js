document.querySelectorAll('img').forEach(thumbnail => {
    thumbnail.addEventListener('click', function () {
        // Show modal
        const modal = document.getElementById('imageModal');
        const modalImg = document.getElementById('modalImage');
        modal.style.display = 'flex';
        modalImg.src = this.src;
    });
});

// Close modal when 'X' is clicked
document.querySelector('.close').addEventListener('click', function () {
    const modal = document.getElementById('imageModal');
    modal.style.display = 'none';
});

// Close modal when clicking outside the image
document.getElementById('imageModal').addEventListener('click', function (e) {
    if (e.target === this) {
        this.style.display = 'none';
    }
});
