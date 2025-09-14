// Sample data
const sampleData = {
  movies: [
    {
      title: "Param Sundari",
      rating: "UA13+",
      language: "Hindi",
      price: "₹299 onwards",
      status: "Premiering this week"
    },
    {
      title: "Vash Level 2",
      rating: "A",
      language: "Hindi",
      price: "₹249 onwards",
      status: "New Release"
    },
    {
      title: "Mahavatar Narsimha",
      rating: "UA13+",
      language: "Hindi",
      price: "₹199 onwards",
      status: "Now Showing"
    },
    {
      title: "War 2",
      rating: "UA16+",
      language: "Hindi",
      price: "₹399 onwards",
      status: "Upcoming"
    }
  ],
  englishMovies: [
    {
      title: "Avengers: Endgame",
      rating: "UA13+",
      language: "English",
      price: "₹350 onwards",
      status: "Now Showing"
    },
    {
      title: "The Batman",
      rating: "UA16+",
      language: "English",
      price: "₹400 onwards",
      status: "New Release"
    },
    {
      title: "Spider-Man: No Way Home",
      rating: "UA13+",
      language: "English",
      price: "₹320 onwards",
      status: "Now Showing"
    },
    {
      title: "Top Gun: Maverick",
      rating: "UA16+",
      language: "English",
      price: "₹380 onwards",
      status: "Upcoming"
    }
  ],
  events: [
    {
      title: "Zamna India | Gurugram",
      date: "Sat, 29 Nov, 5:00 PM",
      venue: "Venue to be announced, Gurugram",
      price: "₹3000 onwards",
      category: "Music"
    },
    {
      title: "Rolling Loud India",
      date: "22 Nov - 23 Nov, 3PM",
      venue: "Loud Park, Kharghar, Mumbai",
      price: "₹6000 onwards",
      category: "Music Festival"
    },
    {
      title: "Sunburn Arena ft. Martin Garrix",
      date: "15 Dec, 8:00 PM",
      venue: "DLF CyberHub, Gurugram",
      price: "₹4500 onwards",
      category: "Electronic"
    },
    {
      title: "NH7 Weekender",
      date: "3 Dec - 4 Dec, 4:00 PM",
      venue: "Parade Grounds, Pune",
      price: "₹2500 onwards",
      category: "Multi-Genre"
    }
  ],
  activities: [
    {
      title: "Chokhi Dhani | Sonipat",
      offer: "50% off up to ₹300",
      time: "Daily, 6:00 PM onwards",
      location: "Chokhi Dhani Sonipat, Haryana",
      price: "₹700 onwards"
    },
    {
      title: "Splash Water World | Rohtak",
      offer: "50% off up to ₹300",
      time: "Every Sun, Fri & Sat, 10:00 AM to 6:00 PM",
      location: "Splash Water World, Rohtak",
      price: "₹600 onwards"
    },
    {
      title: "Adventure Island | Delhi",
      offer: "40% off up to ₹250",
      time: "Daily, 10:00 AM to 8:00 PM",
      location: "Adventure Island, Rohini, Delhi",
      price: "₹850 onwards"
    },
    {
      title: "Snow World | Gurgaon",
      offer: "30% off up to ₹200",
      time: "Daily, 11:00 AM to 9:00 PM",
      location: "DLF Mall of India, Noida",
      price: "₹500 onwards"
    }
  ]
};

// Initialize Application
document.addEventListener('DOMContentLoaded', function() {
  console.log('District app initializing...');
  
  // Initialize theme management
  initializeTheme();
  
  // Initialize navigation
  initializeNavigation();
  
  // Initialize content
  initializeContent();
  
  // Initialize search functionality
  initializeSearch();
  
  // Initialize interactions
  initializeInteractions();
  
  console.log('District app initialized successfully');
});

// Theme Management
function initializeTheme() {
  const themeToggle = document.getElementById('themeToggle');
  
  if (!themeToggle) {
    console.warn('Theme toggle button not found');
    return;
  }
  
  // Get stored theme or use system preference
  let currentTheme = localStorage.getItem('district-theme');
  if (!currentTheme) {
    currentTheme = window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light';
  }
  
  // Apply initial theme
  applyTheme(currentTheme);
  
  // Add click event listener
  themeToggle.addEventListener('click', function(e) {
    e.preventDefault();
    e.stopPropagation();
    console.log('Theme toggle clicked');
    
    const newTheme = document.documentElement.getAttribute('data-color-scheme') === 'dark' ? 'light' : 'dark';
    applyTheme(newTheme);
  });
  
  function applyTheme(theme) {
    console.log('Applying theme:', theme);
    document.documentElement.setAttribute('data-color-scheme', theme);
    localStorage.setItem('district-theme', theme);
    
    // Update icon
    const icon = themeToggle.querySelector('.theme-toggle__icon');
    if (icon) {
      icon.textContent = theme === 'dark' ? '☀️' : '🌙';
    }
  }
}

// Navigation Management
function initializeNavigation() {
  const navToggle = document.getElementById('navToggle');
  const navMenu = document.getElementById('navMenu');
  
  if (!navToggle || !navMenu) {
    console.warn('Navigation elements not found');
    return;
  }
  
  // Mobile menu toggle
  navToggle.addEventListener('click', function(e) {
    e.preventDefault();
    e.stopPropagation();
    console.log('Navigation toggle clicked');
    navMenu.classList.toggle('active');
  });
  
  // Close mobile menu when clicking on links
  navMenu.addEventListener('click', function(e) {
    if (e.target.classList.contains('nav__link')) {
      navMenu.classList.remove('active');
      console.log('Navigation link clicked:', e.target.textContent);
    }
  });
  
  // Close mobile menu when clicking outside
  document.addEventListener('click', function(e) {
    if (!e.target.closest('.nav') && navMenu.classList.contains('active')) {
      navMenu.classList.remove('active');
    }
  });
  
  // Handle window resize
  window.addEventListener('resize', function() {
    if (window.innerWidth > 768) {
      navMenu.classList.remove('active');
    }
  });
}

// Content Management
function initializeContent() {
  console.log('Initializing content...');
  
  // Populate different content sections
  populateMovies();
  populateEnglishMovies();
  populateEvents();
  populateActivities();
  populatePremieringContent();
  
  // Initialize like functionality
  initializeLikeFeature();
}

function populateMovies() {
  const moviesGrid = document.getElementById('moviesGrid');
  if (!moviesGrid) return;
  
  moviesGrid.innerHTML = sampleData.movies
    .map((movie, index) => createMovieCard(movie, `movie-${index}`))
    .join('');
}

function populateEnglishMovies() {
  const englishMoviesGrid = document.getElementById('englishMoviesGrid');
  if (!englishMoviesGrid) return;
  
  englishMoviesGrid.innerHTML = sampleData.englishMovies
    .map((movie, index) => createMovieCard(movie, `english-movie-${index}`))
    .join('');
}

function populateEvents() {
  const eventsGrid = document.getElementById('eventsGrid');
  if (!eventsGrid) return;
  
  eventsGrid.innerHTML = sampleData.events
    .map((event, index) => createEventCard(event, `event-${index}`))
    .join('');
}

function populateActivities() {
  const activitiesGrid = document.getElementById('activitiesGrid');
  if (!activitiesGrid) return;
  
  activitiesGrid.innerHTML = sampleData.activities
    .map((activity, index) => createActivityCard(activity, `activity-${index}`))
    .join('');
}

function populatePremieringContent() {
  const premieringGrid = document.getElementById('premieringGrid');
  if (!premieringGrid) return;
  
  const premieringMovies = sampleData.movies.filter(movie => 
    movie.status.includes('Premiering') || movie.status.includes('Upcoming')
  );
  
  premieringGrid.innerHTML = premieringMovies
    .map((movie, index) => createMovieCard(movie, `premiering-${index}`))
    .join('');
}

function createMovieCard(movie, itemId) {
  const isLiked = isItemLiked(itemId);
  
  return `
    <div class="content-card" data-id="${itemId}">
      <div class="content-card__image">
        🎬
        <button class="content-card__like" data-id="${itemId}" type="button">
          ${isLiked ? '❤️' : '🤍'}
        </button>
      </div>
      <div class="content-card__content">
        <h3 class="content-card__title">${movie.title}</h3>
        <div class="content-card__meta">
          <span class="content-card__badge content-card__badge--rating">${movie.rating}</span>
          <span class="content-card__badge content-card__badge--language">${movie.language}</span>
        </div>
        <div class="content-card__info">${movie.status}</div>
        <div class="content-card__price">${movie.price}</div>
      </div>
    </div>
  `;
}

function createEventCard(event, itemId) {
  const isLiked = isItemLiked(itemId);
  
  return `
    <div class="content-card" data-id="${itemId}">
      <div class="content-card__image">
        🎵
        <button class="content-card__like" data-id="${itemId}" type="button">
          ${isLiked ? '❤️' : '🤍'}
        </button>
      </div>
      <div class="content-card__content">
        <h3 class="content-card__title">${event.title}</h3>
        <div class="content-card__meta">
          <span class="content-card__badge content-card__badge--language">${event.category}</span>
        </div>
        <div class="content-card__info">${event.date}<br>${event.venue}</div>
        <div class="content-card__price">${event.price}</div>
      </div>
    </div>
  `;
}

function createActivityCard(activity, itemId) {
  const isLiked = isItemLiked(itemId);
  
  return `
    <div class="content-card" data-id="${itemId}">
      <div class="content-card__image">
        🎯
        <button class="content-card__like" data-id="${itemId}" type="button">
          ${isLiked ? '❤️' : '🤍'}
        </button>
      </div>
      <div class="content-card__content">
        <h3 class="content-card__title">${activity.title}</h3>
        <div class="content-card__offer">${activity.offer}</div>
        <div class="content-card__info">${activity.time}<br>${activity.location}</div>
        <div class="content-card__price">${activity.price}</div>
      </div>
    </div>
  `;
}

// Like functionality
function initializeLikeFeature() {
  console.log('Initializing like feature...');
  
  document.addEventListener('click', function(e) {
    if (e.target.classList.contains('content-card__like')) {
      e.preventDefault();
      e.stopPropagation();
      
      const itemId = e.target.getAttribute('data-id');
      console.log('Like button clicked for:', itemId);
      
      toggleLike(itemId, e.target);
    }
  });
}

function toggleLike(itemId, buttonElement) {
  let likedItems = getLikedItems();
  
  const isCurrentlyLiked = likedItems.includes(itemId);
  
  if (isCurrentlyLiked) {
    // Remove from liked items
    likedItems = likedItems.filter(id => id !== itemId);
    buttonElement.textContent = '🤍';
    buttonElement.classList.remove('liked');
  } else {
    // Add to liked items
    likedItems.push(itemId);
    buttonElement.textContent = '❤️';
    buttonElement.classList.add('liked');
  }
  
  // Save to localStorage
  localStorage.setItem('district-liked-items', JSON.stringify(likedItems));
  console.log('Like toggled for:', itemId, 'Now liked:', !isCurrentlyLiked);
}

function getLikedItems() {
  const stored = localStorage.getItem('district-liked-items');
  return stored ? JSON.parse(stored) : [];
}

function isItemLiked(itemId) {
  const likedItems = getLikedItems();
  return likedItems.includes(itemId);
}

// Search functionality
function initializeSearch() {
  console.log('Initializing search...');
  
  // Header search
  const searchInput = document.querySelector('.search-input');
  const searchBtn = document.querySelector('.search-btn');
  
  // Hero search
  const heroSearchInput = document.querySelector('.hero__search-input');
  const heroSearchBtn = document.querySelector('.hero__search-btn');
  
  function performSearch(query) {
    if (query && query.trim()) {
      console.log('Searching for:', query.trim());
      alert(`Searching for: "${query.trim()}"`);
    }
  }
  
  // Header search events
  if (searchBtn && searchInput) {
    searchBtn.addEventListener('click', function(e) {
      e.preventDefault();
      e.stopPropagation();
      performSearch(searchInput.value);
    });
    
    searchInput.addEventListener('keypress', function(e) {
      if (e.key === 'Enter') {
        e.preventDefault();
        performSearch(searchInput.value);
      }
    });
  }
  
  // Hero search events
  if (heroSearchBtn && heroSearchInput) {
    heroSearchBtn.addEventListener('click', function(e) {
      e.preventDefault();
      e.stopPropagation();
      performSearch(heroSearchInput.value);
    });
    
    heroSearchInput.addEventListener('keypress', function(e) {
      if (e.key === 'Enter') {
        e.preventDefault();
        performSearch(heroSearchInput.value);
      }
    });
  }
}

// Interactions and animations
function initializeInteractions() {
  console.log('Initializing interactions...');
  
  // Card click handling
  document.addEventListener('click', function(e) {
    const card = e.target.closest('.content-card');
    if (card && !e.target.classList.contains('content-card__like')) {
      const itemId = card.getAttribute('data-id');
      console.log('Card clicked:', itemId);
      
      // Add click animation
      card.style.transform = 'scale(0.98)';
      setTimeout(() => {
        card.style.transform = '';
      }, 150);
    }
  });
  
  // Scroll header shadow
  let ticking = false;
  
  function updateHeader() {
    const scrollTop = window.pageYOffset || document.documentElement.scrollTop;
    const header = document.querySelector('.header');
    
    if (header) {
      if (scrollTop > 10) {
        header.style.boxShadow = 'var(--shadow-md)';
      } else {
        header.style.boxShadow = 'var(--shadow-sm)';
      }
    }
    
    ticking = false;
  }
  
  window.addEventListener('scroll', function() {
    if (!ticking) {
      requestAnimationFrame(updateHeader);
      ticking = true;
    }
  });
  
  // Remove loading states
  setTimeout(function() {
    const grids = document.querySelectorAll('.content-grid');
    grids.forEach(grid => {
      grid.classList.remove('loading');
    });
  }, 500);
}