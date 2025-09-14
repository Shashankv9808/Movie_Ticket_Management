// Theme Toggle Functionality for District Replica
(function() {
    'use strict';

    // Theme management
    const ThemeManager = {
        // Theme constants
        THEMES: {
            LIGHT: 'light',
            DARK: 'dark'
        },
        
        STORAGE_KEY: 'district-theme-preference',
        
        // Initialize theme system
        init() {
            this.setInitialTheme();
            this.bindEvents();
            this.updateThemeToggleIcon();
        },
        
        // Set initial theme based on user preference or system preference
        setInitialTheme() {
            const savedTheme = localStorage.getItem(this.STORAGE_KEY);
            const systemPrefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
            
            let theme = this.THEMES.LIGHT;
            
            if (savedTheme) {
                theme = savedTheme;
            } else if (systemPrefersDark) {
                theme = this.THEMES.DARK;
            }
            
            this.setTheme(theme);
        },
        
        // Set theme and update UI
        setTheme(theme) {
            document.documentElement.setAttribute('data-theme', theme);
            localStorage.setItem(this.STORAGE_KEY, theme);
            this.updateThemeToggleIcon(theme);
            
            // Dispatch custom event for other components
            window.dispatchEvent(new CustomEvent('themeChanged', {
                detail: { theme: theme }
            }));
        },
        
        // Toggle between themes
        toggleTheme() {
            const currentTheme = document.documentElement.getAttribute('data-theme');
            const newTheme = currentTheme === this.THEMES.LIGHT ? this.THEMES.DARK : this.THEMES.LIGHT;
            this.setTheme(newTheme);
        },
        
        // Update theme toggle button icon
        updateThemeToggleIcon(theme) {
            const themeToggleBtn = document.getElementById('themeToggle');
            const icon = themeToggleBtn?.querySelector('.theme-toggle__icon');
            
            if (!icon) return;
            
            const currentTheme = theme || document.documentElement.getAttribute('data-theme');
            icon.textContent = currentTheme === this.THEMES.LIGHT ? '🌙' : '☀️';
            themeToggleBtn.setAttribute('aria-label', 
                currentTheme === this.THEMES.LIGHT ? 'Switch to dark mode' : 'Switch to light mode'
            );
        },
        
        // Bind event listeners
        bindEvents() {
            // Theme toggle button
            const themeToggleBtn = document.getElementById('themeToggle');
            if (themeToggleBtn) {
                themeToggleBtn.addEventListener('click', () => this.toggleTheme());
            }
            
            // Listen for system theme changes
            window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', (e) => {
                if (!localStorage.getItem(this.STORAGE_KEY)) {
                    this.setTheme(e.matches ? this.THEMES.DARK : this.THEMES.LIGHT);
                }
            });
        }
    };

    // Search functionality
    const SearchManager = {
        init() {
            this.bindEvents();
            this.initTypeahead();
        },
        
        bindEvents() {
            const searchForms = document.querySelectorAll('.search-form');
            searchForms.forEach(form => {
                form.addEventListener('submit', this.handleSearch.bind(this));
            });
            
            const searchInputs = document.querySelectorAll('.search-input');
            searchInputs.forEach(input => {
                input.addEventListener('input', this.handleSearchInput.bind(this));
                input.addEventListener('focus', this.handleSearchFocus.bind(this));
                input.addEventListener('blur', this.handleSearchBlur.bind(this));
            });
        },
        
        handleSearch(e) {
            e.preventDefault();
            const form = e.target;
            const query = form.querySelector('.search-input').value.trim();
            
            if (query) {
                // In a real application, this would navigate to search results
                console.log('Searching for:', query);
                // window.location.href = `/search?q=${encodeURIComponent(query)}`;
            }
        },
        
        handleSearchInput(e) {
            const query = e.target.value.trim();
            if (query.length >= 2) {
                this.showSearchSuggestions(query);
            } else {
                this.hideSearchSuggestions();
            }
        },
        
        handleSearchFocus(e) {
            const query = e.target.value.trim();
            if (query.length >= 2) {
                this.showSearchSuggestions(query);
            }
        },
        
        handleSearchBlur(e) {
            // Delay hiding to allow clicking on suggestions
            setTimeout(() => {
                this.hideSearchSuggestions();
            }, 200);
        },
        
        showSearchSuggestions(query) {
            // This would typically fetch suggestions from an API
            const suggestions = this.getMockSuggestions(query);
            this.renderSuggestions(suggestions);
        },
        
        hideSearchSuggestions() {
            const existingSuggestions = document.querySelector('.search-suggestions');
            if (existingSuggestions) {
                existingSuggestions.remove();
            }
        },
        
        getMockSuggestions(query) {
            const mockData = [
                'Movies in Delhi',
                'Concerts near me',
                'Water parks in Gurgaon',
                'Comedy shows this weekend',
                'Hindi movies',
                'Adventure activities',
                'Music festivals',
                'Food events'
            ];
            
            return mockData.filter(item => 
                item.toLowerCase().includes(query.toLowerCase())
            ).slice(0, 5);
        },
        
        renderSuggestions(suggestions) {
            this.hideSearchSuggestions(); // Remove existing suggestions
            
            if (suggestions.length === 0) return;
            
            const searchContainers = document.querySelectorAll('.search-container, .mobile-search');
            
            searchContainers.forEach(container => {
                const suggestionsElement = document.createElement('div');
                suggestionsElement.className = 'search-suggestions';
                suggestionsElement.innerHTML = suggestions.map(suggestion => 
                    `<div class="search-suggestion" role="button" tabindex="0">${suggestion}</div>`
                ).join('');
                
                // Add click handlers for suggestions
                suggestionsElement.addEventListener('click', (e) => {
                    if (e.target.classList.contains('search-suggestion')) {
                        const input = container.querySelector('.search-input');
                        input.value = e.target.textContent;
                        this.hideSearchSuggestions();
                        input.form.dispatchEvent(new Event('submit'));
                    }
                });
                
                container.appendChild(suggestionsElement);
            });
        },
        
        initTypeahead() {
            // Add CSS for search suggestions if not already present
            if (!document.getElementById('search-suggestions-styles')) {
                const style = document.createElement('style');
                style.id = 'search-suggestions-styles';
                style.textContent = `
                    .search-suggestions {
                        position: absolute;
                        top: 100%;
                        left: 0;
                        right: 0;
                        background: var(--bg-card);
                        border: 1px solid var(--border-light);
                        border-radius: var(--radius-md);
                        box-shadow: var(--shadow-medium);
                        z-index: var(--z-dropdown);
                        max-height: 200px;
                        overflow-y: auto;
                        margin-top: 4px;
                    }
                    
                    .search-suggestion {
                        padding: var(--space-sm) var(--space-md);
                        cursor: pointer;
                        transition: background-color var(--transition-fast);
                        font-size: var(--font-size-sm);
                        color: var(--text-secondary);
                    }
                    
                    .search-suggestion:hover {
                        background-color: var(--bg-tertiary);
                        color: var(--text-primary);
                    }
                    
                    .search-suggestion:not(:last-child) {
                        border-bottom: 1px solid var(--border-light);
                    }
                `;
                document.head.appendChild(style);
            }
        }
    };

    // Navigation functionality
    const NavigationManager = {
        init() {
            this.bindEvents();
            this.handleActiveStates();
        },
        
        bindEvents() {
            // Mobile navigation toggle
            const navToggle = document.querySelector('.navbar-toggler');
            const navMenu = document.querySelector('.navbar-collapse');
            
            if (navToggle && navMenu) {
                navToggle.addEventListener('click', () => {
                    navMenu.classList.toggle('show');
                    navToggle.setAttribute('aria-expanded', 
                        navMenu.classList.contains('show') ? 'true' : 'false'
                    );
                });
                
                // Close mobile menu when clicking outside
                document.addEventListener('click', (e) => {
                    if (!navToggle.contains(e.target) && !navMenu.contains(e.target)) {
                        navMenu.classList.remove('show');
                        navToggle.setAttribute('aria-expanded', 'false');
                    }
                });
                
                // Close mobile menu on window resize
                window.addEventListener('resize', () => {
                    if (window.innerWidth >= 992) { // Bootstrap lg breakpoint
                        navMenu.classList.remove('show');
                        navToggle.setAttribute('aria-expanded', 'false');
                    }
                });
            }
        },
        
        handleActiveStates() {
            const currentPath = window.location.pathname;
            const navLinks = document.querySelectorAll('.nav-link');
            
            navLinks.forEach(link => {
                if (link.getAttribute('href') === currentPath) {
                    link.classList.add('active');
                }
            });
        }
    };

    // Content interactions
    const ContentManager = {
        init() {
            this.bindEvents();
            this.initAnimations();
        },
        
        bindEvents() {
            // Like button functionality
            document.addEventListener('click', (e) => {
                if (e.target.closest('.like-btn')) {
                    e.preventDefault();
                    e.stopPropagation();
                    this.handleLike(e.target.closest('.like-btn'));
                }
            });
            
            // Card click navigation
            document.addEventListener('click', (e) => {
                const card = e.target.closest('.content-card');
                if (card && !e.target.closest('.like-btn')) {
                    this.handleCardClick(card);
                }
            });
            
            // Lazy loading for images
            this.initLazyLoading();
        },
        
        handleLike(likeBtn) {
            const id = likeBtn.dataset.id;
            const type = likeBtn.dataset.type;
            
            // Toggle liked state
            likeBtn.classList.toggle('liked');
            
            // Add pulse animation
            likeBtn.classList.add('pulse');
            setTimeout(() => likeBtn.classList.remove('pulse'), 300);
            
            // In a real application, this would make an API call
            console.log(`${likeBtn.classList.contains('liked') ? 'Liked' : 'Unliked'} ${type} with ID: ${id}`);
            
            // Store preference in localStorage for demo purposes
            const likedItems = JSON.parse(localStorage.getItem('district-liked-items') || '{}');
            if (likeBtn.classList.contains('liked')) {
                likedItems[`${type}-${id}`] = true;
            } else {
                delete likedItems[`${type}-${id}`];
            }
            localStorage.setItem('district-liked-items', JSON.stringify(likedItems));
        },
        
        handleCardClick(card) {
            const id = card.dataset.id;
            let type = 'item';
            
            if (card.classList.contains('movie-card')) type = 'movie';
            else if (card.classList.contains('event-card')) type = 'event';
            else if (card.classList.contains('activity-card')) type = 'activity';
            
            // In a real application, this would navigate to detail page
            console.log(`Navigating to ${type} detail page for ID: ${id}`);
            // window.location.href = `/details/${type}/${id}`;
        },
        
        initLazyLoading() {
            if ('IntersectionObserver' in window) {
                const imageObserver = new IntersectionObserver((entries, observer) => {
                    entries.forEach(entry => {
                        if (entry.isIntersecting) {
                            const img = entry.target;
                            if (img.dataset.src) {
                                img.src = img.dataset.src;
                                img.removeAttribute('data-src');
                            }
                            img.classList.remove('loading');
                            imageObserver.unobserve(img);
                        }
                    });
                });
                
                document.querySelectorAll('img[loading="lazy"]').forEach(img => {
                    imageObserver.observe(img);
                });
            }
        },
        
        initAnimations() {
            // Animate elements on scroll
            if ('IntersectionObserver' in window) {
                const animationObserver = new IntersectionObserver((entries) => {
                    entries.forEach(entry => {
                        if (entry.isIntersecting) {
                            entry.target.classList.add('animate-fade-in');
                        }
                    });
                }, {
                    threshold: 0.1,
                    rootMargin: '0px 0px -50px 0px'
                });
                
                document.querySelectorAll('.content-section, .content-card').forEach(el => {
                    animationObserver.observe(el);
                });
            }
        },
        
        // Load saved like states
        loadLikedStates() {
            const likedItems = JSON.parse(localStorage.getItem('district-liked-items') || '{}');
            
            Object.keys(likedItems).forEach(key => {
                const [type, id] = key.split('-');
                const likeBtn = document.querySelector(`.like-btn[data-type="${type}"][data-id="${id}"]`);
                if (likeBtn) {
                    likeBtn.classList.add('liked');
                }
            });
        }
    };

    // Location management
    const LocationManager = {
        init() {
            this.bindEvents();
            this.loadSavedLocation();
        },
        
        bindEvents() {
            const locationSelects = document.querySelectorAll('.location-select');
            locationSelects.forEach(select => {
                select.addEventListener('change', this.handleLocationChange.bind(this));
            });
        },
        
        handleLocationChange(e) {
            const location = e.target.value;
            localStorage.setItem('district-selected-location', location);
            
            // Update all location selects
            const locationSelects = document.querySelectorAll('.location-select');
            locationSelects.forEach(select => {
                select.value = location;
            });
            
            // In a real application, this would update the content based on location
            console.log('Location changed to:', location);
            
            // Dispatch custom event
            window.dispatchEvent(new CustomEvent('locationChanged', {
                detail: { location: location }
            }));
        },
        
        loadSavedLocation() {
            const savedLocation = localStorage.getItem('district-selected-location');
            if (savedLocation) {
                const locationSelects = document.querySelectorAll('.location-select');
                locationSelects.forEach(select => {
                    select.value = savedLocation;
                });
            }
        }
    };

    // Utility functions
    const Utils = {
        // Debounce function for performance
        debounce(func, wait) {
            let timeout;
            return function executedFunction(...args) {
                const later = () => {
                    clearTimeout(timeout);
                    func(...args);
                };
                clearTimeout(timeout);
                timeout = setTimeout(later, wait);
            };
        },
        
        // Throttle function for scroll events
        throttle(func, limit) {
            let inThrottle;
            return function(...args) {
                if (!inThrottle) {
                    func.apply(this, args);
                    inThrottle = true;
                    setTimeout(() => inThrottle = false, limit);
                }
            };
        },
        
        // Check if element is in viewport
        isInViewport(element) {
            const rect = element.getBoundingClientRect();
            return (
                rect.top >= 0 &&
                rect.left >= 0 &&
                rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
                rect.right <= (window.innerWidth || document.documentElement.clientWidth)
            );
        }
    };

    // Performance monitoring
    const PerformanceManager = {
        init() {
            this.measurePageLoad();
            this.observeWebVitals();
        },
        
        measurePageLoad() {
            window.addEventListener('load', () => {
                const loadTime = performance.now();
                console.log(`Page loaded in ${loadTime.toFixed(2)}ms`);
            });
        },
        
        observeWebVitals() {
            // Monitor Largest Contentful Paint (LCP)
            if ('PerformanceObserver' in window) {
                new PerformanceObserver((entryList) => {
                    const entries = entryList.getEntries();
                    const lastEntry = entries[entries.length - 1];
                    console.log('LCP:', lastEntry.startTime);
                }).observe({ entryTypes: ['largest-contentful-paint'] });
                
                // Monitor First Input Delay (FID)
                new PerformanceObserver((entryList) => {
                    const entries = entryList.getEntries();
                    entries.forEach((entry) => {
                        console.log('FID:', entry.processingStart - entry.startTime);
                    });
                }).observe({ entryTypes: ['first-input'] });
            }
        }
    };

    // Initialize all managers when DOM is ready
    function initializeApp() {
        ThemeManager.init();
        SearchManager.init();
        NavigationManager.init();
        ContentManager.init();
        LocationManager.init();
        PerformanceManager.init();
        
        // Load liked states after other initialization
        ContentManager.loadLikedStates();
        
        console.log('District App initialized successfully');
    }

    // Wait for DOM to be ready
    if (document.readyState === 'loading') {
        document.addEventListener('DOMContentLoaded', initializeApp);
    } else {
        initializeApp();
    }

    // Global error handling
    window.addEventListener('error', (e) => {
        console.error('Global error:', e.error);
    });

    // Export for use in other scripts if needed
    window.DistrictApp = {
        ThemeManager,
        SearchManager,
        NavigationManager,
        ContentManager,
        LocationManager,
        Utils
    };

})();