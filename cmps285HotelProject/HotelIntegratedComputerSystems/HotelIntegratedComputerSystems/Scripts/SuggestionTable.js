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


function forwardTo(row, listName, loc1, loc2, loc3, loc4) {

    var tablerow = row.getElementsByTagName4("td");
    document.getElementById(loc1).value = tablerow[0].innerText;
    document.getElementById(loc2).value = tablerow[1].innerText;
    document.getElementById(loc3).value = tablerow[2].innerText;
    document.getElementById(loc4).value = tablerow[3].innerText;
    showTable(listName);
}