//used in booking/create

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

function forwardTo1(row, listName, loc1) {

    var tablerow = row.getElementsByTagName("td");
    document.getElementById(loc1).value = tablerow[0].innerText;
}

function forwardTo2(row, listName, loc1, loc2) {

    var tablerow = row.getElementsByTagName("td");
    document.getElementById(loc1).value = tablerow[0].innerText;
    document.getElementById(loc2).value = tablerow[1].innerText;
}

function forwardTo3(row, listName, loc1, loc2, loc3) {

    var tablerow = row.getElementsByTagName("td");
    document.getElementById(loc1).value = tablerow[0].innerText;
    document.getElementById(loc2).value = tablerow[1].innerText;
    document.getElementById(loc3).value = tablerow[2].innerText;
}

function forwardTo4(row, listName, loc1, loc2, loc3, loc4) {

    var tablerow = row.getElementsByTagName("td");
    document.getElementById(loc1).value = tablerow[0].innerText;
    document.getElementById(loc2).value = tablerow[1].innerText;
    document.getElementById(loc3).value = tablerow[2].innerText;
    document.getElementById(loc4).value = tablerow[3].innerText;
}

function forwardTo5(row, listName, loc1, loc2, loc3, loc4, loc5) {

    var tablerow = row.getElementsByTagName("td");
    document.getElementById(loc1).value = tablerow[0].innerText;
    document.getElementById(loc2).value = tablerow[1].innerText;
    document.getElementById(loc3).value = tablerow[2].innerText;
    document.getElementById(loc4).value = tablerow[3].innerText;
    document.getElementById(loc5).value = tablerow[4].innerText;
}

function forwardTo6(row, listName, loc1, loc2, loc3, loc4, loc5, loc6) {

    var tablerow = row.getElementsByTagName("td");
    document.getElementById(loc1).value = tablerow[0].innerText;
    document.getElementById(loc2).value = tablerow[1].innerText;
    document.getElementById(loc3).value = tablerow[2].innerText;
    document.getElementById(loc4).value = tablerow[3].innerText;
    document.getElementById(loc5).value = tablerow[4].innerText;
    document.getElementById(loc6).value = tablerow[5].innerText;
}

function forwardTo7(row, listName, loc1, loc2, loc3, loc4, loc5, loc6, loc7) {

    var tablerow = row.getElementsByTagName("td");
    document.getElementById(loc1).value = tablerow[0].innerText;
    document.getElementById(loc2).value = tablerow[1].innerText;
    document.getElementById(loc3).value = tablerow[2].innerText;
    document.getElementById(loc4).value = tablerow[3].innerText;
    document.getElementById(loc5).value = tablerow[4].innerText;
    document.getElementById(loc6).value = tablerow[5].innerText;
    document.getElementById(loc7).value = tablerow[6].innerText;
}

function forwardTo8(row, listName, loc1, loc2, loc3, loc4, loc5, loc6, loc7, loc8) {

    var tablerow = row.getElementsByTagName("td");
    document.getElementById(loc1).value = tablerow[0].innerText;
    document.getElementById(loc2).value = tablerow[1].innerText;
    document.getElementById(loc3).value = tablerow[2].innerText;
    document.getElementById(loc4).value = tablerow[3].innerText;
    document.getElementById(loc5).value = tablerow[4].innerText;
    document.getElementById(loc6).value = tablerow[5].innerText;
    document.getElementById(loc7).value = tablerow[6].innerText;
    document.getElementById(loc8).value = tablerow[7].innerText;
}

function forwardTo9(row, listName, loc1, loc2, loc3, loc4, loc5, loc6, loc7, loc8, loc9) {

    var tablerow = row.getElementsByTagName("td");
    document.getElementById(loc1).value = tablerow[0].innerText;
    document.getElementById(loc2).value = tablerow[1].innerText;
    document.getElementById(loc3).value = tablerow[2].innerText;
    document.getElementById(loc4).value = tablerow[3].innerText;
    document.getElementById(loc5).value = tablerow[4].innerText;
    document.getElementById(loc6).value = tablerow[5].innerText;
    document.getElementById(loc7).value = tablerow[6].innerText;
    document.getElementById(loc8).value = tablerow[7].innerText;
    document.getElementById(loc9).value = tablerow[8].innerText;
}

function forwardTo10(row, listName, loc1, loc2, loc3, loc4, loc5, loc6, loc7, loc8, loc9, loc10) {

    var tablerow = row.getElementsByTagName("td");
    document.getElementById(loc1).value = tablerow[0].innerText;
    document.getElementById(loc2).value = tablerow[1].innerText;
    document.getElementById(loc3).value = tablerow[2].innerText;
    document.getElementById(loc4).value = tablerow[3].innerText;
    document.getElementById(loc5).value = tablerow[4].innerText;
    document.getElementById(loc6).value = tablerow[5].innerText;
    document.getElementById(loc7).value = tablerow[6].innerText;
    document.getElementById(loc8).value = tablerow[7].innerText;
    document.getElementById(loc9).value = tablerow[8].innerText;
    document.getElementById(loc10).value = tablerow[9].innerText;
}