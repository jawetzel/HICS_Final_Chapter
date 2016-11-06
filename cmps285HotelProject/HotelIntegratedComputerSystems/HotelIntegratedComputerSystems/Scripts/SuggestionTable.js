﻿//used in booking/create

//for hiding/unhiding an element (in this case, intended for suggestion table)
function showTable(element) {
    if (element.style.display === "none") {
        element.style.display = "";
    }
    else {
        element.style.display = "none";
    }
}


//for copying clicked result to CustomerName and CustomerId fields
function copyTo(listName) {
    var outputName = document.getElementById("myInput");
    var outputId = document.getElementById("CustomerId");
    var td = listName.getElementsByTagName("td");
    outputName.value = td[0].innerText;
    outputId.value = td[1].innerText;
}


function forwardTo3(row, listName, loc1, loc2, loc3) {

    var tablerow = row.getElementsByTagName("td");
    document.getElementById(loc1).value = tablerow[0].innerText;
    document.getElementById(loc2).value = tablerow[1].innerText;
    document.getElementById(loc3).value = tablerow[2].innerText;
    showTable(listName);
}

function forwardTo2(row, listName, loc1, loc2) {

    var tablerow = row.getElementsByTagName("td");
    document.getElementById(loc1).value = tablerow[0].innerText;
    document.getElementById(loc2).value = tablerow[1].innerText;
    showTable(listName);
}

function forwardTo1(row, listName, loc1) {

    var tablerow = row.getElementsByTagName("td");
    document.getElementById(loc1).value = tablerow[0].innerText;
    showTable(listName);
}