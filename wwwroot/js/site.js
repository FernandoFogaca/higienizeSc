const carrossel = document.querySelector(".testimonials-grid");
if (carrossel) {
  setInterval(() => {
    carrossel.scrollBy({ left: 340, behavior: "smooth" });

    if (
      carrossel.scrollLeft + carrossel.clientWidth >=
      carrossel.scrollWidth - 10
    ) {
      carrossel.scrollTo({
        left: 0,
        behavior: "smooth",
      });
    }
  }, 4000);
}


const faqItems = document.querySelectorAll('.faq-item');

faqItems.forEach(item => {

    const button = item.querySelector('.faq-question');

    button.addEventListener('click', () => {

        item.classList.toggle('active');

    });

});
