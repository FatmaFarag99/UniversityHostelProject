function startXX() {
    setTimeout(function () {
        var sliderImages = Array.from(document.querySelectorAll(".jell img")),
            slideCount = sliderImages.length,
            currentSlide = 1,

            nextbutton = document.getElementById('next'),
            prevbutton = document.getElementById('prev');

        nextbutton.onclick = nextSlide;
        prevbutton.onclick = prevSlide;

        theCheacker();

        function nextSlide() {
            if (nextbutton.classList.contains('disabled')) {
                return false;
            }
            else {
                currentSlide++;
                theCheacker();
            }
        }
        function prevSlide() {
            if (prevbutton.classList.contains('disabled')) {
                return false;
            }
            else {
                currentSlide--;
                theCheacker();
            }
        }
        function theCheacker() {
            removeAllActive();

            sliderImages[currentSlide - 1].classList.add('active');

            if (currentSlide == 1) {
                prevbutton.classList.add('disabled');
            }
            else {
                prevbutton.classList.remove('disabled');
            }
            if (currentSlide == slideCount) {
                nextbutton.classList.add('disabled');
            }
            else {
                nextbutton.classList.remove('disabled');
            }
        }
        function removeAllActive() {
            sliderImages.forEach(function (img) {
                img.classList.remove('active');
            });
        }
    }, 500);
}