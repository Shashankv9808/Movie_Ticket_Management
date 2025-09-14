// District Movies Hero Swiper JavaScript
class DistrictMovieSwiper {
    constructor(containerId, options = {}) {
        this.containerId = containerId;
        this.container = document.getElementById(containerId);
        
        if (!this.container) {
            console.error(`District Movie Swiper: Container '${containerId}' not found`);
            return;
        }
        
        this.options = {
            autoplay: options.autoplay !== false,
            autoplayDelay: options.autoplayDelay || 7000,
            loop: options.loop !== false,
            speed: options.speed || 800,
            effect: options.effect || 'slide',
            spaceBetween: options.spaceBetween || 0,
            centeredSlides: options.centeredSlides !== false,
            grabCursor: options.grabCursor !== false,
            keyboard: options.keyboard !== false,
            mousewheel: options.mousewheel || false,
            parallax: options.parallax !== false,
            ...options
        };
        
        this.swiper = null;
        this.backgroundSlides = [];
        this.currentSlide = 0;
        this.progressTimer = null;
        this.isUserInteracting = false;
        
        this.init();
    }
    
    init() {
        this.setupBackgroundSlides();
        this.initializeSwiper();
        this.setupEventListeners();
        this.startProgressAnimation();
        
        console.log('District Movie Swiper initialized successfully');
    }
    
    setupBackgroundSlides() {
        const bgContainer = this.container.querySelector('.swiper-backgrounds');
        const slides = this.container.querySelectorAll('[data-bg]');
        
        slides.forEach((slide, index) => {
            const bgImage = slide.getAttribute('data-bg');
            if (bgImage) {
                slide.style.backgroundImage = `url(${bgImage})`;
                this.backgroundSlides.push(slide);
            }
        });
    }
    
    initializeSwiper() {
        this.swiper = new Swiper(`#${this.containerId} .swiper`, {
            // Core parameters
            slidesPerView: 1,
            spaceBetween: this.options.spaceBetween,
            centeredSlides: this.options.centeredSlides,
            loop: this.options.loop,
            speed: this.options.speed,
            effect: this.options.effect,
            grabCursor: this.options.grabCursor,
            
            // Autoplay
            autoplay: this.options.autoplay ? {
                delay: this.options.autoplayDelay,
                disableOnInteraction: false,
                pauseOnMouseEnter: true,
                reverseDirection: false
            } : false,
            
            // Parallax
            parallax: this.options.parallax,
            
            // Navigation arrows
            navigation: {
                nextEl: `#${this.containerId} .district-swiper-next`,
                prevEl: `#${this.containerId} .district-swiper-prev`,
                disabledClass: 'swiper-button-disabled'
            },
            
            // Pagination
            pagination: {
                el: `#${this.containerId} .district-pagination`,
                clickable: true,
                bulletClass: 'swiper-pagination-bullet',
                bulletActiveClass: 'swiper-pagination-bullet-active'
            },
            
            // Keyboard control
            keyboard: this.options.keyboard ? {
                enabled: true,
                onlyInViewport: true,
                pageUpDown: false
            } : false,
            
            // Touch settings
            touchRatio: 1,
            touchAngle: 45,
            simulateTouch: true,
            allowTouchMove: true,
            touchStartPreventDefault: false,
            touchStartForcePreventDefault: false,
            touchMoveStopPropagation: false,
            
            // Resistance
            resistance: true,
            resistanceRatio: 0.85,
            
            // Progress
            watchSlidesProgress: true,
            watchSlidesVisibility: true,
            
            // Breakpoints for responsive design
            breakpoints: {
                320: {
                    slidesPerView: 1,
                    spaceBetween: 0
                },
                768: {
                    slidesPerView: 1,
                    spaceBetween: 0
                },
                1024: {
                    slidesPerView: 1,
                    spaceBetween: 0
                }
            },
            
            // Event callbacks
            on: {
                init: (swiper) => {
                    this.onSwiperInit(swiper);
                },
                slideChange: (swiper) => {
                    this.onSlideChange(swiper);
                },
                slideChangeTransitionStart: (swiper) => {
                    this.onSlideTransitionStart(swiper);
                },
                slideChangeTransitionEnd: (swiper) => {
                    this.onSlideTransitionEnd(swiper);
                },
                touchStart: () => {
                    this.onUserInteractionStart();
                },
                touchEnd: () => {
                    this.onUserInteractionEnd();
                },
                click: (swiper, event) => {
                    this.onSwiperClick(swiper, event);
                },
                autoplayStart: () => {
                    this.startProgressAnimation();
                },
                autoplayStop: () => {
                    this.stopProgressAnimation();
                },
                autoplayPause: () => {
                    this.pauseProgressAnimation();
                },
                autoplayResume: () => {
                    this.resumeProgressAnimation();
                }
            }
        });
    }
    
    onSwiperInit(swiper) {
        this.updateBackgroundSlide(0);
        this.dispatchEvent('swiperInit', { swiper: swiper });
    }
    
    onSlideChange(swiper) {
        this.currentSlide = swiper.realIndex;
        this.updateBackgroundSlide(this.currentSlide);
        this.restartProgressAnimation();
        
        this.dispatchEvent('slideChange', {
            activeIndex: this.currentSlide,
            previousIndex: swiper.previousIndex,
            slides: swiper.slides
        });
    }
    
    onSlideTransitionStart(swiper) {
        this.pauseProgressAnimation();
        this.dispatchEvent('slideTransitionStart', { swiper: swiper });
    }
    
    onSlideTransitionEnd(swiper) {
        this.resumeProgressAnimation();
        this.dispatchEvent('slideTransitionEnd', { swiper: swiper });
    }
    
    onUserInteractionStart() {
        this.isUserInteracting = true;
        this.pauseProgressAnimation();
    }
    
    onUserInteractionEnd() {
        this.isUserInteracting = false;
        setTimeout(() => {
            if (!this.isUserInteracting) {
                this.resumeProgressAnimation();
            }
        }, 1000);
    }
    
    onSwiperClick(swiper, event) {
        // Handle clicks on action buttons
        const target = event.target;
        
        if (target.classList.contains('book-now-btn')) {
            this.handleBookNow(target);
        } else if (target.classList.contains('notify-btn')) {
            this.handleNotifyMe(target);
        }
    }
    
    updateBackgroundSlide(slideIndex) {
        this.backgroundSlides.forEach((slide, index) => {
            if (index === slideIndex) {
                slide.classList.add('active');
            } else {
                slide.classList.remove('active');
            }
        });
    }
    
    startProgressAnimation() {
        const progressFill = this.container.querySelector('.progress-fill');
        if (!progressFill) return;
        
        this.stopProgressAnimation();
        
        const duration = this.options.autoplayDelay;
        progressFill.style.transition = `width ${duration}ms linear`;
        progressFill.style.width = '100%';
        
        this.progressTimer = setTimeout(() => {
            this.resetProgressAnimation();
        }, duration);
    }
    
    pauseProgressAnimation() {
        const progressFill = this.container.querySelector('.progress-fill');
        if (!progressFill) return;
        
        const currentWidth = progressFill.offsetWidth;
        const containerWidth = progressFill.parentElement.offsetWidth;
        const percentage = (currentWidth / containerWidth) * 100;
        
        progressFill.style.transition = 'none';
        progressFill.style.width = `${percentage}%`;
        
        clearTimeout(this.progressTimer);
    }
    
    resumeProgressAnimation() {
        if (this.isUserInteracting) return;
        
        const progressFill = this.container.querySelector('.progress-fill');
        if (!progressFill) return;
        
        const currentWidth = progressFill.offsetWidth;
        const containerWidth = progressFill.parentElement.offsetWidth;
        const currentPercentage = (currentWidth / containerWidth) * 100;
        const remainingPercentage = 100 - currentPercentage;
        const remainingTime = (remainingPercentage / 100) * this.options.autoplayDelay;
        
        if (remainingTime > 100) {
            progressFill.style.transition = `width ${remainingTime}ms linear`;
            progressFill.style.width = '100%';
            
            this.progressTimer = setTimeout(() => {
                this.resetProgressAnimation();
            }, remainingTime);
        }
    }
    
    resetProgressAnimation() {
        const progressFill = this.container.querySelector('.progress-fill');
        if (!progressFill) return;
        
        progressFill.style.transition = 'none';
        progressFill.style.width = '0%';
        
        // Small delay to ensure the reset is visible
        setTimeout(() => {
            if (this.swiper && this.swiper.autoplay && this.swiper.autoplay.running) {
                this.startProgressAnimation();
            }
        }, 50);
    }
    
    stopProgressAnimation() {
        const progressFill = this.container.querySelector('.progress-fill');
        if (progressFill) {
            progressFill.style.transition = 'none';
            progressFill.style.width = '0%';
        }
        clearTimeout(this.progressTimer);
    }
    
    restartProgressAnimation() {
        this.stopProgressAnimation();
        if (this.swiper && this.swiper.autoplay && this.swiper.autoplay.running) {
            setTimeout(() => this.startProgressAnimation(), 100);
        }
    }
    
    setupEventListeners() {
        // Visibility change (pause when tab is not visible)
        document.addEventListener('visibilitychange', () => {
            if (document.hidden) {
                this.swiper?.autoplay?.stop();
                this.stopProgressAnimation();
            } else {
                this.swiper?.autoplay?.start();
                this.startProgressAnimation();
            }
        });
        
        // Intersection observer for performance
        if ('IntersectionObserver' in window) {
            const observer = new IntersectionObserver((entries) => {
                entries.forEach(entry => {
                    if (entry.isIntersecting) {
                        this.swiper?.autoplay?.start();
                        this.startProgressAnimation();
                    } else {
                        this.swiper?.autoplay?.stop();
                        this.stopProgressAnimation();
                    }
                });
            }, { threshold: 0.1 });
            
            observer.observe(this.container);
        }
        
        // Mouse enter/leave for pause on hover
        this.container.addEventListener('mouseenter', () => {
            this.pauseProgressAnimation();
        });
        
        this.container.addEventListener('mouseleave', () => {
            if (!this.isUserInteracting) {
                this.resumeProgressAnimation();
            }
        });
    }
    
    handleBookNow(button) {
        const movieId = button.getAttribute('data-movie-id');
        
        // Add loading state
        button.innerHTML = 'Booking...';
        button.disabled = true;
        
        // Simulate booking process
        setTimeout(() => {
            // In a real application, navigate to booking page
            window.location.href = `/booking/movie/${movieId}`;
        }, 500);
        
        this.dispatchEvent('bookNow', { movieId: movieId });
    }
    
    handleNotifyMe(button) {
        const movieId = button.getAttribute('data-movie-id');
        
        // Update button state
        button.innerHTML = '✓ Notified';
        button.classList.add('notified');
        button.disabled = true;
        
        // Save notification preference
        const notifications = JSON.parse(localStorage.getItem('district-movie-notifications') || '[]');
        if (!notifications.includes(movieId)) {
            notifications.push(movieId);
            localStorage.setItem('district-movie-notifications', JSON.stringify(notifications));
        }
        
        this.dispatchEvent('notifyMe', { movieId: movieId });
    }
    
    dispatchEvent(eventName, detail) {
        const event = new CustomEvent(`districtSwiper:${eventName}`, {
            detail: detail,
            bubbles: true
        });
        this.container.dispatchEvent(event);
    }
    
    // Public API methods
    slideNext() {
        this.swiper?.slideNext();
    }
    
    slidePrev() {
        this.swiper?.slidePrev();
    }
    
    slideTo(index, speed = undefined) {
        this.swiper?.slideTo(index, speed);
    }
    
    startAutoplay() {
        this.swiper?.autoplay?.start();
        this.startProgressAnimation();
    }
    
    stopAutoplay() {
        this.swiper?.autoplay?.stop();
        this.stopProgressAnimation();
    }
    
    pauseAutoplay() {
        this.swiper?.autoplay?.pause();
        this.pauseProgressAnimation();
    }
    
    resumeAutoplay() {
        this.swiper?.autoplay?.resume();
        this.resumeProgressAnimation();
    }
    
    destroy() {
        this.stopProgressAnimation();
        this.swiper?.destroy(true, true);
        console.log('District Movie Swiper destroyed');
    }
    
    getCurrentSlide() {
        return this.currentSlide;
    }
    
    getTotalSlides() {
        return this.swiper?.slides?.length || 0;
    }
}

// Auto-initialize when DOM is ready
document.addEventListener('DOMContentLoaded', function() {
    const swiperElement = document.getElementById('moviesHeroSwiper');
    
    if (swiperElement) {
        // Initialize the District Movie Swiper
        window.districtMovieSwiper = new DistrictMovieSwiper('moviesHeroSwiper', {
            autoplay: true,
            autoplayDelay: 7000,
            loop: true,
            speed: 800,
            parallax: true,
            keyboard: true,
            grabCursor: true
        });
        
        // Listen for custom events
        swiperElement.addEventListener('districtSwiper:slideChange', function(e) {
            console.log('Slide changed:', e.detail);
        });
        
        swiperElement.addEventListener('districtSwiper:bookNow', function(e) {
            console.log('Book now clicked for movie:', e.detail.movieId);
        });
        
        swiperElement.addEventListener('districtSwiper:notifyMe', function(e) {
            console.log('Notify me clicked for movie:', e.detail.movieId);
        });
    }
});

// Utility function for manual initialization
window.initDistrictMovieSwiper = function(containerId, options = {}) {
    return new DistrictMovieSwiper(containerId, options);
};

// Export for module systems
if (typeof module !== 'undefined' && module.exports) {
    module.exports = DistrictMovieSwiper;
}