// Hero Movie Slider JavaScript Component
class HeroMovieSlider {
    constructor(containerId, options = {}) {
        this.container = document.getElementById(containerId);
        if (!this.container) {
            console.error(`Hero Movie Slider: Container with ID '${containerId}' not found`);
            return;
        }
        
        this.options = {
            autoPlay: options.autoPlay || true,
            autoPlayInterval: options.autoPlayInterval || 5000,
            transitionDuration: options.transitionDuration || 600,
            enableSwipe: options.enableSwipe !== false,
            enableKeyboard: options.enableKeyboard !== false,
            pauseOnHover: options.pauseOnHover !== false,
            ...options
        };
        
        this.currentSlide = 0;
        this.totalSlides = 0;
        this.isAutoPlaying = this.options.autoPlay;
        this.autoPlayTimer = null;
        this.isTransitioning = false;
        
        this.init();
    }
    
    init() {
        this.setupElements();
        this.setupEventListeners();
        this.setupAutoPlay();
        this.setupSwipeGestures();
        this.setupKeyboardNavigation();
        
        // Initialize first slide
        this.updateSlider(0, false);
        
        console.log('Hero Movie Slider initialized successfully');
    }
    
    setupElements() {
        // Get all slider elements
        this.slides = this.container.querySelectorAll('.slide');
        this.backgrounds = this.container.querySelectorAll('.slider-bg');
        this.dots = this.container.querySelectorAll('.pagination-dot');
        this.prevBtn = this.container.querySelector('.slider-prev');
        this.nextBtn = this.container.querySelector('.slider-next');
        this.autoPlayBtn = this.container.querySelector('.autoplay-toggle');
        
        this.totalSlides = this.slides.length;
        
        if (this.totalSlides === 0) {
            console.warn('Hero Movie Slider: No slides found');
            return;
        }
        
        // Setup initial states
        this.updateNavigationState();
    }
    
    setupEventListeners() {
        // Navigation arrows
        if (this.prevBtn) {
            this.prevBtn.addEventListener('click', () => this.previousSlide());
        }
        
        if (this.nextBtn) {
            this.nextBtn.addEventListener('click', () => this.nextSlide());
        }
        
        // Pagination dots
        this.dots.forEach((dot, index) => {
            dot.addEventListener('click', () => this.goToSlide(index));
        });
        
        // Auto-play toggle
        if (this.autoPlayBtn) {
            this.autoPlayBtn.addEventListener('click', () => this.toggleAutoPlay());
        }
        
        // Movie action buttons
        this.setupMovieActions();
        
        // Pause on hover
        if (this.options.pauseOnHover) {
            this.container.addEventListener('mouseenter', () => this.pauseAutoPlay());
            this.container.addEventListener('mouseleave', () => this.resumeAutoPlay());
        }
        
        // Visibility change (pause when tab is not active)
        document.addEventListener('visibilitychange', () => {
            if (document.hidden) {
                this.pauseAutoPlay();
            } else if (this.isAutoPlaying) {
                this.resumeAutoPlay();
            }
        });
    }
    
    setupMovieActions() {
        // Book Now buttons
        this.container.addEventListener('click', (e) => {
            if (e.target.closest('.book-now-btn')) {
                const movieId = e.target.closest('.book-now-btn').dataset.movieId;
                this.handleBookNow(movieId);
            }
        });
        
        // Like buttons
        this.container.addEventListener('click', (e) => {
            if (e.target.closest('.like-btn')) {
                e.preventDefault();
                const btn = e.target.closest('.like-btn');
                const movieId = btn.dataset.movieId;
                this.handleLike(btn, movieId);
            }
        });
        
        // Notify Me buttons
        this.container.addEventListener('click', (e) => {
            if (e.target.closest('.notify-btn')) {
                const movieId = e.target.closest('.notify-btn').dataset.movieId;
                this.handleNotifyMe(movieId);
            }
        });
        
        // Trailer buttons
        this.container.addEventListener('click', (e) => {
            if (e.target.closest('.trailer-btn')) {
                const trailerUrl = e.target.closest('.trailer-btn').dataset.trailerUrl;
                this.handleTrailer(trailerUrl);
            }
        });
    }
    
    setupSwipeGestures() {
        if (!this.options.enableSwipe) return;
        
        let startX = 0;
        let startY = 0;
        let isDown = false;
        
        this.container.addEventListener('touchstart', (e) => {
            startX = e.touches[0].clientX;
            startY = e.touches[0].clientY;
            isDown = true;
        }, { passive: true });
        
        this.container.addEventListener('touchend', (e) => {
            if (!isDown) return;
            
            const endX = e.changedTouches[0].clientX;
            const endY = e.changedTouches[0].clientY;
            const diffX = startX - endX;
            const diffY = startY - endY;
            
            // Check if horizontal swipe is more significant than vertical
            if (Math.abs(diffX) > Math.abs(diffY) && Math.abs(diffX) > 50) {
                if (diffX > 0) {
                    this.nextSlide();
                } else {
                    this.previousSlide();
                }
            }
            
            isDown = false;
        }, { passive: true });
    }
    
    setupKeyboardNavigation() {
        if (!this.options.enableKeyboard) return;
        
        document.addEventListener('keydown', (e) => {
            // Only handle keys when slider is in viewport
            if (!this.isInViewport()) return;
            
            switch (e.key) {
                case 'ArrowLeft':
                    e.preventDefault();
                    this.previousSlide();
                    break;
                case 'ArrowRight':
                    e.preventDefault();
                    this.nextSlide();
                    break;
                case ' ': // Spacebar
                    e.preventDefault();
                    this.toggleAutoPlay();
                    break;
                case 'Home':
                    e.preventDefault();
                    this.goToSlide(0);
                    break;
                case 'End':
                    e.preventDefault();
                    this.goToSlide(this.totalSlides - 1);
                    break;
            }
        });
    }
    
    setupAutoPlay() {
        if (this.options.autoPlay) {
            this.startAutoPlay();
        }
    }
    
    updateSlider(targetSlide, animate = true) {
        if (this.isTransitioning && animate) return;
        if (targetSlide < 0 || targetSlide >= this.totalSlides) return;
        
        this.isTransitioning = animate;
        
        // Update slides
        this.slides.forEach((slide, index) => {
            slide.classList.remove('active', 'prev');
            if (index === targetSlide) {
                slide.classList.add('active');
            } else if (index === this.currentSlide && animate) {
                slide.classList.add('prev');
            }
        });
        
        // Update backgrounds
        this.backgrounds.forEach((bg, index) => {
            bg.classList.toggle('active', index === targetSlide);
        });
        
        // Update dots
        this.dots.forEach((dot, index) => {
            dot.classList.toggle('active', index === targetSlide);
        });
        
        // Update navigation state
        this.currentSlide = targetSlide;
        this.updateNavigationState();
        
        // Clear transition state after animation
        if (animate) {
            setTimeout(() => {
                this.isTransitioning = false;
            }, this.options.transitionDuration);
        }
        
        // Dispatch custom event
        this.dispatchSlideChangeEvent();
    }
    
    nextSlide() {
        const nextIndex = (this.currentSlide + 1) % this.totalSlides;
        this.updateSlider(nextIndex);
    }
    
    previousSlide() {
        const prevIndex = (this.currentSlide - 1 + this.totalSlides) % this.totalSlides;
        this.updateSlider(prevIndex);
    }
    
    goToSlide(slideIndex) {
        if (slideIndex >= 0 && slideIndex < this.totalSlides && slideIndex !== this.currentSlide) {
            this.updateSlider(slideIndex);
        }
    }
    
    startAutoPlay() {
        this.clearAutoPlay();
        if (this.totalSlides <= 1) return;
        
        this.autoPlayTimer = setInterval(() => {
            this.nextSlide();
        }, this.options.autoPlayInterval);
        
        this.isAutoPlaying = true;
        this.updateAutoPlayButton();
    }
    
    pauseAutoPlay() {
        this.clearAutoPlay();
    }
    
    resumeAutoPlay() {
        if (this.isAutoPlaying) {
            this.startAutoPlay();
        }
    }
    
    clearAutoPlay() {
        if (this.autoPlayTimer) {
            clearInterval(this.autoPlayTimer);
            this.autoPlayTimer = null;
        }
    }
    
    toggleAutoPlay() {
        if (this.isAutoPlaying) {
            this.isAutoPlaying = false;
            this.clearAutoPlay();
        } else {
            this.isAutoPlaying = true;
            this.startAutoPlay();
        }
        this.updateAutoPlayButton();
    }
    
    updateAutoPlayButton() {
        if (!this.autoPlayBtn) return;
        
        const playIcon = this.autoPlayBtn.querySelector('.play-icon');
        const pauseIcon = this.autoPlayBtn.querySelector('.pause-icon');
        
        if (this.isAutoPlaying) {
            playIcon?.classList.add('d-none');
            pauseIcon?.classList.remove('d-none');
            this.autoPlayBtn.setAttribute('aria-label', 'Pause slideshow');
        } else {
            playIcon?.classList.remove('d-none');
            pauseIcon?.classList.add('d-none');
            this.autoPlayBtn.setAttribute('aria-label', 'Play slideshow');
        }
    }
    
    updateNavigationState() {
        // Update aria labels for accessibility
        if (this.prevBtn) {
            this.prevBtn.setAttribute('aria-label', `Previous movie (${this.currentSlide + 1} of ${this.totalSlides})`);
        }
        
        if (this.nextBtn) {
            this.nextBtn.setAttribute('aria-label', `Next movie (${this.currentSlide + 1} of ${this.totalSlides})`);
        }
    }
    
    handleBookNow(movieId) {
        console.log(`Booking movie with ID: ${movieId}`);
        // In a real application, navigate to booking page
        window.location.href = `/booking/movie/${movieId}`;
    }
    
    handleLike(button, movieId) {
        const isLiked = button.classList.contains('liked');
        const likeText = button.querySelector('.like-text');
        
        button.classList.toggle('liked');
        
        if (likeText) {
            likeText.textContent = isLiked ? 'Like' : 'Liked';
        }
        
        // Add animation effect
        button.style.transform = 'scale(0.9)';
        setTimeout(() => {
            button.style.transform = '';
        }, 150);
        
        // Save to localStorage for demo purposes
        const likedMovies = JSON.parse(localStorage.getItem('district-liked-movies') || '[]');
        if (isLiked) {
            const index = likedMovies.indexOf(parseInt(movieId));
            if (index > -1) likedMovies.splice(index, 1);
        } else {
            likedMovies.push(parseInt(movieId));
        }
        localStorage.setItem('district-liked-movies', JSON.stringify(likedMovies));
        
        console.log(`${isLiked ? 'Unliked' : 'Liked'} movie with ID: ${movieId}`);
    }
    
    handleNotifyMe(movieId) {
        console.log(`Setting notification for movie with ID: ${movieId}`);
        // In a real application, show notification signup modal
        alert('Notification set! We\'ll let you know when booking opens.');
    }
    
    handleTrailer(trailerUrl) {
        console.log(`Playing trailer: ${trailerUrl}`);
        // In a real application, open video modal or navigate to video page
        window.open(trailerUrl, '_blank');
    }
    
    dispatchSlideChangeEvent() {
        const event = new CustomEvent('slideChange', {
            detail: {
                currentSlide: this.currentSlide,
                totalSlides: this.totalSlides,
                slider: this
            }
        });
        this.container.dispatchEvent(event);
    }
    
    isInViewport() {
        const rect = this.container.getBoundingClientRect();
        return rect.top < window.innerHeight && rect.bottom > 0;
    }
    
    // Public API methods
    destroy() {
        this.clearAutoPlay();
        // Remove event listeners and cleanup
        console.log('Hero Movie Slider destroyed');
    }
    
    refresh() {
        this.setupElements();
        this.updateSlider(0, false);
        console.log('Hero Movie Slider refreshed');
    }
    
    getCurrentSlide() {
        return this.currentSlide;
    }
    
    getTotalSlides() {
        return this.totalSlides;
    }
}

// Initialize slider when DOM is ready
document.addEventListener('DOMContentLoaded', function() {
    const sliderContainer = document.getElementById('heroMovieSlider');
    if (sliderContainer) {
        // Initialize the slider with options
        window.heroMovieSlider = new HeroMovieSlider('heroMovieSlider', {
            autoPlay: true,
            autoPlayInterval: 6000,
            transitionDuration: 600,
            enableSwipe: true,
            enableKeyboard: true,
            pauseOnHover: true
        });
        
        // Listen for slide change events
        sliderContainer.addEventListener('slideChange', function(e) {
            console.log(`Slide changed to: ${e.detail.currentSlide + 1} of ${e.detail.totalSlides}`);
        });
    }
    
    // Load liked states from localStorage
    loadLikedStates();
});

// Load saved like states
function loadLikedStates() {
    const likedMovies = JSON.parse(localStorage.getItem('district-liked-movies') || '[]');
    
    likedMovies.forEach(movieId => {
        const likeBtn = document.querySelector(`.like-btn[data-movie-id="${movieId}"]`);
        if (likeBtn) {
            likeBtn.classList.add('liked');
            const likeText = likeBtn.querySelector('.like-text');
            if (likeText) {
                likeText.textContent = 'Liked';
            }
        }
    });
}

// Intersection Observer for performance optimization
if ('IntersectionObserver' in window) {
    const sliderObserver = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            const slider = window.heroMovieSlider;
            if (!slider) return;
            
            if (entry.isIntersecting) {
                // Slider is visible, resume auto-play if enabled
                if (slider.isAutoPlaying) {
                    slider.resumeAutoPlay();
                }
            } else {
                // Slider is not visible, pause auto-play
                slider.pauseAutoPlay();
            }
        });
    }, {
        threshold: 0.1
    });
    
    // Observe the slider when it exists
    document.addEventListener('DOMContentLoaded', function() {
        const sliderContainer = document.getElementById('heroMovieSlider');
        if (sliderContainer) {
            sliderObserver.observe(sliderContainer);
        }
    });
}