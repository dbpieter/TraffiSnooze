/// <reference path="./common/Util.ts"/>
'use strict'

var Nightmare = require('nightmare');
var vo = require('vo');
var program = require('commander');
var process = require('process');
var Util = require('./common/Util.js');

program
  .option('-s, --start <param>', 'Start',String)
  .option('-e, --end <param>', 'End',String)
  .parse(process.argv);

var fail = false

if (!program.start) {
    console.log('no start location given');
    fail = true;
}
if (!program.end) {
    console.log('no end location given');
    fail = true;
}

if (fail) {
    process.exit(1);
}

vo(run)(program.start,program.end,function (err, result) {
    if (err) throw err;
    console.log(result);
});

function* run(start,end) {
    let x = Date.now();
    let nightmare = Nightmare();
    let output = yield nightmare
    .goto('http://touringmobilis.myroute.be/Default.aspx')
    .wait()
   	.type('input#ctl00_ContentLeft_ucRoute_ucSearch_tbFrom', start)
    .type('input#ctl00_ContentLeft_ucRoute_ucSearch_tbTo', end)
    .click('#ctl00_ContentLeft_ucRoute_ucSearch_btnSearch')
    .wait()
    .evaluate(function () {
        var traveltime = document.querySelector('#reistijd div.time span').innerHTML;
        var delay = document.querySelector('#vertraging span').innerHTML;

        return {"traveltime":traveltime,"delay":delay}
    });
    
    output = processResult(output);
    output.traveltime = parseResult(output.traveltime);
    output.delay = parseResult(output.delay);
    
    let traveltime_normal = output.traveltime  - output.delay;
    output = { "traveltime_current":output.traveltime,"delay":output.delay,"traveltime_normal": traveltime_normal}

    let runtime = (Date.now() - x);
    console.log(runtime + "ms");
    yield nightmare.end();
    return output;
}

function processResult(result){
    let traveltime = result.traveltime;
    let delay = result.delay;
    
    traveltime = Util.StripNonAlphaNumeric(traveltime);
    delay = Util.StripNonAlphaNumeric(delay);
    
    traveltime = removeNonKeyWords(traveltime);
    delay = removeNonKeyWords(delay);
    
    traveltime = Util.StripWhiteSpace(traveltime);
    delay = Util.StripWhiteSpace(delay);

    let output = { "traveltime": traveltime, "delay": delay }

    return output;
}

function parseResult(str){

    let traveltimeArr = str.split('u');
    if (traveltimeArr.length > 1) {
        traveltimeArr[0] = parseInt(traveltimeArr[0]) * 60;
        traveltimeArr[1] = parseInt(traveltimeArr[1].replace(/(min)/ig), '');
        return traveltimeArr[0] + traveltimeArr[1];
    }
    return parseInt(str.replace(/(min)/ig), '');
}

function removeNonKeyWords(str){
    let output = str.replace(/(vertraging)/ig, '');
    return output;
}