$(document).ready(function () {
    // Filter functionality
    $('.filter-btn').on('click', function () {
        console.log('Filter button clicked');
        const filterType = $(this).data('filter') || $(this).data('genre') || $(this).data('format');
        const filterCategory = $(this).data('filter') ? 'language' :
            $(this).data('genre') ? 'genre' : 'format';

        // Update active state
        if (filterCategory === 'language') {
            $('.filter-btn[data-filter]').removeClass('active');
        }
        $(this).toggleClass('active');

        // Apply filters
        applyFilters();
    });

    // Clear all filters
    $('.clear-filters-btn').on('click', function () {
        $('.filter-btn').removeClass('active');
        $('.filter-btn[data-filter="all"]').addClass('active');
        $('.movie-card').show();
    });

    // View toggle
    $('.view-toggle').on('click', function () {
        const view = $(this).data('view');
        $('.view-toggle').removeClass('active');
        $(this).addClass('active');

        $('.movies-grid').attr('data-view', view);
    });

    // Book tickets functionality
    $('.book-tickets').on('click', function (e) {
        e.preventDefault();
        e.stopPropagation();

        const movieId = $(this).data('movie-id');
        window.location.href = `/booking/movie/${movieId}`;
    });

    //TODO: Notify me functionality
    // $('.notify-me').on('click', function(e) {
    //     e.preventDefault();
    //     e.stopPropagation();

    //     const movieId = $(this).data('movie-id');
    //     $(this).text('✓ Notified').addClass('notified');

    //     console.log(`Set notification for movie ${movieId}`);
    // });

    function applyFilters() {
        const activeLanguage = $('.filter-btn[data-filter].active').data('filter');
        const activeGenres = $('.filter-btn[data-genre].active').map(function () {
            return $(this).data('genre');
        }).get();
        const activeFormats = $('.filter-btn[data-format].active').map(function () {
            return $(this).data('format');
        }).get();

        $('.movie-card').each(function () {
            const card = $(this);
            const cardLanguage = card.data('language');
            const cardGenre = card.data('genre');

            let showCard = true;

            // Language filter
            if (activeLanguage && activeLanguage !== 'all' && cardLanguage !== activeLanguage) {
                showCard = false;
            }

            // Genre filter
            if (activeGenres.length > 0 && !activeGenres.includes(cardGenre)) {
                showCard = false;
            }

            // Show/hide card with animation
            if (showCard) {
                card.fadeIn(300);
            } else {
                card.fadeOut(300);
            }
        });
    }

    // Initialize filters based on URL parameters
    const urlParams = new URLSearchParams(window.location.search);
    const language = urlParams.get('language');
    const genre = urlParams.get('genre');

    if (language) {
        $(`.filter-btn[data-filter="${language}"]`).addClass('active');
        $('.filter-btn[data-filter="all"]').removeClass('active');
    }

    if (genre) {
        $(`.filter-btn[data-genre="${genre}"]`).addClass('active');
    }

    if (language || genre) {
        applyFilters();
    }
});