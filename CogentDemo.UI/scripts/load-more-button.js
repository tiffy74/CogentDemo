function loadMoreHandler() {
    $('.load-more').click(function (e) {
        e.preventDefault();

        $(this).find('span').text('');
        $(this).addClass('loading');
        $(this).find('.spinner').show();

        $.get('https://localhost:44339/umbraco/surface/spotlightsurface/RenderMoreSpotlights', function (data) {
            $('.tweet__grid').append(data);
            $('.load-more').removeClass('loading');
            $('.load-more').find('.spinner').hide();
            $('.load-more').find('span').text('Load More');
        });
    })
}