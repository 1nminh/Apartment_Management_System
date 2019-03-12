function toggleOnOff() {
    var x = document.getElementById("myDIV");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}
$(function() {    // Makes sure the code contained doesn't run until
                  //     all the DOM elements have loaded

    $('#id1').change(function(){
        $('.notDisplay').hide();
        $('#' + $(this).val()).show();
    });

    $('#id2').change(function(){
        $('.notDisplay').hide();
        $('#' + $(this).val()).show();
    });

});


(function() {
    
    // get references to select list and display text box
    var sel = document.getElementById('scripts');
    var el = document.getElementById('display');


    function getSelectedOption(sel) {
        var opt;
        for ( var i = 0, len = sel.options.length; i < len; i++ ) {
            opt = sel.options[i];
            if ( opt.selected === true ) {
                break;
            }
        }
        return opt;
    }

    // assign onclick handlers to the buttons
    document.getElementById('showVal').onclick = function () {
        el.value = sel.value;    
    }
    
    document.getElementById('showTxt').onclick = function () {
        // access text property of selected option
        el.value = sel.options[sel.selectedIndex].text;
    }

    document.getElementById('doLoop').onclick = function () {
        var opt = getSelectedOption(sel);
        el.value = opt.value;
    }
    
}());
// immediate function to preserve global namespace

var express = require('express');
var app = express();

