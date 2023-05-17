// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var uri = 'api/MyFirst';

function LynnwoodDisplay() {
    $.getJSON(uri)
        .done(function (data) {
            console.log(data);
            drawTable(data);
        })
        .fail(function (jqXHR, textStatus, err) {

            console.log();
        });

}

function drawTable(data) {
    // get the reference for the table
    // creates a <table> element
    var tbl = document.getElementById('q1Table');
    while (tbl.rows.length > 1) {  // clear, but don't delete the header
        tbl.deleteRow(1);
    }

    // creating rows    
        var row = document.createElement("tr");
        var cell0 = document.createElement("td");
    var cell1 = document.createElement("td");

        cell0.appendChild(document.createTextNode(data[0]));
        row.appendChild(cell0);
        cell1.appendChild(document.createTextNode(data[1]));
        row.appendChild(cell1);


        tbl.appendChild(row); // add the row to the end of the table body
    

}