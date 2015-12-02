//var Nightmare = require('nightmare');

//var filelijn = new Nightmare({ show: true })
//	.goto('http://filelijn.be/en/my-touring-mobilis')
//	.type('input#ctl00_ContentLeft_ucRoute_ucSearch_tbFrom', 'Lede')
//	.type('input#ctl00_ContentLeft_ucRoute_ucSearch_tbTo', 'Gent')
//	.click('input#ctl00_ContentLeft_ucRoute_ucSearch_btnSearch')
//	.wait('#routinfo')
//	.run(function () {
//	return document.getElementsByClassName('left')[0].innerHTML;
//	});

//console.log("test");
//console.log(filelijn.evaluate());

var Nightmare = require('nightmare');
var vo = require('vo');

vo(function* () {
	var nightmare = Nightmare({ show: true });
	var link = yield nightmare
    .goto('http://yahoo.com')
	.wait()
    .type('input[title="Search"]', 'github nightmare')
    .click('.searchsubmit')
    .wait('.ac-21th')
    .evaluate(function () {
		return document.getElementsByClassName('ac-21th')[0].href;
	});
	yield nightmare.end();
	return link;
})(function (err, result) {
	if (err) return console.log(err);
	console.log(result);
});