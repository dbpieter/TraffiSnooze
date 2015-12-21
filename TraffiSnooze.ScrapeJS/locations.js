var scraperjs = require('scraperjs');

scraperjs.DynamicScraper.create('http://touringmobilis.myroute.be/Default.aspx')
    .scrape(function ($) {
        $('#ctl00_ContentLeft_ucRoute_ucSearch_tbFrom').attr('autocomplete','on');
        $('#ctl00_ContentLeft_ucRoute_ucSearch_tbFrom').val('aa');

        
        
        
        return $('html').html();
    })
    .then(function (news) {
        console.log(news);
    });